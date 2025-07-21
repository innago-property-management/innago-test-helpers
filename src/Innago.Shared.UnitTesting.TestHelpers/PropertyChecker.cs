namespace Innago.Shared.UnitTesting.TestHelpers;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using AwesomeAssertions;

using JetBrains.Annotations;

/// <summary>
///     Helps verify property traits
/// </summary>
[PublicAPI]
public static class PropertyChecker
{
    /// <summary>
    ///     Checks that an attribute exists on the property specified.
    /// </summary>
    /// <param name="expression">
    ///     An <see cref="Expression{T}"/> that represents the property.
    ///     Example, <code>PropertyChecker.CheckAttribute&lt;MyAttribute&gt;(() => someObject.someProperty);</code>
    /// </param>
    /// <typeparam name="TAttribute">The attribute type.</typeparam>
    /// <returns>
    ///     The attribute, so that other tests can be done on it if desired.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the <paramref name="expression"/> is not a property.
    /// </exception>
    /// <example>
    /// <code>
    /// ISomeInterface? someInterface = null;
    /// Action act = () => PropertyChecker.CheckAttribute&lt;RequiredAttribute>(() => someInterface!.Name);
    /// </code>
    /// </example>
    public static TAttribute CheckAttribute<TAttribute>(Expression<Func<object?>> expression) where TAttribute : Attribute
    {
        PropertyInfo property = GetPropertyInfo(expression);

        var attribute = property.GetCustomAttribute<TAttribute>();
        attribute.Should().NotBeNull();

        return attribute!;
    }

    /// <summary>
    ///     Checks a property for invariance (the value gotten is the same as the one set).
    /// </summary>
    /// <param name="expression">
    ///     An expression of the form <code>foo.bar == val</code> is expected, where bar is a
    ///     property.
    /// </param>
    /// <remarks>
    ///     You should prefer the <see cref="PropertyChecker.CheckInvariance{T}"/> method.
    ///     This syntax is borrowed from the simplified property setup in Moq.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    ///     Thrown if the <paramref name="expression"/> is not a comparison.
    /// </exception>
    /// <example>
    /// <code>
    /// Dummy target = new() { ReadWriteString = "a" };
    /// PropertyChecker.CheckInvarianceWithValue(() => target.ReadWriteString == "b");
    /// </code>
    /// </example>
    public static void CheckInvarianceWithValue(Expression<Func<bool>> expression)
    {
        (MemberExpression? left, ConstantExpression? right) = GetLeftRight(expression);

        object? expected = right.Value;

        BinaryExpression assignment = Expression.Assign(left, right);
        LambdaExpression assignmentLambda = Expression.Lambda(assignment);
        assignmentLambda.Compile().DynamicInvoke();

        UnaryExpression getter = Expression.Convert(left, typeof(object));
        LambdaExpression getterLambda = Expression.Lambda(getter);
        object? actual = getterLambda.Compile().DynamicInvoke();

        actual.Should().Be(expected);
    }

    /// <summary>
    ///     Checks a property for invariance (the value gotten is the same as the one set).
    /// </summary>
    /// <typeparam name="T">The type of the value(s).</typeparam>
    /// <param name="expression">A property/member expression.</param>
    /// <param name="values">The values to use for testing.</param>
    /// <remarks>
    ///     For built-in value types, the <paramref name="values" /> can be omitted if min, max, zero are acceptable.
    ///     <seealso cref="Nullable{T}" /> is supported.
    ///     <seealso cref="Guid" /> is supported.
    ///     <seealso cref="string" /> is tested with null, whitespace, aGUID, and a 100-character. Do not use this method if
    ///     truncation is important.
    /// </remarks>
    /// <example>
    /// <code>
    /// PropertyChecker.CheckInvariance(() => target.SomeProperty);
    /// </code>
    /// </example>
    public static void CheckInvariance<T>(Expression<Func<T>> expression, IEnumerable<T>? values = null)
    {
        if (expression.Body is not MemberExpression memberExpression)
        {
            throw new InvalidOperationException($"Expected a {nameof(MemberExpression)}.");
        }

        values ??= GetValuesForType<T>();

        IEnumerable<object?> values2 = values.Cast<object>();
        
        Type type = typeof(T);
        bool isNullable = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        if (isNullable)
        {
            values2 = values2.AsEnumerable().Concat(new object?[] { null });
        }

        foreach (T? value in values2)
        {
            ConstantExpression constantExpression;

            try
            {
                constantExpression = Expression.Constant(value, typeof(T));
            }
            catch
            {
                UnaryExpression cast = Expression.Convert(Expression.Constant(value), typeof(T));
                constantExpression = Expression.Constant(cast, typeof(T));
            }

            BinaryExpression binaryExpression = Expression.Equal(memberExpression, constantExpression);
            Expression<Func<bool>> lambda = Expression.Lambda<Func<bool>>(binaryExpression);
            CheckInvarianceWithValue(lambda);
        }
    }

