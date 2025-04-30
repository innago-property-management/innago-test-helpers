namespace Innago.Shared.ServiceTesting.TestHelpers;

using System;

using AutoFixture;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;

/// <summary>
///     ServiceTestBaseBase.
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
/// <code>
/// public class AuthorQueryServiceTests : ServiceTestBase&lt;Program, TestDatabaseContextFactory, DemoDbContext>
/// </code>
/// </example>
[PublicAPI]
public abstract class ServiceTestBaseBase<TProgram, TDbContextFactory, TDbContext> : IDisposable
    where TProgram : class
    where TDbContextFactory : TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServiceTestBaseBase{TProgram,TDbContextFactory,TDbContext}" /> class.
    /// </summary>
    /// <param name="serviceTestFixture">
    ///     The service test fixture.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     serviceTestFixture is null.
    /// </exception>
    protected ServiceTestBaseBase(ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext> serviceTestFixture)
    {
        this.ServiceTestFixture = serviceTestFixture ?? throw new ArgumentNullException(nameof(serviceTestFixture));
        this.Fixture = new Fixture();
    }

    /// <summary>
    ///     <see cref="IDisposable.Dispose" />.
    /// </summary>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Gets the ServiceTestFixture.
    /// </summary>
    protected internal ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext> ServiceTestFixture { get; }

    /// <summary>
    ///     Gets the Fixture.
    /// </summary>
    protected Fixture Fixture { get; }

    /// <summary>
    ///     Disposes the service test fixture.
    /// </summary>
    /// <param name="disposing">
    ///     A value indicating whether the object is disposing.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        this.ServiceTestFixture.Dispose();
    }

    /// <summary>
    ///     Finalizes an instance of the <see cref="ServiceTestBaseBase{TProgram,TDbContextFactory,TDbContext}" /> class.
    /// </summary>
    ~ServiceTestBaseBase()
    {
        this.Dispose(false);
    }
}