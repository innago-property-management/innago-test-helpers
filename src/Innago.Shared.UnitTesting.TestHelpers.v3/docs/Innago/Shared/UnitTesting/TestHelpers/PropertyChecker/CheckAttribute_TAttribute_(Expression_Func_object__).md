### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckAttribute\<TAttribute\>\(Expression\<Func\<object\>\>\) Method

Checks that an attribute exists on the property specified\.

```csharp
public static TAttribute CheckAttribute<TAttribute>(System.Linq.Expressions.Expression<System.Func<object?>> expression)
    where TAttribute : System.Attribute;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).TAttribute'></a>

`TAttribute`

The attribute type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

An [System\.Linq\.Expressions\.Expression&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1') that represents the property\.
Example, 

```csharp
PropertyChecker.CheckAttribute<MyAttribute>(() => someObject.someProperty);
```

#### Returns
[TAttribute](CheckAttribute_TAttribute_(Expression_Func_object__).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)\.TAttribute')  
The attribute, so that other tests can be done on it if desired\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown if the [expression](CheckAttribute_TAttribute_(Expression_Func_object__).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).expression 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)\.expression') is not a property\.

### Example

```csharp
ISomeInterface? someInterface = null;
Action act = () => PropertyChecker.CheckAttribute<RequiredAttribute>(() => someInterface!.Name);
```