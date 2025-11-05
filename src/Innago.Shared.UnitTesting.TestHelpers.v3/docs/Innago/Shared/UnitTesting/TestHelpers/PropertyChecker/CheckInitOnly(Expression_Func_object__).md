### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckInitOnly\(Expression\<Func\<object\>\>\) Method

Verifies that a property is init\-only\.

```csharp
public static void CheckInitOnly(System.Linq.Expressions.Expression<System.Func<object?>> expression);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInitOnly(System.Linq.Expressions.Expression_System.Func_object__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The member expression\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The expression is not a member expression\.

### Example

```csharp
PropertyChecker.CheckInitOnly(() => target.ReadInitNullableString);
```