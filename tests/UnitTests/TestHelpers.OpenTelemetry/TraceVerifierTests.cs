namespace UnitTests.TestHelpers.OpenTelemetry;

using System.Diagnostics;

using AwesomeAssertions;

using global::OpenTelemetry.Trace;

using Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry;

using Xunit;

[UnitTest(nameof(TraceVerifier))]
public class TraceVerifierTests
{
    [Fact]
    public void ItShouldBeDisposable()
    {
        typeof(TraceVerifier).Should().Implement<IDisposable>();
    }

    [Fact]
    public void VerifyActivityShouldFindTrace()
    {
        using var verifier = new TraceVerifier();
        Tracer tracer = verifier.Tracer;
        var name = Guid.NewGuid().ToString("N");

        MyTraceable.SomeMethod(tracer, name);

        Func<Activity, bool> activityMatcher = activity => activity.OperationName == name;

        // ReSharper disable once AccessToDisposedClosure
        Action act = () => verifier.VerifyActivity(activity => activityMatcher(activity));

        act.Should().NotThrow();
    }
}

internal static class MyTraceable
{
    public static void SomeMethod(Tracer tracer, string name)
    {
        using TelemetrySpan _ = tracer.StartActiveSpan(name);
    }
}
