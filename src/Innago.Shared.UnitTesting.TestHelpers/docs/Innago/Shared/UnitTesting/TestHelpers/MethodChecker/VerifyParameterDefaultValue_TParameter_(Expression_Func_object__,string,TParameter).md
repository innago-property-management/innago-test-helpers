### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyParameterDefaultValue\<TParameter\>\(Expression\<Func\<object\>\>, string, TParameter\) Method

Verifies that the parameter has the expected default value\.

```csharp
public static System.Reflection.ParameterInfo VerifyParameterDefaultValue<TParameter>(System.Linq.Expressions.Expression<System.Func<object?>> expression, string name, TParameter expectedDefaultValue);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterDefaultValue_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string,TParameter).TParameter'></a>

`TParameter`

The type of the parameter\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterDefaultValue_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string,TParameter).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The [System\.Linq\.Expressions\.MethodCallExpression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.methodcallexpression 'System\.Linq\.Expressions\.MethodCallExpression')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterDefaultValue_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string,TParameter).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter to check\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterDefaultValue_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string,TParameter).expectedDefaultValue'></a>

`expectedDefaultValue` [TParameter](VerifyParameterDefaultValue_TParameter_(Expression_Func_object__,string,TParameter).md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameterDefaultValue_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string,TParameter).TParameter 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameterDefaultValue\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string, TParameter\)\.TParameter')

The expected default value\.

#### Returns
[System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')  
The [System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')\.

### Example

```csharp
Dummy d = null!;
const int expectedDefaultValue = 9999;
const string name = "b";

MethodChecker.VerifyParameterDefaultValue(
    () => d.MethodWithDefaultValuesForParameters(default!, default),
    name,
    expectedDefaultValue);
```