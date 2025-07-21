### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckRange\<TValue\>\(Expression\<Func\<object\>\>, TValue, TValue\) Method

Checks that a [System\.ComponentModel\.DataAnnotations\.RangeAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.rangeattribute 'System\.ComponentModel\.DataAnnotations\.RangeAttribute') with the correct values is present\.

```csharp
public static void CheckRange<TValue>(System.Linq.Expressions.Expression<System.Func<object?>> expression, TValue minValue, TValue maxValue);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).TValue'></a>

`TValue`

The value type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The property expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).minValue'></a>

`minValue` [TValue](CheckRange_TValue_(Expression_Func_object__,TValue,TValue).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).TValue 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckRange\<TValue\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, TValue, TValue\)\.TValue')

The min value\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).maxValue'></a>

`maxValue` [TValue](CheckRange_TValue_(Expression_Func_object__,TValue,TValue).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).TValue 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckRange\<TValue\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, TValue, TValue\)\.TValue')

The max value\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
[expression](CheckRange_TValue_(Expression_Func_object__,TValue,TValue).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckRange_TValue_(System.Linq.Expressions.Expression_System.Func_object__,TValue,TValue).expression 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckRange\<TValue\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, TValue, TValue\)\.expression') is not a member expression\.

### Example

```csharp
PropertyChecker.CheckRange(() => target.IntPropWithRange, 1, 10);
```