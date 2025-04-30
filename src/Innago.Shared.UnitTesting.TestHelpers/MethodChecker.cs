namespace Innago.Shared.UnitTesting.TestHelpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

using FluentAssertions;
using FluentAssertions.Specialized;

using JetBrains.Annotations;

using Moq;

/// <summary>
///     Unit test helpers for methods.
/// </summary>
[PublicAPI]
public static class MethodChecker
{
    /// <summary>
    ///     Verifies a method's parameters and return type.
    /// </summary>
    /// <param name="expression">
    ///     An expression representing the method.
    /// </param>
    /// <typeparam name="TReturn">
    ///     The expected return type of the method.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="MethodInfo"/> of the method so that further tests can be done.
    /// </returns>
    /// <example>
    /// <code>
    /// const string? firstName = default;
    /// const string? lastName = default;
    /// MethodChecker.VerifyMethod&lt;string>(() => d.GetFullName(firstName, lastName));
    /// </code>
    /// </example>
    public static MethodInfo VerifyMethod<TReturn>(Expression<Func<object?>> expression)
    {
        var methodCallExpression = expression.Body as MethodCallExpression;

        methodCallExpression.Should().NotBeNull();
        methodCallExpression!.Method.ReturnParameter.ParameterType.Should().BeAssignableTo<TReturn>();

        return methodCallExpression.Method;
    }

    /// <summary>
    ///     Verifies that a method has an attribute.
    /// </summary>
    /// <param name="expression">
    ///     The method expression.
    /// </param>
    /// <typeparam name="TAttribute">
    ///     The attribute type.
    /// </typeparam>
    /// <returns>
    ///     An <see cref="IEnumerable{T}"/> of <typeparamref name="TAttribute"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// var d = new MyType();
    /// MethodChecker.VerifyMethodAttribute&lt;MyAttribute>(
    ///     () => d.GetFullName(default));
    /// </code>
    /// </example>
    public static IEnumerable<TAttribute> VerifyMethodAttribute<TAttribute>(Expression<Func<object?>> expression)
        where TAttribute : Attribute
    {
        MethodInfo method = VerifyMethod<object?>(expression);

        IEnumerable<TAttribute> attributes = method.GetCustomAttributes<TAttribute>().ToList();

        attributes.Should().NotBeEmpty();

        return attributes;
    }

    /// <summary>
    ///     Verifies the existence of a parameter.
    /// </summary>
    /// <param name="expression">
    ///     The method call expression.
    /// </param>
    /// <param name="parameterName">
    ///     The name of the parameter.
    /// </param>
    /// <returns>
    ///     The <see cref="ParameterInfo"/>.
    /// </returns>
    /// <remarks>
    ///     Use the <see cref="VerifyParameter(System.Linq.Expressions.Expression{System.Func{object?}},Type,string?)"/> overload.
    /// </remarks>
    /// <example>
    /// <code>
    /// MethodChecker.VerifyParameter(() => new Dummy().GetFullName(default), "foo");
    /// </code>
    /// </example>
    public static ParameterInfo? VerifyParameter(Expression<Func<object?>> expression, string parameterName)
    {
        MethodInfo method = VerifyMethod<object?>(expression);

        ParameterInfo? parameter = method.GetParameters().SingleOrDefault(p => p.Name == parameterName);

        parameter.Should().NotBeNull();

        return parameter;
    }

    /// <summary>
    ///     Verifies the existence of a parameter with the specified type.
    ///     Also checks the <paramref name="name"/>.
    /// </summary>
    /// <param name="expression">
    ///     The method call expression.
    /// </param>
    /// <param name="name">
    ///     The parameter name.
    /// </param>
    /// <typeparam name="TParameter">
    ///     The type of the parameter.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ParameterInfo"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// MethodChecker.VerifyParameter&lt;string>(
    ///     () => new Dummy().GetFullName(default),
    ///     "lastName");
    /// </code>
    /// </example>
    public static ParameterInfo? VerifyParameter<TParameter>(Expression<Func<object?>> expression, string name)
    {
        return VerifyParameter(expression, typeof(TParameter), name);
    }

