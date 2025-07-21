### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers')

## PropertyChecker Class

Helps verify property traits

```csharp
public static class PropertyChecker
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; PropertyChecker

| Methods | |
| :--- | :--- |
| [CheckAttribute&lt;TAttribute&gt;\(Expression&lt;Func&lt;object&gt;&gt;\)](CheckAttribute_TAttribute_(Expression_Func_object__).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)') | Checks that an attribute exists on the property specified\. |
| [CheckInitOnly\(Expression&lt;Func&lt;object&gt;&gt;\)](CheckInitOnly(Expression_Func_object__).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInitOnly\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)') | Verifies that a property is init\-only\. |
| [CheckInvariance&lt;T&gt;\(Expression&lt;Func&lt;T&gt;&gt;, IEnumerable&lt;T&gt;\)](CheckInvariance_T_(Expression_Func_T__,IEnumerable_T_).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvariance\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T\>\>, System\.Collections\.Generic\.IEnumerable\<T\>\)') | Checks a property for invariance \(the value gotten is the same as the one set\)\. |
| [CheckInvarianceWithValue\(Expression&lt;Func&lt;bool&gt;&gt;\)](CheckInvarianceWithValue(Expression_Func_bool__).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvarianceWithValue\(System\.Linq\.Expressions\.Expression\<System\.Func\<bool\>\>\)') | Checks a property for invariance \(the value gotten is the same as the one set\)\. |
| [CheckMaxLength\(Expression&lt;Func&lt;object&gt;&gt;, int\)](CheckMaxLength(Expression_Func_object__,int).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckMaxLength\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, int\)') | Verifies that a [System\.ComponentModel\.DataAnnotations\.MaxLengthAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.maxlengthattribute 'System\.ComponentModel\.DataAnnotations\.MaxLengthAttribute') with the correct [maxLength](CheckMaxLength(Expression_Func_object__,int).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckMaxLength(System.Linq.Expressions.Expression_System.Func_object__,int).maxLength 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckMaxLength\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, int\)\.maxLength') is on the property\. |
| [CheckProperty&lt;T&gt;\(Expression&lt;Func&lt;object&gt;&gt;, Nullable&lt;bool&gt;, object, bool, bool\)](CheckProperty_T_(Expression_Func_object__,Nullable_bool_,object,bool,bool).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckProperty\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, System\.Nullable\<bool\>, object, bool, bool\)') | Checks that a property has the correct characteristics: read/write, return type, default value\. |
| [CheckRange&lt;TValue&gt;\(Expression&lt;Func&lt;object&gt;&gt;, TValue, TValue\)](CheckRange_TValue_(Expression_Func_object__,TValue,TValue).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckRange\<TValue\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, TValue, TValue\)') | Checks that a [System\.ComponentModel\.DataAnnotations\.RangeAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.rangeattribute 'System\.ComponentModel\.DataAnnotations\.RangeAttribute') with the correct values is present\. |
| [CheckRequired\(Expression&lt;Func&lt;object&gt;&gt;, bool\)](CheckRequired(Expression_Func_object__,bool).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckRequired\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, bool\)') | Verifies that a [System\.ComponentModel\.DataAnnotations\.RequiredAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute 'System\.ComponentModel\.DataAnnotations\.RequiredAttribute') is present on the property\. |