    /// <summary>
    ///     Verifies that a <see cref="MaxLengthAttribute"/> with the correct <paramref name="maxLength"/> is on the property.
    /// </summary>
    /// <param name="expression">
    ///     An expression.
    /// </param>
    /// <param name="maxLength">The max length.</param>
    /// <example>
    /// <code>
    /// ISomeInterface i = null!;
    /// PropertyChecker.CheckMaxLength(() => i.StringProperty, 100)
    /// </code>
    /// </example>
    public static void CheckMaxLength(Expression<Func<object?>> expression, int maxLength)
    {
        PropertyInfo property = GetPropertyInfo(expression);

        var attribute = property.GetCustomAttribute<MaxLengthAttribute>();
        attribute.Should().NotBeNull();
        attribute!.Length.Should().Be(maxLength);
    }

    /// <summary>
    ///     Checks that a property has the correct characteristics: read/write, return type, default value.
    /// </summary>
    /// <typeparam name="T">The EXPECTED type of the property.</typeparam>
    /// <param name="expression">The property access expression.</param>
    /// <param name="readOnly">If <c>true</c>, then the property is not writable. Default is that properties are read-write.</param>
    /// <param name="expectedDefaultValue">The expected value when the property is not explicitly set.</param>
    /// <param name="testDefaultEquivalence">Set to true if testing equivalence is needed (edge case).</param>
    /// <param name="skipDefaultValueCheck">Set to true to skip default value check. Useful for timestamps, GUIDs.</param>
    /// <remarks>
    ///     Default value checks require an instance.
    /// </remarks>
    /// <returns>
    ///     The <see cref="PropertyInfo"/> of the matching property so that further testing can be done.
    /// </returns>
    /// <example>
    /// <code>
    /// var t = new SomeType();
    /// PropertyInfo property = PropertyChecker.CheckProperty&lt;bool>(() => t.BoolProp);
    /// </code>
    /// </example>
    public static PropertyInfo CheckProperty<T>(
        Expression<Func<object?>> expression,
        bool? readOnly = null,
        object? expectedDefaultValue = default,
        bool testDefaultEquivalence = false,
        bool skipDefaultValueCheck = false)
    {
        MemberExpression memberExpression = GetMemberExpression(expression);

        var property = (PropertyInfo)memberExpression.Member;
        property.Should().BeReadable();
        property.PropertyType.Should().Be<T>();

        if (readOnly != true)
        {
            property.Should().BeWritable();
        }
        else
        {
            property.Should().NotBeWritable();
        }

        if (skipDefaultValueCheck)
        {
            return property;
        }

        UnaryExpression convert = Expression.Convert(memberExpression, typeof(T));
        LambdaExpression lambda = Expression.Lambda<Func<T>>(convert);
        Delegate compile = lambda.Compile();
        object? actualDefault = compile.DynamicInvoke();
        expectedDefaultValue ??= GetDefault(typeof(T));

        if (testDefaultEquivalence)
        {
            actualDefault.Should().BeEquivalentTo(expectedDefaultValue);
        }
        else
        {
            actualDefault.Should().Be(expectedDefaultValue);
        }

        return property;
    }

    /// <summary>
    ///     Checks that a <see cref="RangeAttribute"/> with the correct values is present.
    /// </summary>
    /// <param name="expression">
    ///     The property expression.
    /// </param>
    /// <param name="minValue">The min value.</param>
    /// <param name="maxValue">The max value.</param>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <exception cref="InvalidOperationException">
    ///     <paramref name="expression"/> is not a member expression.
    /// </exception>
    /// <example>
    /// <code>
    /// PropertyChecker.CheckRange(() => target.IntPropWithRange, 1, 10);
    /// </code>
    /// </example>
    public static void CheckRange<TValue>(Expression<Func<object?>> expression, TValue minValue, TValue maxValue)
    {
        PropertyInfo property = GetPropertyInfo(expression);

        var attribute = property.GetCustomAttribute<RangeAttribute>();
        attribute.Should().NotBeNull();
        attribute!.Minimum.Should().Be(minValue);
        attribute.Maximum.Should().Be(maxValue);
    }

    /// <summary>
    ///     Verifies that a <see cref="RequiredAttribute"/> is present on the property.
    /// </summary>
    /// <param name="expression">
    ///     The member expression.
    /// </param>
    /// <param name="allowEmptyStrings">
    ///     If <see langword="true" />, then allow empty strings.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     The expression is not a member expression.
    /// </exception>
    /// <example>
    /// <code>
    /// PropertyChecker.CheckRequired(() => target.RequiredStringAllowEmpty, true);
    /// </code>
    /// </example>
    public static void CheckRequired(Expression<Func<object?>> expression, bool allowEmptyStrings = false)
    {
        PropertyInfo property = GetPropertyInfo(expression);

        var attribute = property.GetCustomAttribute<RequiredAttribute>();
        attribute.Should().NotBeNull();
        attribute!.AllowEmptyStrings.Should().Be(allowEmptyStrings);
    }

