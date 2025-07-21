### [Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry')

## TraceVerifier Class

The trace verifier\.

```csharp
public sealed class TraceVerifier : System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; TraceVerifier

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

| Constructors | |
| :--- | :--- |
| [TraceVerifier\(\)](TraceVerifier().md 'Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry\.TraceVerifier\.TraceVerifier\(\)') | Initializes a new instance of the [TraceVerifier](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry\.TraceVerifier') class\. |

| Properties | |
| :--- | :--- |
| [Tracer](Tracer.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry\.TraceVerifier\.Tracer') | Gets the tracer\. |

| Methods | |
| :--- | :--- |
| [VerifyActivity\(Expression&lt;Func&lt;Activity,bool&gt;&gt;\)](VerifyActivity(Expression_Func_Activity,bool__).md 'Innago\.Shared\.UnitTesting\.TestHelpers\.OpenTelemetry\.TraceVerifier\.VerifyActivity\(System\.Linq\.Expressions\.Expression\<System\.Func\<System\.Diagnostics\.Activity,bool\>\>\)') | Verifies the activity\. |
