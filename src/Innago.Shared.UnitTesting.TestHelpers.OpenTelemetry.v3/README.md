# Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry #

Allows you to verify tracing calls.

## Usage ##

```c#
using var verifier = new TraceVerifier(); // disposable

// get the tracer
Tracer tracer = verifier.Tracer;

// call your code
var name = Guid.NewGuid().ToString("N");
MyTraceable.SomeMethod(tracer, name);

// define a matcher to verify the trace you expect
Func<Activity, bool> activityMatcher = activity => activity.OperationName == name;

// verify it
verifier.VerifyActivity(activity => activityMatcher(activity));
```