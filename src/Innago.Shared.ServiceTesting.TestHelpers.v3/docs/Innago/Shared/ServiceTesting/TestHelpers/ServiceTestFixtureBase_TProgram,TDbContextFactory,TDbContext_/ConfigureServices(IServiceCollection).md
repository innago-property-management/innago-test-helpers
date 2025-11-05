### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers').[ServiceTestFixtureBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>')

## ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\.ConfigureServices\(IServiceCollection\) Method

Configures the services\.

```csharp
protected internal abstract void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_.ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The services\.

### Remarks
Use this method to specify additional service configuration needed for your tests\.
This method runs AFTER the internal service configurations in this class are run\.