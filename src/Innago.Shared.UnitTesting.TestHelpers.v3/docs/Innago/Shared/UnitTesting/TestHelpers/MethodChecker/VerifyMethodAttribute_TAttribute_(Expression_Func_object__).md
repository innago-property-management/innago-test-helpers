### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyMethodAttribute\<TAttribute\>\(Expression\<Func\<object\>\>\) Method

Verifies that a method has an attribute\.

```csharp
public static System.Collections.Generic.IEnumerable<TAttribute> VerifyMethodAttribute<TAttribute>(System.Linq.Expressions.Expression<System.Func<object?>> expression)
    where TAttribute : System.Attribute;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethodAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).TAttribute'></a>

`TAttribute`

The attribute type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethodAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The method expression\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[TAttribute](VerifyMethodAttribute_TAttribute_(Expression_Func_object__).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethodAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyMethodAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)\.TAttribute')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
An [System\.Collections\.Generic\.IEnumerable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1') of [TAttribute](VerifyMethodAttribute_TAttribute_(Expression_Func_object__).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyMethodAttribute_TAttribute_(System.Linq.Expressions.Expression_System.Func_object__).TAttribute 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyMethodAttribute\<TAttribute\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>\)\.TAttribute')\.

### Example

```csharp
var d = new MyType();
MethodChecker.VerifyMethodAttribute<MyAttribute>(
    () => d.GetFullName(default));
```