    /// <summary>
    ///     This is the same as <see cref="VerifyParameter{T}(System.Linq.Expressions.Expression{System.Func{object?}},string)"/>
    /// </summary>
    /// <param name="expression">
    ///     The method expression.
    /// </param>
    /// <param name="parameterType">
    ///     The type of the parameter.
    /// </param>
    /// <param name="name">
    ///     The name.
    /// </param>
    /// <returns>
    ///     The <see cref="ParameterInfo"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// const string parameterName = "lastName";
    /// const string? lastName = default;
    /// Type parameterType = typeof(string);
    /// MethodChecker.VerifyParameter(
    ///     () => new Dummy().GetFullName(lastName),
    ///     parameterType,
    ///     parameterName);
    /// </code>
    /// </example>
    public static ParameterInfo? VerifyParameter(Expression<Func<object?>> expression, Type parameterType, string? name = null)
    {
        MethodInfo method = VerifyMethod<object?>(expression);

        ParameterInfo? parameter = method.GetParameters().ToList().Find(p => p.ParameterType == parameterType && (name is null || p.Name == name));

        parameter.Should().NotBeNull();

        if (!string.IsNullOrWhiteSpace(name))
        {
            parameter!.Name.Should().Be(name);
        }

        return parameter;
    }

    /// <summary>
    ///     Verifies that an attribute of type <typeparamref name="TAttribute"/> is applied to the parameter.
    /// </summary>
    /// <param name="expression">
    ///     The method expression.
    /// </param>
    /// <param name="parameterName">
    ///     The parameter name.
    /// </param>
    /// <typeparam name="TAttribute">
    ///     The type of the attribute.
    /// </typeparam>
    /// <returns>
    ///     An <see cref="IEnumerable{T}"/> of <typeparamref name="TAttribute"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// MethodChecker.VerifyParameterAttribute&lt;MyAttribute>(() => d.GetFullName(default), "lastName");
    /// </code>
    /// </example>
    public static IEnumerable<TAttribute> VerifyParameterAttribute<TAttribute>(
        Expression<Func<object?>> expression,
        string parameterName)
        where TAttribute : Attribute
    {
        ParameterInfo? parameter = VerifyParameter(expression, parameterName);

        IEnumerable<TAttribute> attributes = parameter!.GetCustomAttributes<TAttribute>().ToList();

        attributes.Should().NotBeEmpty();

        return attributes;
    }

    /// <summary>
    ///     Verifies that the parameter has the expected default value.
    /// </summary>
    /// <param name="expression">
    ///     The <see cref="MethodCallExpression"/>.
    /// </param>
    /// <param name="name">
    ///     The name of the parameter to check.
    /// </param>
    /// <param name="expectedDefaultValue">
    ///     The expected default value.
    /// </param>
    /// <typeparam name="TParameter">
    ///     The type of the parameter.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ParameterInfo"/>.
    /// </returns>
    /// <example>
    /// <code>
    /// Dummy d = null!;
    /// const int expectedDefaultValue = 9999;
    /// const string name = "b";
    ///
    /// MethodChecker.VerifyParameterDefaultValue(
    ///     () => d.MethodWithDefaultValuesForParameters(default!, default),
    ///     name,
    ///     expectedDefaultValue);
    /// </code>
    /// </example>
    public static ParameterInfo VerifyParameterDefaultValue<TParameter>(
        Expression<Func<object?>> expression,
        string name,
        TParameter expectedDefaultValue)
    {
        ParameterInfo parameter = VerifyParameter<TParameter>(expression, name)!;

        var defaultValue = (TParameter?)parameter.RawDefaultValue;

        if (typeof(TParameter).IsEnum && defaultValue is not null)
        {
            defaultValue.As<TParameter>().Should().BeEquivalentTo(expectedDefaultValue);
        }
        else
        {
            defaultValue.Should().Be(expectedDefaultValue);
        }

        return parameter;
    }

