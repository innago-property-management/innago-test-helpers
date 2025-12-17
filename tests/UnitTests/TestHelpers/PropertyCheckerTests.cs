namespace UnitTests.TestHelpers;

using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

using AwesomeAssertions;

using Innago.Shared.UnitTesting.TestHelpers;

using Xunit;
using Xunit.Sdk;

[UnitTest(nameof(PropertyChecker))]
public class PropertyCheckerTests
{
    [Fact]
    public void CheckAttributeShouldFailIfNoAttribute()
    {
        var target = new Dummy();

        Action act = () => PropertyChecker.CheckAttribute<Attribute>(() => target.ReadInitNullableString);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckAttributeShouldNotFailIfAttribute()
    {
        var target = new Dummy();

        Action act = () => PropertyChecker.CheckAttribute<RequiredAttribute>(() => target.RequiredString);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckAttributeShouldReturnAttribute()
    {
        var target = new Dummy();

        var a = PropertyChecker.CheckAttribute<RequiredAttribute>(() => target.RequiredString);

        a.Should().BeOfType<RequiredAttribute>().And.NotBeNull();
    }

    [Fact]
    public void CheckAttributeShouldWorkWithAnInterface()
    {
        ISomeInterface? someInterface = null;

        Action act = () => PropertyChecker.CheckAttribute<RequiredAttribute>(() => someInterface!.Name);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckInvarianceWithValueShouldSucceedIfInvariant()
    {
        Dummy target = new() { ReadWriteString = "a" };
        Action act = () => PropertyChecker.CheckInvarianceWithValue(() => target.ReadWriteString == "b");
        act.Should().NotThrow();
    }

    [Fact]
    public void CheckInvarianceWithValueShouldFailSucceedIfNotInvariant()
    {
        Dummy target = new();
        Action act = () => PropertyChecker.CheckInvarianceWithValue(() => target.PropertyThatChangesTheValue == "b");
        act.Should().Throw<XunitException>();
    }

    public static IEnumerable<object[]> InvarianceTestCases
    {
        get
        {
            var target = new Dummy();

            var expressions = new LambdaExpression[]
            {
                (Expression<Func<bool>>)(() => target.BoolProp),
                (Expression<Func<bool?>>)(() => target.NullableBoolProp),
                (Expression<Func<char>>)(() => target.CharProp),
                (Expression<Func<string?>>)(() => target.ReadWriteString),
                (Expression<Func<sbyte>>)(() => target.SByteProp),
                (Expression<Func<byte>>)(() => target.ByteProp),
                (Expression<Func<short>>)(() => target.ShortProp),
                (Expression<Func<int>>)(() => target.IntProp),
                (Expression<Func<uint>>)(() => target.UintProp),
                (Expression<Func<long>>)(() => target.LongProp),
                (Expression<Func<ulong>>)(() => target.ULongProp),
                (Expression<Func<float>>)(() => target.FloatProp),
                (Expression<Func<double>>)(() => target.DoubleProp),
                (Expression<Func<decimal>>)(() => target.DecimalProp),
                (Expression<Func<DateTime>>)(() => target.DateTimeProp),
                (Expression<Func<Guid>>)(() => target.GuidProp),
                (Expression<Func<Dummy?>>)(() => target.DummyProp),
                (Expression<Func<object?>>)(() => target.ObjectProp),
            };

            foreach (LambdaExpression expression in expressions)
            {
                yield return new object[] { expression };
            }
        }
    }

    [Theory]
    [MemberData(nameof(InvarianceTestCases))]
    public void CheckInvarianceShouldWorkForCommonTypes<T>(Expression<Func<T>> expression)
    {
        Action act = () => PropertyChecker.CheckInvariance(expression);
        act.Should().NotThrow();
    }

    [Fact]
    public void CheckMaxLengthShouldThrowIfNoAttribute()
    {
        Dummy d = null!;
        Action act = () => PropertyChecker.CheckMaxLength(() => d.ReadInitNullableString, 0);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckMaxLengthShouldThrowIfWrongLength()
    {
        Dummy d = null!;
        Action act = () => PropertyChecker.CheckMaxLength(() => d.ReadWriteString, 0);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckMaxLengthShouldNotThrowIfCorrectLength()
    {
        Dummy d = null!;
        Action act = () => PropertyChecker.CheckMaxLength(() => d.ReadWriteString, 100);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckRangeShouldThrowIfNoAttribute()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRange(() => target.IntProp, 1, 2);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckRangeShouldThrowIfBadMin()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRange(() => target.IntPropWithRange, 0, 10);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckRangeShouldThrowIfBadMax()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRange(() => target.IntPropWithRange, 1, 11);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckRangeShouldNotThrowIfGoodValues()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRange(() => target.IntPropWithRange, 1, 10);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckRequiredShouldThrowIfNoAttribute()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRequired(() => target.ReadWriteString);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckRequiredShouldNotThrowIfFalseAllowEmptyStringsValue()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRequired(() => target.RequiredString);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckRequiredShouldNotThrowIfTrueAllowEmptyStringsValue()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckRequired(() => target.RequiredStringAllowEmpty, true);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckInitOnlyShouldThrowIfSet()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckInitOnly(() => target.DummyProp);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckInitOnlyShouldNotThrowIfInit()
    {
        Dummy target = null!;

        Action act = () => PropertyChecker.CheckInitOnly(() => target.ReadInitNullableString);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckPropertyShouldReturnProperty()
    {
        var t = new Dummy();

        PropertyInfo? expected = t.GetType().GetProperty(nameof(t.BoolProp));
        PropertyInfo actual = PropertyChecker.CheckProperty<bool>(() => t.BoolProp);

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void CheckPropertyShouldFailIfBadPropertyType()
    {
        Dummy t = null!;

        Action act = () => PropertyChecker.CheckProperty<int>(() => t.ShortProp);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckPropertyShouldFailIfWriteableWhenExpectReadOnly()
    {
        Dummy t = null!;

        Action act = () => PropertyChecker.CheckProperty<short>(() => t.ShortProp, readOnly: true);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckPropertyShouldFailIfReadOnlyWhenExpectWritable()
    {
        Dummy t = null!;

        Action act = () => PropertyChecker.CheckProperty<short>(() => t.ReadOnlyProp, readOnly: false);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckPropertyShouldFailIfDefaultValueNotExpected()
    {
        var t = new Dummy();

        Action act = () => PropertyChecker.CheckProperty<Guid>(() => t.InitializedGuidProp);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void CheckPropertyShouldNotFailIfSkipDefaultValueCheck()
    {
        var t = new Dummy();

        Action act = () => PropertyChecker.CheckProperty<Guid>(
            () => t.InitializedGuidProp,
            skipDefaultValueCheck: true);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckPropertyShouldNotFailIfForEquivalentDefaultValue()
    {
        var t = new Dummy();

        Action act = () => PropertyChecker.CheckProperty<object>(
            () => t.InitializedObjectProp,
            expectedDefaultValue: new List<string> { "a" },
            testDefaultEquivalence: true);

        act.Should().NotThrow();
    }

    [Fact]
    public void CheckPropertyShouldFailForEquivalentDefaultValueWithoutSwitch()
    {
        var t = new Dummy();

        Action act = () => PropertyChecker.CheckProperty<object>(
            () => t.InitializedObjectProp,
            expectedDefaultValue: new List<string> { "a" },
            testDefaultEquivalence: false);

        act.Should().Throw<XunitException>();
    }

#pragma warning disable S3459
#pragma warning disable S1144
    // ReSharper disable All
    private class Dummy
    {
        private string? propertyThatChangesTheValue;

        public string ReadOnlyProp { get; } = null!;

        [MaxLength(100)]
        public string? ReadWriteString { get; set; }

        public string? ReadInitNullableString { get; init; }

        [Required]
        public string? RequiredString { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string? RequiredStringAllowEmpty { get; set; }

        public string? PropertyThatChangesTheValue
        {
            get => this.propertyThatChangesTheValue;
            set => this.propertyThatChangesTheValue = $"{value} changed";
        }

        public bool BoolProp { get; set; } = default;
        public bool? NullableBoolProp { get; set; }
        public char CharProp { get; set; } = default;
        public sbyte SByteProp { get; set; } = default;
        public byte ByteProp { get; set; } = default;
        public short ShortProp { get; set; } = default;
        public int IntProp { get; set; } = default;

        [Range(1, 10)]
        public int IntPropWithRange { get; set; } = default;

        public uint UintProp { get; set; } = default;
        public long LongProp { get; set; } = default;
        public ulong ULongProp { get; set; } = default;
        public float FloatProp { get; set; } = default;
        public double DoubleProp { get; set; } = default;
        public decimal DecimalProp { get; set; } = default;
        public DateTime DateTimeProp { get; set; } = default;
        public Guid GuidProp { get; set; } = Guid.Empty;
        public Dummy? DummyProp { get; set; } = default;
        public object? ObjectProp { get; set; } = default;
        public Guid InitializedGuidProp { get; set; } = Guid.NewGuid();

        public object InitializedObjectProp { get; set; } = new List<string> { "a" };
    }

    private interface ISomeInterface
    {
        [Required]
        string Name { get; set; }
    }
#pragma warning restore S1144
#pragma warning restore S3459
}
