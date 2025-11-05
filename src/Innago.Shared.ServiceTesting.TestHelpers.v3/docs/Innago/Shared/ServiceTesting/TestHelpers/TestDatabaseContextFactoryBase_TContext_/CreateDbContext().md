### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers').[TestDatabaseContextFactoryBase&lt;TContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>')

## TestDatabaseContextFactoryBase\<TContext\>\.CreateDbContext\(\) Method

Creates a new instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\.

```csharp
public TContext CreateDbContext();
```

Implements [CreateDbContext\(\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.idbcontextfactory-1.createdbcontext 'Microsoft\.EntityFrameworkCore\.IDbContextFactory\`1\.CreateDbContext')

#### Returns
[TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')  
An instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\.

### Remarks
Wires up an in\-memory database for the context\.