    /// <summary>
    ///     A helper to replace
    ///     <code>
    ///         Action act = () => { /* ... */ });
    ///         act.Should.Throw&lt;TException&gt;();
    ///     </code>
    /// </summary>
    /// <param name="action">
    ///     The method call expression.
    /// </param>
    /// <typeparam name="TException">
    ///     The expected exception type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ExceptionAssertions{TException}"/> so that additional tests can be made.
    /// </returns>
    /// <example>
    /// <code>MethodChecker.VerifyThrows&lt;NotImplementedException>(() => throw new NotImplementedException());</code>
    /// </example>
    public static ExceptionAssertions<TException>? VerifyThrows<TException>(Action action) where TException : Exception
    {
        ExceptionAssertions<TException>? assertions = action.Should().Throw<TException>();

        return assertions;
    }

    /// <summary>
    ///     A helper to replace
    ///     <code>
    ///         async act = () =>     { /* ... */ });
    ///         act.should.ThrowAsync&lt;TException&gt;();
    ///     </code>
    /// </summary>
    /// <param name="action">
    ///     The async method call expression.
    /// </param>
    /// <typeparam name="TException">
    ///     The expected exception type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ExceptionAssertions{TException}"/> so that additional tests can be made.
    /// </returns>
    /// <example>
    /// <code>MethodChecker.VerifyThrowsAsync&lt;NotImplementedException>(() =? throw new NotImplementedException());</code>
    /// </example>
    public static async Task<ExceptionAssertions<TException>?> VerifyThrowsAsync<TException>(Func<Task> action) where TException : Exception
    {
        ExceptionAssertions<TException>? assertions = await action.Should().ThrowAsync<TException>();

        return assertions;
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <example>
    /// <code>
    /// var doSomething = Mock.Of&lt;IDoSomething>();
    /// var d = new Dummy(doSomething);
    /// MethodChecker.VerifyUses(
    ///     () => d.UseDoSomething(),
    ///     Mock.Get(doSomething),
    ///     something => something.DoSomething());
    /// </code>
    /// </example>
    public static void VerifyUses<T>(
        Action act,
        Mock<T> mock,
        Expression<Action<T>> expression) where T : class
    {
        VerifyUses(act, mock, expression, Times.AtLeastOnce());
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <param name="times">The <see cref="Times"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <example>
    /// <code>
    ///var doSomething = Mock.Of&lt;IDoSomething>();
    /// var d = new Dummy(doSomething);
    /// MethodChecker.VerifyUses(
    ///     () => d.UseDoSomething(),
    ///     Mock.Get(doSomething),
    ///     something => something.DoSomething(),
    ///     Times.Once());
    /// </code>
    /// </example>
    public static void VerifyUses<T>(
        Action act,
        Mock<T> mock,
        Expression<Action<T>> expression,
        Times times) where T : class
    {
        act();

        mock.Verify(expression, times);
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <example>
    /// <code>MethodChecker.VerifyUses(() => d.UseReturnSomething(), Mock.Get(doSomething), something => something.ReturnSomething());</code>
    /// </example>
    public static void VerifyUses<T, TResult>(
        Action act,
        Mock<T> mock,
        Expression<Func<T, TResult>> expression) where T : class
    {
        VerifyUses(act, mock, expression, Times.AtLeastOnce());
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <param name="times">The <see cref="Times"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public static void VerifyUses<T, TResult>(
        Action act,
        Mock<T> mock,
        Expression<Func<T, TResult>> expression,
        Times times) where T : class
    {
        act();

        mock.Verify(expression, times);
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <example>
    /// <code>
    ///var doSomething = Mock.Of&lt;IDoSomething>();
    /// var d = new Dummy(doSomething);
    /// await VerifyUsesAsync(
    ///     async () => await d.UseDoSomethingAsync2(),
    ///     Mock.Get(doSomething),
    ///     something => something.DoSomething());
    /// </code>
    /// </example>
    public static Task VerifyUsesAsync<T>(
        Func<Task> act,
        Mock<T> mock,
        Expression<Action<T>> expression)
        where T : class
    {
        return VerifyUsesAsync(act, mock, expression, Times.AtLeastOnce());
    }

    /// <summary>
    ///     Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    /// </summary>
    /// <remarks> This is just syntactic sugar.</remarks>
    /// <param name="act">The <see cref="Action"/>.</param>
    /// <param name="mock">The <see cref="Mock{T}"/>.</param>
    /// <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    /// <param name="times">The <see cref="Times"/>.</param>
    /// <typeparam name="T">The type of the mocked object.</typeparam>
    /// <example>
    /// <code>
    ///var doSomething = Mock.Of&lt;IDoSomething>();
    /// var d = new Dummy(doSomething);
    /// await VerifyUsesAsync(
    ///     async () => await d.UseDoSomethingAsync2(),
    ///     Mock.Get(doSomething),
    ///     something => something.DoSomething(),
    ///     Times.Once());
    /// </code>
    /// </example>
    public static async Task VerifyUsesAsync<T>(
        Func<Task> act,
        Mock<T> mock,
        Expression<Action<T>> expression,
        Times times)
        where T : class
    {
        await act().ConfigureAwait(false);
        mock.Verify(expression, times);
    }

    ///  <summary>
    ///      Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    ///  </summary>
    ///  <remarks> This is just syntactic sugar.</remarks>
    ///  <param name="act">The <see cref="Action"/>.</param>
    ///  <param name="mock">The <see cref="Mock{T}"/>.</param>
    ///  <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    ///  <typeparam name="T">The type of the mocked object.</typeparam>
    ///  <typeparam name="TResult">The expression result type.</typeparam>
    ///  <example>
    ///  <code>
    /// var doSomething = Mock.Of&lt;IDoSomething>();
    ///  var d = new Dummy(doSomething);
    ///  await VerifyUsesAsync(
    ///      async () => await d.UseDoSomethingAsync(),
    ///      Mock.Get(doSomething),
    ///      something => something.DoSomethingAsync());
    ///  </code>
    ///  </example>
    public static Task VerifyUsesAsync<T, TResult>(
        Func<Task> act,
        Mock<T> mock,
        Expression<Func<T, TResult>> expression)
        where T : class
    {
        return VerifyUsesAsync(act, mock, expression, Times.AtLeastOnce());
    }

    ///  <summary>
    ///      Verifies that the <paramref name="act"/> uses the method indicated in <paramref name="expression"/> on the <paramref name="mock"/> object.
    ///  </summary>
    ///  <remarks> This is just syntactic sugar.</remarks>
    ///  <param name="act">The <see cref="Action"/>.</param>
    ///  <param name="mock">The <see cref="Mock{T}"/>.</param>
    ///  <param name="expression">The <see cref="Expression{TDelegate}"/> of <see cref="Action{T}"/>.</param>
    ///  <param name="times">The <see cref="Times"/>.</param>
    ///  <typeparam name="T">The type of the mocked object.</typeparam>
    ///  <typeparam name="TResult">The expression result type.</typeparam>
    ///  <example>
    ///  <code>
    /// var doSomething = Mock.Of&lt;IDoSomething>();
    ///  var d = new Dummy(doSomething);
    ///  await VerifyUsesAsync(
    ///      async () => await d.UseDoSomethingAsync(),
    ///      Mock.Get(doSomething),
    ///      something => something.DoSomethingAsync(),
    ///      Times.Once());
    ///  </code>
    ///  </example>
    public static async Task VerifyUsesAsync<T, TResult>(
        Func<Task> act,
        Mock<T> mock,
        Expression<Func<T, TResult>> expression,
        Times times)
        where T : class
    {
        await act().ConfigureAwait(false);
        mock.Verify(expression, times);
    }
}