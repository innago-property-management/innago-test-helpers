namespace Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;

using FluentAssertions;

using global::OpenTelemetry.Trace;

using JetBrains.Annotations;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// The trace verifier.
/// </summary>
[PublicAPI]
public sealed class TraceVerifier : IDisposable
{
    private readonly IHost host;

    private readonly IList<Activity> activities;

    /// <summary>
    /// Gets the tracer.
    /// </summary>
    public Tracer Tracer => ActivatorUtilities.GetServiceOrCreateInstance<Tracer>(this.host.Services);

    /// <summary>
    /// Initializes a new instance of the <see cref="TraceVerifier"/> class.
    /// </summary>
    public TraceVerifier()
    {
        this.activities = new List<Activity>();
        
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder();

        var source = Guid.NewGuid().ToString("N");

        hostBuilder.ConfigureServices((_, serviceCollection) =>
        {
            serviceCollection.AddOpenTelemetry()
                .WithTracing(builder =>
                {
                    builder.AddSource(source);
                    builder.AddInMemoryExporter(this.activities);
                });

            serviceCollection.AddSingleton(TracerProvider.Default.GetTracer(source));
        });

        this.host = hostBuilder.Build();
        this.host.Start();
    }

    /// <summary>
    /// Verifies the activity.
    /// </summary>
    /// <param name="predicate">
    /// The predicate.
    /// </param>
    public void VerifyActivity(Expression<Func<Activity, bool>> predicate)
    {
        this.activities.Should().Contain(predicate);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        this.host.StopAsync().GetAwaiter().GetResult();
    }
}