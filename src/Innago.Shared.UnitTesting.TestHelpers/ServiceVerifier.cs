namespace Innago.Shared.UnitTesting.TestHelpers;

using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using JetBrains.Annotations;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Verifies that a service is registered.
/// </summary>
[PublicAPI]
public static class ServiceVerifier
{
    /// <summary>
    ///     Verifies that a service is registered as <see cref="ServiceLifetime.Transient"/>.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <typeparam name="TService">
    ///     The service type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService&lt;IMyType>();
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
        this IServiceCollection serviceCollection) where TService : class
    {
        return serviceCollection.VerifyService<TService>(ServiceLifetime.Transient, false);
    }

    /// <summary>
    ///     Verifies that a service is registered.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <param name="serviceLifetime">
    ///     The <see cref="ServiceLifetime"/>.
    /// </param>
    /// <typeparam name="TService">
    ///     The service type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService&lt;IMyType>(ServiceLifetime.Scoped);
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
        this IServiceCollection serviceCollection,
        ServiceLifetime serviceLifetime) where TService : class
    {
        return serviceCollection.VerifyService<TService>(serviceLifetime, false);
    }

    /// <summary>
    ///     Verifies that a service is registered.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <param name="serviceLifetime">
    ///     The <see cref="ServiceLifetime"/>.
    /// </param>
    /// <param name="requireImplementationFactory">
    ///     If true, the service must have an <see cref="ServiceDescriptor.ImplementationFactory"/>.
    /// </param>
    /// <typeparam name="TService">
    ///     The service type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService&lt;IMyType&gt;(ServiceLifetime.Singleton, true);
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
        this IServiceCollection serviceCollection,
        ServiceLifetime serviceLifetime,
        bool requireImplementationFactory) where TService : class
    {
        return serviceCollection.VerifyService(typeof(TService), serviceLifetime, requireImplementationFactory);
    }

    /// <summary>
    ///     Verifies that a service is registered.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <param name="serviceType">
    ///     The service type.
    /// </param>
    /// <param name="serviceLifetime">
    ///     The <see cref="ServiceLifetime"/>.
    /// </param>
    /// <param name="requireImplementationFactory">
    ///     If true, the service must have an <see cref="ServiceDescriptor.ImplementationFactory"/>.
    /// </param>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService(typeof(IMyType), ServiceLifetime.Singleton, true);
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService(
        this IServiceCollection serviceCollection,
        Type serviceType,
        ServiceLifetime? serviceLifetime = null,
        bool requireImplementationFactory = false)
    {
        IEnumerable<ServiceDescriptor> serviceDescriptors = serviceCollection.Where(descriptor =>
            descriptor.ServiceType == serviceType &&
            (serviceLifetime is null || descriptor.Lifetime == serviceLifetime) &&
            (!requireImplementationFactory || descriptor.ImplementationFactory is not null)).ToList();

        serviceDescriptors.Should().NotBeEmpty();

        return serviceDescriptors;
    }

    /// <summary>
    ///     Verifies that a service is registered as <see cref="ServiceLifetime.Transient"/>.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <typeparam name="TService">
    ///     The service type.
    /// </typeparam>
    /// <typeparam name="TImplementation">
    ///     The implementation type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService&lt;IMyType, MyType&gt;();
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService<TService, TImplementation>(
        this IServiceCollection serviceCollection) where TService : class
    {
        return serviceCollection.VerifyService<TService, TImplementation>(ServiceLifetime.Transient);
    }

    /// <summary>
    ///     Verifies that a service is registered.
    /// </summary>
    /// <param name="serviceCollection">
    ///     The <see cref="IServiceCollection"/>.
    /// </param>
    /// <param name="serviceLifetime">
    ///     The <see cref="ServiceLifetime"/>.
    /// </param>
    /// <typeparam name="TService">
    ///     The service type.
    /// </typeparam>
    /// <typeparam name="TImplementation">
    ///     The implementation type.
    /// </typeparam>
    /// <returns>
    ///     The <see cref="ServiceDescriptor"/>s for the service.
    /// </returns>
    /// <example>
    /// <code>
    /// serviceCollection.VerifyService&lt;IMyType, MyType&gt;(expectedServiceLifetime);
    /// </code>
    /// </example>
    public static IEnumerable<ServiceDescriptor> VerifyService<TService, TImplementation>(
        this IServiceCollection serviceCollection,
        ServiceLifetime serviceLifetime) where TService : class
    {
        IEnumerable<ServiceDescriptor> serviceDescriptors =
            serviceCollection.VerifyService<TService>(serviceLifetime)
                .Where(descriptor => descriptor.ImplementationType == typeof(TImplementation))
                .ToList();

        serviceDescriptors.Should().NotBeEmpty();

        return serviceDescriptors;
    }
}