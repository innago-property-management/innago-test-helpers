### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers')

## TestDatabaseContextFactoryBase\<TContext\> Class

TestDatabaseContextFactoryBase\.

```csharp
public abstract class TestDatabaseContextFactoryBase<TContext> : Microsoft.EntityFrameworkCore.IDbContextFactory<TContext>
    where TContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext'></a>

`TContext`

The type of the context\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; TestDatabaseContextFactoryBase\<TContext\>

Implements [Microsoft\.EntityFrameworkCore\.IDbContextFactory&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.idbcontextfactory-1 'Microsoft\.EntityFrameworkCore\.IDbContextFactory\`1')[TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.idbcontextfactory-1 'Microsoft\.EntityFrameworkCore\.IDbContextFactory\`1')

### Example

```csharp
public class TestDatabaseContextFactory : TestDatabaseContextFactoryBase<DemoDbContext>
{
  protected override DemoDbContext MakeContext(DbContextOptions<DemoDbContext> options)
  {
    return new DemoDbContext(options);
  }
}
```

| Constructors | |
| :--- | :--- |
| [TestDatabaseContextFactoryBase\(\)](TestDatabaseContextFactoryBase().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TestDatabaseContextFactoryBase\(\)') | Initializes a new instance of the [TestDatabaseContextFactoryBase&lt;TContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>') class\. |

| Methods | |
| :--- | :--- |
| [CreateDbContext\(\)](CreateDbContext().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.CreateDbContext\(\)') | Creates a new instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\. |
| [MakeContext\(DbContextOptions&lt;TContext&gt;\)](MakeContext(DbContextOptions_TContext_).md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.MakeContext\(Microsoft\.EntityFrameworkCore\.DbContextOptions\<TContext\>\)') | Used by [CreateDbContext\(\)](CreateDbContext().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.CreateDbContext\(\)') to create a new instance of [TContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase_TContext_.TContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.TestDatabaseContextFactoryBase\<TContext\>\.TContext')\. |
