### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers').[TestDatabaseContextFactoryBase&lt;TContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>')

## TestDatabaseContextFactoryBase\<TContext\>\.MakeContext\(DbContextOptions\<TContext\>\) Method

Used by [CreateDbContext\(\)](CreateDbContext().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.CreateDbContext\(\)') to create a new instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\.

```csharp
protected abstract TContext MakeContext(Microsoft.EntityFrameworkCore.DbContextOptions<TContext> options);
```
#### Parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.MakeContext(Microsoft.EntityFrameworkCore.DbContextOptions_TContext_).options'></a>

`options` [Microsoft\.EntityFrameworkCore\.DbContextOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions-1 'Microsoft\.EntityFrameworkCore\.DbContextOptions\`1')[TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions-1 'Microsoft\.EntityFrameworkCore\.DbContextOptions\`1')

#### Returns
[TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')  
An instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\.

### Remarks
This method needs to call the constructor of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext') with the [options](MakeContext(DbContextOptions_TContext_).md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.MakeContext(Microsoft.EntityFrameworkCore.DbContextOptions_TContext_).options 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.MakeContext\(Microsoft\.EntityFrameworkCore\.DbContextOptions\<TContext\>\)\.options') parameter\.