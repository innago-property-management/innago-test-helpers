### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[PropertyChecker](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker')

## PropertyChecker\.CheckInvariance\<T\>\(Expression\<Func\<T\>\>, IEnumerable\<T\>\) Method

Checks a property for invariance \(the value gotten is the same as the one set\)\.

```csharp
public static void CheckInvariance<T>(System.Linq.Expressions.Expression<System.Func<T>> expression, System.Collections.Generic.IEnumerable<T>? values=null);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).T'></a>

`T`

The type of the value\(s\)\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[T](CheckInvariance_T_(Expression_Func_T__,IEnumerable_T_).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).T 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvariance\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T\>\>, System\.Collections\.Generic\.IEnumerable\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

A property/member expression\.

<a name='Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).values'></a>

`values` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](CheckInvariance_T_(Expression_Func_T__,IEnumerable_T_).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).T 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvariance\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T\>\>, System\.Collections\.Generic\.IEnumerable\<T\>\)\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The values to use for testing\.

### Example

```csharp
PropertyChecker.CheckInvariance(() => target.SomeProperty);
```

### Remarks
For built\-in value types, the [values](CheckInvariance_T_(Expression_Func_T__,IEnumerable_T_).md#Innago.Shared.UnitTesting.TestHelpers.PropertyChecker.CheckInvariance_T_(System.Linq.Expressions.Expression_System.Func_T__,System.Collections.Generic.IEnumerable_T_).values 'Innago\.Shared\.UnitTesting\.TestHelpers\.PropertyChecker\.CheckInvariance\<T\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<T\>\>, System\.Collections\.Generic\.IEnumerable\<T\>\)\.values') can be omitted if min, max, zero are acceptable\.
\<seealso cref="T:System\.Nullable\`1" /\> is supported\.
\<seealso cref="T:System\.Guid" /\> is supported\.
\<seealso cref="T:System\.String" /\> is tested with null, whitespace, aGUID, and a 100\-character\. Do not use this method if
truncation is important\.