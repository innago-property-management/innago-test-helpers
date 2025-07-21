### [Innago\.Shared\.ServiceTesting\.TestHelpers](../index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers').[ServiceTestBaseBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>')

## ServiceTestBaseBase\(ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>\) Constructor

Initializes a new instance of the [ServiceTestBaseBase&lt;TProgram,TDbContextFactory,TDbContext&gt;](index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>') class\.

```csharp
protected ServiceTestBaseBase(Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase<TProgram,TDbContextFactory,TDbContext> serviceTestFixture);
```
#### Parameters

<a name='Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.ServiceTestBaseBase(Innago.Shared.ServiceTesting.TestHelpers.ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_).serviceTestFixture'></a>

`serviceTestFixture` [Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase&lt;](../ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_/index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>')[TProgram](index.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TProgram 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.TProgram')[,](../ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_/index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>')[TDbContextFactory](index.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TDbContextFactory 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.TDbContextFactory')[,](../ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_/index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>')[TDbContext](index.md#Innago.Shared.ServiceTesting.TestHelpers.ServiceTestBaseBase_TProgram,TDbContextFactory,TDbContext_.TDbContext 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestBaseBase\<TProgram,TDbContextFactory,TDbContext\>\.TDbContext')[&gt;](../ServiceTestFixtureBase_TProgram,TDbContextFactory,TDbContext_/index.md 'Innago\.Shared\.ServiceTesting\.TestHelpers\.ServiceTestFixtureBase\<TProgram,TDbContextFactory,TDbContext\>')

The service test fixture\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
serviceTestFixture is null\.