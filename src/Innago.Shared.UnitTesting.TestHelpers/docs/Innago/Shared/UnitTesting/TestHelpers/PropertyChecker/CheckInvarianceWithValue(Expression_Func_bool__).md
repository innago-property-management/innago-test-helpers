### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckInvarianceWithValue\(Expression\<Func\<bool\>\>\) Method

Checks a property for invariance \(the value gotten is the same as the one set\)\.

```csharp
public static void CheckInvarianceWithValue(System.Linq.Expressions.Expression<System.Func<bool>> expression);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvarianceWithValue(System.Linq.Expressions.Expression_System.Func_bool__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

An expression of the form 

```csharp
foo.bar == val
``` is expected, where bar is a
property\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
Thrown if the [expression](CheckInvarianceWithValue(Expression_Func_bool__).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvarianceWithValue(System.Linq.Expressions.Expression_System.Func_bool__).expression 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvarianceWithValue\(System\.Linq\.Expressions\.Expression\<System\.Func\<bool\>\>\)\.expression') is not a comparison\.

### Example

```csharp
Dummy target = new() { ReadWriteString = "a" };
PropertyChecker.CheckInvarianceWithValue(() => target.ReadWriteString == "b");
```

### Remarks
You should prefer the [CheckInvariance&lt;T&gt;\(Expression&lt;Func&lt;T&gt;&gt;, IEnumerable&lt;T&gt;\)](CheckInvariance_T_(Expression_Func_T__,IEnumerable_T_).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvariance\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T\>\>, System\.Collections\.Generic\.IEnumerable\<T\>\)') method\.
This syntax is borrowed from the simplified property setup in Moq\.