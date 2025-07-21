### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyMethod\<TReturn\>\(Expression\<Func\<object\>\>\) Method

Verifies a method's parameters and return type\.

```csharp
public static System.Reflection.MethodInfo VerifyMethod<TReturn>(System.Linq.Expressions.Expression<System.Func<object?>> expression);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethod_TReturn_(System.Linq.Expressions.Expression_System.Func_object__).TReturn'></a>

`TReturn`

The expected return type of the method\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethod_TReturn_(System.Linq.Expressions.Expression_System.Func_object__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

An expression representing the method\.

#### Returns
[System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo')  
The [System\.Reflection\.MethodInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo 'System\.Reflection\.MethodInfo') of the method so that further tests can be done\.

### Example

```csharp
const string? firstName = default;
const string? lastName = default;
MethodChecker.VerifyMethod<string>(() => d.GetFullName(firstName, lastName));
```