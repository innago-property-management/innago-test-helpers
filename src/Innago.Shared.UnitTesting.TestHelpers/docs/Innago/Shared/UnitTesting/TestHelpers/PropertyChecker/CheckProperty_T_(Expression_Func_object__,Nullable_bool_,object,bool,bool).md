### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckProperty\<T\>\(Expression\<Func\<object\>\>, Nullable\<bool\>, object, bool, bool\) Method

Checks that a property has the correct characteristics: read/write, return type, default value\.

```csharp
public static System.Reflection.PropertyInfo CheckProperty<T>(System.Linq.Expressions.Expression<System.Func<object?>> expression, System.Nullable<bool> readOnly=null, object? expectedDefaultValue=null, bool testDefaultEquivalence=false, bool skipDefaultValueCheck=false);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).T'></a>

`T`

The EXPECTED type of the property\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The property access expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).readOnly'></a>

`readOnly` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

If `true`, then the property is not writable\. Default is that properties are read\-write\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).expectedDefaultValue'></a>

`expectedDefaultValue` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The expected value when the property is not explicitly set\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).testDefaultEquivalence'></a>

`testDefaultEquivalence` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Set to true if testing equivalence is needed \(edge case\)\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckProperty_T_(System.Linq.Expressions.Expression_System.Func_object__,System.Nullable_bool_,object,bool,bool).skipDefaultValueCheck'></a>

`skipDefaultValueCheck` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Set to true to skip default value check\. Useful for timestamps, GUIDs\.

#### Returns
[System\.Reflection\.PropertyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo 'System\.Reflection\.PropertyInfo')  
The [System\.Reflection\.PropertyInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.propertyinfo 'System\.Reflection\.PropertyInfo') of the matching property so that further testing can be done\.

### Example

```csharp
var t = new SomeType();
PropertyInfo property = PropertyChecker.CheckProperty<bool>(() => t.BoolProp);
```

### Remarks
Default value checks require an instance\.