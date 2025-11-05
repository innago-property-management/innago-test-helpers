### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyParameterAttribute\<TAttribute\>\(Expression\<Func\<object\>\>, string\) Method

Verifies that an attribute of type [TAttribute](VerifyParameterAttribute_TAttribute_(Expression_Func_object__,string).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameterAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)\.TAttribute') is applied to the parameter\.

```csharp
public static System.Collections.Generic.IEnumerable<TAttribute> VerifyParameterAttribute<TAttribute>(System.Linq.Expressions.Expression<System.Func<object?>> expression, string parameterName)
    where TAttribute : System.Attribute;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).TAttribute'></a>

`TAttribute`

The type of the attribute\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The method expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).parameterName'></a>

`parameterName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The parameter name\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TAttribute](VerifyParameterAttribute_TAttribute_(Expression_Func_object__,string).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameterAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)\.TAttribute')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') of [TAttribute](VerifyParameterAttribute_TAttribute_(Expression_Func_object__,string).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__,string).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameterAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)\.TAttribute')\.

### Example

```csharp
MethodChecker.VerifyParameterAttribute<MyAttribute>(() => d.GetFullName(default), "lastName");
```