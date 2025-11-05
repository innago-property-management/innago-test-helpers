### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers')

## ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\> Class

ServiceTestBaseBase\.

```csharp
public abstract class ServiceTestBaseBase<TProgram,TDbContextFactory,TDbContext> : System.IDisposable
    where TProgram : class
    where TDbContextFactory : Innago.Shared.ServiceTesting.TestHelpers.TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TProgram'></a>

`TProgram`

The type of the program\.

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TDbContextFactory'></a>

`TDbContextFactory`

The type of the database context factory\.

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TDbContext'></a>

`TDbContext`

The type of the database context\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

### Example

```csharp
public class AuthorQueryServiceTests : ServiceTestBase<Program, TestDatabaseContextFactory, DemoDbContext>
```

| Constructors | |
| :--- | :--- |
| [ServiceTestBaseBase\(ServiceTestFixtureBase&lt;TProgram,TDbContextFactory,TDbContext&gt;\)](ServiceTestBaseBase(ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_).md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.ServiceTestBaseBase\(Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\)') | Initializes a new instance of the [ServiceTestBaseBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>') class\. |

| Properties | |
| :--- | :--- |
| [Fixture](Fixture.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.Fixture') | Gets the Fixture\. |
| [ServiceTestFixture](ServiceTestFixture.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.ServiceTestFixture') | Gets the ServiceTestFixture\. |

| Methods | |
| :--- | :--- |
| [Dispose\(\)](Dispose.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.Dispose() 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.Dispose\(\)') | [System\.IDisposable\.Dispose](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable.dispose 'System\.IDisposable\.Dispose')\. |
| [Dispose\(bool\)](Dispose.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.Dispose(bool) 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.Dispose\(bool\)') | Disposes the service test fixture\. |
| [~ServiceTestBaseBase\(\)](~ServiceTestBaseBase().md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.~ServiceTestBaseBase\(\)') | Finalizes an instance of the [ServiceTestBaseBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>') class\. |
