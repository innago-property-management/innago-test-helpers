### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyThrowsAsync\<TException\>\(Func\<Task\>\) Method

A helper to replace

```csharp
async act = () =>     { /* ... */ });
act.should.ThrowAsync<TException>();
```

```csharp
public static System.Threading.Tasks.Task<AwesomeAssertions.Specialized.ExceptionAssertions<TException>?> VerifyThrowsAsync<TException>(System.Func<System.Threading.Tasks.Task> action)
    where TException : System.Exception;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrowsAsync_TException_(System.Func_System.Threading.Tasks.Task_).TException'></a>

`TException`

The expected exception type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrowsAsync_TException_(System.Func_System.Threading.Tasks.Task_).action'></a>

`action` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

The async method call expression\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[AwesomeAssertions\.Specialized\.ExceptionAssertions&lt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1')[TException](VerifyThrowsAsync_TException_(Func_Task_).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyThrowsAsync_TException_(System.Func_System.Threading.Tasks.Task_).TException 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyThrowsAsync\<TException\>\(System\.Func\<System\.Threading\.Tasks\.Task\>\)\.TException')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The [AwesomeAssertions\.Specialized\.ExceptionAssertions&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/awesomeassertions.specialized.exceptionassertions-1 'AwesomeAssertions\.Specialized\.ExceptionAssertions\`1') so that additional tests can be made\.

### Example

```csharp
MethodChecker.VerifyThrowsAsync<NotImplementedException>(() =? throw new NotImplementedException());
```