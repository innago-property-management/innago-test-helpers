### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckMaxLength\(Expression\<Func\<object\>\>, int\) Method

Verifies that a [System\.ComponentModel\.DataAnnotations\.MaxLengthAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.maxlengthattribute 'System\.ComponentModel\.DataAnnotations\.MaxLengthAttribute') with the correct [maxLength](CheckMaxLength(Expression_Func_object__,int).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckMaxLength(System.Linq.Expressions.Expression_System.Func_object__,int).maxLength 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckMaxLength\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, int\)\.maxLength') is on the property\.

```csharp
public static void CheckMaxLength(System.Linq.Expressions.Expression<System.Func<object?>> expression, int maxLength);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckMaxLength(System.Linq.Expressions.Expression_System.Func_object__,int).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

An expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckMaxLength(System.Linq.Expressions.Expression_System.Func_object__,int).maxLength'></a>

`maxLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The max length\.

### Example

```csharp
ISomeInterface i = null!;
PropertyChecker.CheckMaxLength(() => i.StringProperty, 100)
```