    /// <summary>
    ///         Verifies that a property is init-only.
    /// </summary>
    /// <param name="expression">
    ///     The member expression.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     The expression is not a member expression.
    /// </exception>
    /// <example>
    /// <code>
    /// PropertyChecker.CheckInitOnly(() => target.ReadInitNullableString);
    /// </code>
    /// </example>
    public static void CheckInitOnly(Expression<Func<object?>> expression)
    {
        PropertyInfo property = GetPropertyInfo(expression);

        MethodInfo? setMethod = property.GetSetMethod();

        setMethod.Should().NotBeNull();

        Type isExternalInitType = typeof(System.Runtime.CompilerServices.IsExternalInit);

        setMethod!.ReturnParameter.GetRequiredCustomModifiers().Should().Contain(isExternalInitType);
    }

    [ExcludeFromCodeCoverage]
    private static (MemberExpression left, ConstantExpression right) GetLeftRight(Expression<Func<bool>> expression)
    {
        if (expression.Body is BinaryExpression { Left: MemberExpression left, Right: ConstantExpression right })
        {
            return (left, right);
        }

        if (expression.Body is not MemberExpression memberExpression || memberExpression.Type != typeof(bool))
        {
            throw new InvalidOperationException($"Expected a {nameof(Boolean)} {nameof(BinaryExpression)} in the form `foo.bar == val`.");
        }

        left = memberExpression;
        right = Expression.Constant(true);

        return (left, right);
    }

    [ExcludeFromCodeCoverage]
    private static IEnumerable<T> GetValuesForType<T>()
    {
        Type? type = typeof(T);

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            type = Nullable.GetUnderlyingType(type);
        }

        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault
        return Type.GetTypeCode(type) switch
        {
            TypeCode.Boolean => new[] { false, true }.Cast<T>(),
            TypeCode.Char => new[] { char.MinValue, '\0', char.MaxValue }.Cast<T>(),
            TypeCode.SByte => new[] { sbyte.MinValue, (sbyte)0, sbyte.MaxValue }.Cast<T>(),
            TypeCode.Byte => new[] { byte.MinValue, (byte)0, byte.MaxValue }.Cast<T>(),
            TypeCode.Int16 => new[] { short.MinValue, (short)0, short.MaxValue }.Cast<T>(),
            TypeCode.UInt16 => new[] { ushort.MinValue, (ushort)0, ushort.MaxValue }.Cast<T>(),
            TypeCode.Int32 => new[] { int.MinValue, 0, int.MaxValue }.Cast<T>(),
            TypeCode.UInt32 => new[] { uint.MinValue, 0U, uint.MaxValue }.Cast<T>(),
            TypeCode.Int64 => new[] { long.MinValue, 0L, long.MaxValue }.Cast<T>(),
            TypeCode.UInt64 => new[] { ulong.MinValue, 0UL, ulong.MaxValue }.Cast<T>(),
            TypeCode.Single => new[] { float.MinValue, 0F, float.MaxValue }.Cast<T>(),
            TypeCode.Double => new[] { double.MinValue, 0D, double.MaxValue }.Cast<T>(),
            TypeCode.Decimal => new[] { decimal.MinValue, 0M, decimal.MaxValue }.Cast<T>(),
            TypeCode.DateTime => new[] { DateTime.MinValue, DateTime.MaxValue, default }.Cast<T>(),
            TypeCode.String => new[] { null, string.Empty, " ", new string('a', 100), Guid.NewGuid().ToString() }.Cast<T>(),
            TypeCode.Object => GetInvarianceTestValues(type).Cast<T>(),
            _ => throw new InvalidOperationException(
                $"Default values for type {typeof(T).Name} are not known. Please supply values."),
        };
    }

    [ExcludeFromCodeCoverage]
    private static PropertyInfo GetPropertyInfo(Expression<Func<object?>> expression)
    {
        return (PropertyInfo)GetMemberExpression(expression).Member;
    }

    [ExcludeFromCodeCoverage]
    private static MemberExpression GetMemberExpression(Expression<Func<object?>> expression)
    {
        if (expression.Body is UnaryExpression { Operand: MemberExpression memberExpression })
        {
            return memberExpression;
        }

        if (expression.Body is not MemberExpression tmp)
        {
            throw new InvalidOperationException($"Expected a {nameof(MemberExpression)}.");
        }

        memberExpression = tmp;

        return memberExpression;
    }

    [ExcludeFromCodeCoverage]
    private static object? GetDefault(Type t)
    {
        return t.IsValueType ? Activator.CreateInstance(t) : null;
    }

    [ExcludeFromCodeCoverage]
    private static IEnumerable<object?> GetInvarianceTestValues(Type? type)
    {
        IEnumerable<object?> retVal;

        if (type == typeof(Guid))
        {
            retVal = new object?[] { Guid.Empty, Guid.NewGuid() };
        }
        else if (type == typeof(DateTimeOffset))
        {
            retVal = new object?[] { DateTimeOffset.MinValue, default(DateTimeOffset), DateTimeOffset.MaxValue };
        }
        else
        {
            retVal = new object?[] { null };
        }

        return retVal;
    }
}