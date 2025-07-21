### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers')

## ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\> Class

ServiceTestFixtureBase\.

```csharp
public abstract class ServiceTestFixtureBase<TProgram,TDbContextFactory,TDbContext> : System.IDisposable
    where TProgram : class
    where TDbContextFactory : Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.TProgram'></a>

`TProgram`

The type of the program\.

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.TDbContextFactory'></a>

`TDbContextFactory`

The type of the database context factory\.

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.TDbContext'></a>

`TDbContext`

The type of the database context\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

### Example

```csharp
public sealed class ServiceTestFixture<TProgram, TDbContextFactory, TDbContext> : ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext>
   where TProgram : class
   where TDbContextFactory : TestDatabaseContextFactoryBase<TDbContext>, new()
   where TDbContext : DbContext
{
  protected override void ConfigureServices(IServiceCollection services)
  {
    services.AddTransient<IAuthorQueryService, AuthorQueryService>();
    services.AddTransient<IAuthorMutationService, AuthorMutationService>();
    services.AddTransient<IBookQueryService, BookQueryService>();
  }
}
```

| Constructors | |
| :--- | :--- |
| [ServiceTestFixtureBase\(\)](ServiceTestFixtureBase().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.ServiceTestFixtureBase\(\)') | Initializes a new instance of the [ServiceTestFixtureBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>') class\. |

| Properties | |
| :--- | :--- |
| [Configuration](Configuration.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.Configuration') | Gets the configuration\. |
| [DatabaseContextFactory](DatabaseContextFactory.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.DatabaseContextFactory') | Gets the database context factory\. |
| [HttpClient](HttpClient.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.HttpClient') | Gets the HTTP client\. |
| [Services](Services.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.Services') | Gets the service provider for retrieving service instances\. |
| [WebApplicationFactory](WebApplicationFactory.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.WebApplicationFactory') | Provides a factory for creating instances of the WebApplication under test\. |

| Methods | |
| :--- | :--- |
| [ConfigureServices\(IServiceCollection\)](ConfigureServices(IServiceCollection).md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.ConfigureServices\(Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Configures the services\. |
| [Dispose\(\)](Dispose.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.Dispose() 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.Dispose\(\)') | Finalizes an instance of the [ServiceTestFixtureBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>') class\. |
| [Dispose\(bool\)](Dispose.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.Dispose(bool) 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.Dispose\(bool\)') | Disposes\. |
| [GetService&lt;T&gt;\(\)](GetService_T_().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.GetService\<T\>\(\)') | Gets a service\. |
