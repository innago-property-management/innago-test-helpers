### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckRequired\(Expression\<Func\<object\>\>, bool\) Method

Verifies that a [System\.ComponentModel\.DataAnnotations\.RequiredAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute 'System\.ComponentModel\.DataAnnotations\.RequiredAttribute') is present on the property\.

```csharp
public static void CheckRequired(System.Linq.Expressions.Expression<System.Func<object?>> expression, bool allowEmptyStrings=false);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRequired(System.Linq.Expressions.Expression_System.Func_object__,bool).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The member expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRequired(System.Linq.Expressions.Expression_System.Func_object__,bool).allowEmptyStrings'></a>

`allowEmptyStrings` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool'), then allow empty strings\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The expression is not a member expression\.

### Example

```csharp
PropertyChecker.CheckRequired(() => target.RequiredStringAllowEmpty, true);
```