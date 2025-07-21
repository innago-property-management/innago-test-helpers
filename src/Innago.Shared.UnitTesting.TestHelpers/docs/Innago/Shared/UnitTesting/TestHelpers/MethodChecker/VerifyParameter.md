### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[MethodChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker')

## MethodChecker\.VerifyParameter Method

| Overloads | |
| :--- | :--- |
| [VerifyParameter\(Expression&lt;Func&lt;object&gt;&gt;, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)') | Verifies the existence of a parameter\. |
| [VerifyParameter\(Expression&lt;Func&lt;object&gt;&gt;, Type, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, System\.Type, string\)') | This is the same as [VerifyParameter&lt;TParameter&gt;\(Expression&lt;Func&lt;object&gt;&gt;, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)') |
| [VerifyParameter&lt;TParameter&gt;\(Expression&lt;Func&lt;object&gt;&gt;, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)') | Verifies the existence of a parameter with the specified type\. Also checks the [name](index.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string).name 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)\.name')\. |

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,string)'></a>

## MethodChecker\.VerifyParameter\(Expression\<Func\<object\>\>, string\) Method

Verifies the existence of a parameter\.

```csharp
public static System.Reflection.ParameterInfo? VerifyParameter(System.Linq.Expressions.Expression<System.Func<object?>> expression, string parameterName);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,string).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The method call expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,string).parameterName'></a>

`parameterName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the parameter\.

#### Returns
[System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')  
The [System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')\.

### Example

```csharp
MethodChecker.VerifyParameter(() => new Dummy().GetFullName(default), "foo");
```

### Remarks
Use the [VerifyParameter\(Expression&lt;Func&lt;object&gt;&gt;, Type, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, System\.Type, string\)') overload\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string)'></a>

## MethodChecker\.VerifyParameter\(Expression\<Func\<object\>\>, Type, string\) Method

This is the same as [VerifyParameter&lt;TParameter&gt;\(Expression&lt;Func&lt;object&gt;&gt;, string\)](VerifyParameter.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string) 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)')

```csharp
public static System.Reflection.ParameterInfo? VerifyParameter(System.Linq.Expressions.Expression<System.Func<object?>> expression, System.Type parameterType, string? name=null);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The method expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string).parameterType'></a>

`parameterType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The type of the parameter\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter(System.Linq.Expressions.Expression_System.Func_object__,System.Type,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name\.

#### Returns
[System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')  
The [System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')\.

### Example

```csharp
const string parameterName = "lastName";
const string? lastName = default;
Type parameterType = typeof(string);
MethodChecker.VerifyParameter(
    () => new Dummy().GetFullName(lastName),
    parameterType,
    parameterName);
```

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string)'></a>

## MethodChecker\.VerifyParameter\<TParameter\>\(Expression\<Func\<object\>\>, string\) Method

Verifies the existence of a parameter with the specified type\.
Also checks the [name](index.md#Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string).name 'Innago\.Shared\.UnitTesting\.TestHelpers\.MethodChecker\.VerifyParameter\<TParameter\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<object\>\>, string\)\.name')\.

```csharp
public static System.Reflection.ParameterInfo? VerifyParameter<TParameter>(System.Linq.Expressions.Expression<System.Func<object?>> expression, string name);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string).TParameter'></a>

`TParameter`

The type of the parameter\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The method call expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.MethodChecker.VerifyParameter_TParameter_(System.Linq.Expressions.Expression_System.Func_object__,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The parameter name\.

#### Returns
[System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')  
The [System\.Reflection\.ParameterInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.parameterinfo 'System\.Reflection\.ParameterInfo')\.

### Example

```csharp
MethodChecker.VerifyParameter<string>(
    () => new Dummy().GetFullName(default),
    "lastName");
```