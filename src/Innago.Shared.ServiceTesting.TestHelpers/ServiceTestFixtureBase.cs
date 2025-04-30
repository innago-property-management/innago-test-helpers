namespace Innago.Shared.ServiceTesting.TestHelpers;

using System;
using System.Net.Http;

using JetBrains.Annotations;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

/// <summary>
///     ServiceTestFixtureBase.
/// </summary>
/// <typeparam name="TProgram">
///     The type of the program.
/// </typeparam>
/// <typeparam name="TDbContextFactory">
///     The type of the database context factory.
/// </typeparam>
/// <typeparam name="TDbContext">
///     The type of the database context.
/// </typeparam>
/// <example>
///     <code>
/// public sealed class ServiceTestFixture&lt;TProgram, TDbContextFactory, TDbContext> : ServiceTestFixtureBase&lt;TProgram, TDbContextFactory, TDbContext>
///    where TProgram : class
///    where TDbContextFactory : TestDatabaseContextFactoryBase&lt;TDbContext>, new()
///    where TDbContext : DbContext
/// {
///   protected override void ConfigureServices(IServiceCollection services)
///   {
///     services.AddTransient&lt;IAuthorQueryService, AuthorQueryService>();
///     services.AddTransient&lt;IAuthorMutationService, AuthorMutationService>();
///     services.AddTransient&lt;IBookQueryService, BookQueryService>();
///   }
/// }
/// </code>
/// </example>
[PublicAPI]
public abstract class ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext> : IDisposable
    where TProgram : class
    // where TServiceImplementation : class, TServiceInterface
    // where TServiceInterface : class
    where TDbContextFactory : TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServiceTestFixtureBase{TProgram,TDbContextFactory,TDbContext}" />
    ///     class.
    /// </summary>
    protected ServiceTestFixtureBase()
    {
        this.Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        this.DatabaseContextFactory = new TDbContextFactory();

        this.WebApplicationFactory = new WebApplicationFactory<TProgram>();

        this.WebApplicationFactory = this.WebApplicationFactory.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment(Environments.Development);

            builder.ConfigureAppConfiguration((_, configurationBuilder) => { configurationBuilder.AddConfiguration(this.Configuration); });

            builder.ConfigureServices(this.ConfigureTestServices);
        });

        this.HttpClient = this.WebApplicationFactory.CreateClient();

        this.Services = this.WebApplicationFactory.Services;
    }

    /// <summary>
    ///     Finalizes an instance of the <see cref="ServiceTestFixtureBase{TProgram,TDbContextFactory,TDbContext}" /> class.
    /// </summary>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Gets the database context factory.
    /// </summary>
    public TDbContextFactory DatabaseContextFactory { get; }

    /// <summary>
    ///     Gets the configuration.
    /// </summary>
    protected internal IConfiguration Configuration { get; }

    /// <summary>
    ///     Gets the HTTP client.
    /// </summary>
    protected internal HttpClient HttpClient { get; protected set; }

    /// <summary>
    ///     Gets the service provider for retrieving service instances.
    /// </summary>
    protected IServiceProvider Services { get; }

    /// <summary>
    ///     Provides a factory for creating instances of the WebApplication under test.
    /// </summary>
    protected WebApplicationFactory<TProgram> WebApplicationFactory { get; }

    /// <summary>
    ///     Gets a service.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the service.
    /// </typeparam>
    /// <returns>
    ///     The service.
    /// </returns>
    public T GetService<T>()
    {
        return ActivatorUtilities.GetServiceOrCreateInstance<T>(this.Services);
    }

    /// <summary>
    ///     Configures the services.
    /// </summary>
    /// <param name="services">
    ///     The services.
    /// </param>
    /// <remarks>
    ///     Use this method to specify additional service configuration needed for your tests.
    ///     This method runs AFTER the internal service configurations in this class are run.
    /// </remarks>
    protected internal abstract void ConfigureServices(IServiceCollection services);

    /// <summary>
    ///     Disposes.
    /// </summary>
    /// <param name="disposing">
    ///     If set to <c>true</c> [disposing].
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
    }

    internal void ConfigureTestServices(IServiceCollection services)
    {
        services.AddEntityFrameworkInMemoryDatabase();

        services.Replace(ServiceDescriptor.Singleton<IDbContextFactory<TDbContext>>(this.DatabaseContextFactory));

        services.AddTransient(_ => this.HttpClient);
        this.ConfigureServices(services);
    }
}