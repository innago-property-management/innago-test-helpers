namespace Innago.Shared.ServiceTesting.TestHelpers;

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     TestDatabaseContextFactoryBase.
/// </summary>
/// <typeparam name="TContext">
///     The type of the context.
/// </typeparam>
/// <example>
/// <code>
/// public class TestDatabaseContextFactory : TestDatabaseContextFactoryBase&lt;DemoDbContext>
/// {
///   protected override DemoDbContext MakeContext(DbContextOptions&lt;DemoDbContext> options)
///   {
///     return new DemoDbContext(options);
///   }
/// }
/// </code>
/// </example>
public abstract class TestDatabaseContextFactoryBase<TContext> : IDbContextFactory<TContext> where TContext : DbContext
{
    private const string DbName = "ServiceTests";
    internal IServiceProvider ServiceProvider { get; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="TestDatabaseContextFactoryBase{TContext}" /> class.
    /// </summary>
    protected TestDatabaseContextFactoryBase()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddEntityFrameworkInMemoryDatabase();
        this.ServiceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    ///     Creates a new instance of <typeparamref name="TContext"/>.
    /// </summary>
    /// <returns>
    ///     An instance of <typeparamref name="TContext"/>.
    /// </returns>
    /// <remarks>
    ///     Wires up an in-memory database for the context.
    /// </remarks>
    public TContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<TContext>();
        builder.UseInMemoryDatabase(TestDatabaseContextFactoryBase<TContext>.DbName);
        builder.UseInternalServiceProvider(this.ServiceProvider);
        TContext context = this.MakeContext(builder.Options);
        return context;
    }

    /// <inheritdoc />
    public Task<TContext> CreateDbContextAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(this.CreateDbContext());
    }

    /// <summary>
    ///     Used by <see cref="CreateDbContext"/> to create a new instance of <typeparamref name="TContext"/>.
    /// </summary>
    /// <param name="options"></param>
    /// <returns>
    ///     An instance of <typeparamref name="TContext"/>.
    /// </returns>
    /// <remarks>
    ///     This method needs to call the constructor of <typeparamref name="TContext"/> with the <paramref name="options"/> parameter.
    /// </remarks>
    protected abstract TContext MakeContext(DbContextOptions<TContext> options);
}
