namespace UnitTests.TestHelpers;

using AwesomeAssertions;

using Microsoft.Extensions.DependencyInjection;

using Innago.Shared.UnitTesting.TestHelpers;

using Xunit;
using Xunit.Sdk;

[UnitTest(nameof(ServiceVerifier))]
public class ServiceVerifierTests
{
    [Fact]
    public void VerifyServiceShouldReturnServiceDescriptors()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMyType, MyType>();

        IEnumerable<ServiceDescriptor> expected = serviceCollection.Where(descriptor => descriptor.ServiceType == typeof(IMyType));

        IEnumerable<ServiceDescriptor> actual = serviceCollection.VerifyService<IMyType>();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void VerifyServiceShouldThrowIfServiceNotRegistered()
    {
        IServiceCollection serviceCollection = new ServiceCollection();

        Action act = () => serviceCollection.VerifyService<IMyType>();

        act.Should().Throw<XunitException>();
    }

    [Theory]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Singleton)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Singleton)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Singleton)]
    public void VerifyServiceShouldThrowIfServiceRegisteredWithWrongLifetime(
        ServiceLifetime actualServiceLifetime,
        ServiceLifetime expectedServiceLifetime)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        bool shouldThrow = actualServiceLifetime != expectedServiceLifetime;

        switch (actualServiceLifetime)
        {
            case ServiceLifetime.Singleton:
                serviceCollection.AddSingleton<IMyType, MyType>();
                break;
            case ServiceLifetime.Scoped:
                serviceCollection.AddScoped<IMyType, MyType>();
                break;
            case ServiceLifetime.Transient:
                serviceCollection.AddTransient<IMyType, MyType>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(actualServiceLifetime), actualServiceLifetime, null);
        }

        Action act = () => serviceCollection.VerifyService<IMyType>(expectedServiceLifetime);

        if (shouldThrow)
        {
            act.Should().Throw<XunitException>();
        }
        else
        {
            act.Should().NotThrow();
        }
    }

    [Fact]
    public void VerifyServiceShouldThrowIfWrongImplementationType()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMyType, MyType>();

        Action act = () => serviceCollection.VerifyService<IMyType, MyType2>();

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyServiceShouldNotThrowIfCorrectImplementationType()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMyType, MyType>();

        Action act = () => serviceCollection.VerifyService<IMyType, MyType>();

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Transient, ServiceLifetime.Singleton)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Scoped, ServiceLifetime.Singleton)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Transient)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Scoped)]
    [InlineData(ServiceLifetime.Singleton, ServiceLifetime.Singleton)]
    public void VerifyServiceShouldThrowIfServiceRegisteredWithImplementationAndWrongLifetime(
        ServiceLifetime actualServiceLifetime,
        ServiceLifetime expectedServiceLifetime)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        bool shouldThrow = actualServiceLifetime != expectedServiceLifetime;

        switch (actualServiceLifetime)
        {
            case ServiceLifetime.Singleton:
                serviceCollection.AddSingleton<IMyType, MyType>();
                break;
            case ServiceLifetime.Scoped:
                serviceCollection.AddScoped<IMyType, MyType>();
                break;
            case ServiceLifetime.Transient:
                serviceCollection.AddTransient<IMyType, MyType>();
                break;
        }

        Action act = () => serviceCollection.VerifyService<IMyType, MyType>(expectedServiceLifetime);

        if (shouldThrow)
        {
            act.Should().Throw<XunitException>();
        }
        else
        {
            act.Should().NotThrow();
        }
    }

    [Fact]
    public void VerifyServiceShouldNotThrowIfImplementationFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IMyType>(_ => new MyType());

        Action act = () => serviceCollection.VerifyService<IMyType>(ServiceLifetime.Singleton);

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyServiceShouldNotThrowIfFactoryAndRequireImplementationFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IMyType>(_ => new MyType());

        Action act = () => serviceCollection.VerifyService<IMyType>(ServiceLifetime.Singleton, true);

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyServiceShouldThrowNoFactoryAndIfRequireImplementationFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IMyType, MyType2>();

        Action act = () => serviceCollection.VerifyService<IMyType>(ServiceLifetime.Singleton, true);

        act.Should().Throw<XunitException>();
    }

    [Fact]
    public void VerifyServiceNonGenericShouldNotThrowIfRegistered()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IMyType, MyType2>(_ => new MyType2());
        
        Action act = () => serviceCollection.VerifyService(typeof(IMyType), ServiceLifetime.Singleton, true);

        act.Should().NotThrow();
    }

    private interface IMyType
    {
    }

    private class MyType : IMyType
    {
    }

    private class MyType2 : IMyType
    {
    }
}
