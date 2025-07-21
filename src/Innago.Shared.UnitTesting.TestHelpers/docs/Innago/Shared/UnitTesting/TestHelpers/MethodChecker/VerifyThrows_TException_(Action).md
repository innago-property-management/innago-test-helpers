### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyThrows\<TException\>\(Action\) Method

A helper to replace

```csharp
Action act = () => { /* ... */ });
act.Should.Throw<TException>();
```

```csharp
public static AwesomeAssertions.Specialized.ExceptionAssertions<TException>? VerifyThrows<TException>(System.Action action)
    where TException : System.Exception;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrows_TException_(System.Action).TException'></a>

`TException`

The expected exception type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrows_TException_(System.Action).action'></a>

`action` [System\.Action](https://learn.microsoft.com/en-us/dotnet/api/system.action 'System\.Action')

The method call expression\.

#### Returns
[AwesomeAssertions\.Specialized\.ExceptionAssertions&lt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1')[TException](VerifyThrows_TException_(Action).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrows_TException_(System.Action).TException 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyThrows\<TException\>\(System\.Action\)\.TException')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1')  
The [AwesomeAssertions\.Specialized\.ExceptionAssertions&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1') so that additional tests can be made\.

### Example

```csharp
MethodChecker.VerifyThrows<NotImplementedException>(() => throw new NotImplementedException());
```