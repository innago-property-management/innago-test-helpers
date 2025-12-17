namespace UnitTests.TestHelpers;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using AwesomeAssertions;
using AwesomeAssertions.Specialized;

using JetBrains.Annotations;

using Moq;

using Innago.Shared.UnitTesting.TestHelpers;

using Xunit.Sdk;

using static Innago.Shared.UnitTesting.TestHelpers.MethodChecker;

[UnitTest(nameof(MethodChecker))]
public class MethodCheckerTests
{
    [Fact]
    public void VerifyMethodShouldReturnMethodInfo()
    {
        var d = new Dummy();

        MethodInfo? expected = d.GetType().GetMethod(
            nameof(d.GetFullName),
            BindingFlags.Public | BindingFlags.Instance,
            new[]
            {
                typeof(string),
                typeof(string),
            });

        const string? firstName = default;
        const string? lastName = default;
        MethodInfo actual = VerifyMethod<string>(() => d.GetFullName(firstName, lastName));

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void VerifyMethodShouldFailIfTheReturnTypeDiffers()
    {
        var d = new Dummy();

        Action act = () => VerifyMethod<bool>(() => d.GetFullName(default, default));

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyMethodShouldNotFailIfTheReturnTypeMatches()
    {
        var d = new Dummy();

        Action act = () => VerifyMethod<string>(() => d.GetFullName(default, default));

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyMethodAttributeShouldReturnAttributes()
    {
        var d = new Dummy();

        MethodInfo method = VerifyMethod<object?>(() => d.GetFullName(default));
        IEnumerable<MyAttribute> expected = method.GetCustomAttributes<MyAttribute>();

        IEnumerable<MyAttribute> actual = VerifyMethodAttribute<MyAttribute>(() => d.GetFullName(default));

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void VerifyMethodAttributeShouldFailIfNoAttribute()
    {
        var d = new Dummy();

        Action act = () => VerifyMethodAttribute<MyAttribute>(() => d.GetFullName(default, default));

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyMethodAttributeNotShouldFailIfAttribute()
    {
        var d = new Dummy();

        Action act = () => VerifyMethodAttribute<MyAttribute>(() => d.GetFullName(default));

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyParameterShouldReturnParameter()
    {
        const string parameterName = "lastName";

        MethodInfo method = VerifyMethod<string>(() => new Dummy().GetFullName(default));
        ParameterInfo expected = method.GetParameters().Single(p => p.Name == parameterName);

        ParameterInfo? actual = VerifyParameter(() => new Dummy().GetFullName(default), parameterName);

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void VerifyParameterShouldThrowIfNoMatchOnName()
    {
        Action act = () => VerifyParameter(() => new Dummy().GetFullName(default), "foo");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyParameterWithNameAndTypeShouldReturnParameter()
    {
        const string parameterName = "lastName";

        const string? lastName = default;

        MethodInfo method = VerifyMethod<string>(() => new Dummy().GetFullName(lastName));
        ParameterInfo expected = method.GetParameters().Single(p => p.Name == parameterName);

        Type parameterType = typeof(string);
        ParameterInfo? actual = VerifyParameter(() => new Dummy().GetFullName(lastName), parameterType, parameterName);

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void VerifyParameterWithNameAndTypeThrowIfNoMatchOnName()
    {
        Action act = () => VerifyParameter(() => new Dummy().GetFullName(default), typeof(string), "foo");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyParameterWithNameAndTypeParameterShouldThrowIfNoMatchOnName()
    {
        Action act = () => VerifyParameter<string>(() => new Dummy().GetFullName(default), "foo");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyParameterWithTypeParameterShouldThrowIfNoMatchOnType()
    {
        Action act = () => VerifyParameter<bool>(() => new Dummy().GetFullName(default), "lastName");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyParameterWithTypeParameterShouldReturnParameter()
    {
        const string parameterName = "lastName";

        MethodInfo method = VerifyMethod<string>(() => new Dummy().GetFullName(default));
        ParameterInfo expected = method.GetParameters().Single(p => p.Name == parameterName);

        ParameterInfo? actual = VerifyParameter<string>(() => new Dummy().GetFullName(default), "lastName");

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void VerifyParameterWithTypeParameterShouldNotFailIfMultipleReturnParameter()
    {
        const string parameterName = "lastName";

        MethodInfo method = VerifyMethod<string>(() => new Dummy().GetFullName(default, default));
        ParameterInfo expected = method.GetParameters().Single(p => p.Name == parameterName);

        ParameterInfo? actual = VerifyParameter<string>(() => new Dummy().GetFullName(default, default), "lastName");

        actual.Should().BeSameAs(expected);
    }

    [Fact]
    public void VerifyParameterAttributeShouldReturnTheAttribute()
    {
        var d = new Dummy();

        IEnumerable<MyAttribute> expected = d.GetType().GetMethod(nameof(d.GetFullName), new[] { typeof(string) })!.GetParameters()
            .Single(p => p.Name == "lastName").GetCustomAttributes<MyAttribute>();

        IEnumerable<MyAttribute> actual = VerifyParameterAttribute<MyAttribute>(() => d.GetFullName(default), "lastName");

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void VerifyParameterAttributeShouldThrowIfNoMatchingAttribute()
    {
        var d = new Dummy();

        Action act = () => VerifyParameterAttribute<PublicAPIAttribute>(() => d.GetFullName(default), "lastName");

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyThrowsShouldReturnExceptionAssertion()
    {
        object? e = null;

        try
        {
            e = VerifyThrows<NotImplementedException>(() => throw new NotImplementedException());
        }
        catch (Exception)
        {
            // expected
        }

        e.Should().NotBeNull();
        e.Should().BeOfType<ExceptionAssertions<NotImplementedException>>();
    }

    [Fact]
    public async Task VerifyThrowsAsyncShouldReturnExceptionAssertion()
    {
        object? e = null;

        try
        {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
            e = await VerifyThrowsAsync<NotImplementedException>(async () => throw new NotImplementedException());
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        }
        catch (Exception)
        {
            // expected
        }

        e.Should().NotBeNull();
        e.Should().BeOfType<ExceptionAssertions<NotImplementedException>>();
    }

    [Fact]
    public void VerifyUsesShouldVerifyUsage()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        VerifyUses(() => d.UseDoSomething(), Mock.Get(doSomething), something => something.DoSomething());
    }

    [Fact]
    public void VerifyUsesShouldVerifyUsageCount()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        VerifyUses(
            () => d.UseDoSomething(),
            Mock.Get(doSomething),
            something => something.DoSomething(),
            Times.Once());
    }

    [Fact]
    public void VerifyUsesFuncShouldVerifyUsage()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        VerifyUses(() => d.UseReturnSomething(), Mock.Get(doSomething), something => something.ReturnSomething());
    }

    [Fact]
    public void VerifyUsesFuncShouldVerifyUsageCount()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        VerifyUses(
            () => d.UseReturnSomething(),
            Mock.Get(doSomething),
            something => something.ReturnSomething(),
            Times.Once());
    }

    [Fact]
    public async Task VerifyUsesAsyncShouldVerifyUsage()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        await VerifyUsesAsync(
            async () => await d.UseDoSomethingAsync(),
            Mock.Get(doSomething),
            something => something.DoSomethingAsync());
    }

    [Fact]
    public async Task VerifyUsesAsyncShouldVerifyUsageCount()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        await VerifyUsesAsync(
            async () => await d.UseDoSomethingAsync(),
            Mock.Get(doSomething),
            something => something.DoSomethingAsync(),
            Times.Once());
    }

    [Fact]
    public async Task VerifyUsesAsyncShouldVerifyAction()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        await VerifyUsesAsync(
            async () => await d.UseDoSomethingAsync2(),
            Mock.Get(doSomething),
            something => something.DoSomething());
    }

    [Fact]
    public async Task VerifyUsesAsyncShouldVerifyActionCount()
    {
        var doSomething = Mock.Of<IDoSomething>(MockBehavior.Loose);
        var d = new Dummy(doSomething);

        await VerifyUsesAsync(
            async () => await d.UseDoSomethingAsync2(),
            Mock.Get(doSomething),
            something => something.DoSomething(),
            Times.Once());
    }

    [Fact]
    public void VerifyParameterDefaultShouldReturnParameter()
    {
        var d = new Dummy();

        ParameterInfo expected = d.GetType().GetMethod(nameof(d.MethodWithDefaultValuesForParameters))!.GetParameters().Single(info => info.Name == "b");

        ParameterInfo actual = VerifyParameterDefaultValue(() => d.MethodWithDefaultValuesForParameters(default!, default), "b", 1);

        actual.Should().Be(expected);
    }

    [Fact]
    public void VerifyParameterDefaultShouldNotThrowIfDefaultParameterValueMatches()
    {
        Dummy d = null!;
        const int expectedDefaultValue = 1;
        const string name = "b";

        Action act = () => VerifyParameterDefaultValue(
            () => d.MethodWithDefaultValuesForParameters(default!, default),
            name,
            expectedDefaultValue);

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyParameterDefaultShouldThrowIfDefaultParameterValueDoesNotMatch()
    {
        Dummy d = null!;
        const int expectedDefaultValue = 9999;
        const string name = "b";

        Action act = () => VerifyParameterDefaultValue(
            () => d.MethodWithDefaultValuesForParameters(default!, default),
            name,
            expectedDefaultValue);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyParameterDefaultShouldThrowIfDefaultParameterValueMissing()
    {
        Dummy d = null!;
        Dummy? expectedDefaultValue = null;
        const string name = "b";

        Action act = () => VerifyParameterDefaultValue(
            () => d.MethodWithDefaultValuesForParameters(default!, default),
            name,
            expectedDefaultValue);

        act.Should().Throw<XunitException>();
    }

    [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "class for testing")]
    // ReSharper disable once MemberCanBePrivate.Global
    public class Dummy
    {
        private readonly IDoSomething? doer;

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string StringProp { get; set; }

        public Dummy() : this(null)
        {
        }

        // ReSharper disable once ConvertToPrimaryConstructor
        public Dummy(IDoSomething? doer)
        {
            this.doer = doer;
            this.StringProp = string.Empty;
        }

        public void UseDoSomething()
        {
            this.doer?.DoSomething();
        }

        // ReSharper disable once UnusedMethodReturnValue.Global
        public object? UseReturnSomething()
        {
            return this.doer?.ReturnSomething();
        }

        public async Task UseDoSomethingAsync()
        {
            if (this.doer is not null)
            {
                await this.doer.DoSomethingAsync().ConfigureAwait(false);
            }
        }

        public Task UseDoSomethingAsync2()
        {
            this.doer?.DoSomething();
            return Task.CompletedTask;
        }

        public object MethodWithDefaultValuesForParameters(Dummy? a, int b = 1) => new { A = a, B = b };

        [My]
        public string GetFullName([My] string? lastName)
        {
            return $"{lastName}";
        }

#pragma warning disable S2325
        public string GetFullName(string? firstName, string? lastName)
#pragma warning restore S2325
        {
            return $"{(string.IsNullOrWhiteSpace(firstName) ? string.Empty : $"{firstName} ")} {lastName}";
        }
    }

    public interface IDoSomething
    {
        void DoSomething();
        object ReturnSomething();

        Task DoSomethingAsync();
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    private class MyAttribute : Attribute
    {
    }
}
