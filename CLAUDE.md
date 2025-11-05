# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

This repository contains test helper utilities for .NET 9.0 projects, published as six NuGet packages supporting both xUnit v2 and xUnit v3:

### xUnit v2 Packages (xunit 2.9.x)
- `Innago.Shared.UnitTesting.TestHelpers` - Core unit testing utilities
- `Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry` - OpenTelemetry testing utilities
- `Innago.Shared.ServiceTesting.TestHelpers` - Service/integration testing utilities

### xUnit v3 Packages (xunit.v3 3.1.x)
- `Innago.Shared.UnitTesting.TestHelpers.v3` - Core unit testing utilities
- `Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3` - OpenTelemetry testing utilities
- `Innago.Shared.ServiceTesting.TestHelpers.v3` - Service/integration testing utilities

The `.v3` packages share the same source code as their v2 counterparts but reference xUnit v3 instead of xUnit v2. They are built from wrapper projects that link to the original source files.

## Building and Testing

### Build all projects (v2 and v3)
```bash
dotnet build
```

### Build only v2 packages
```bash
dotnet build --filter "!*.v3"
```

### Build only v3 packages
```bash
dotnet build src/Innago.Shared.UnitTesting.TestHelpers.v3/Innago.Shared.UnitTesting.TestHelpers.v3.csproj
dotnet build src/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3.csproj
dotnet build src/Innago.Shared.ServiceTesting.TestHelpers.v3/Innago.Shared.ServiceTesting.TestHelpers.v3.csproj
```

### Run all tests
```bash
dotnet test tests/UnitTests/UnitTests.csproj
```

Note: Tests are currently built against v2 packages. The v3 packages share the same source code.

### Run a specific test
```bash
dotnet test tests/UnitTests/UnitTests.csproj --filter "FullyQualifiedName~ServiceVerifierTests.VerifyServiceShouldReturnServiceDescriptors"
```

### Create NuGet packages
```bash
dotnet pack
```

This builds all 6 packages (3 v2 + 3 v3). Packages are automatically generated on build when `GeneratePackageOnBuild` is true.

## Architecture

### Project Structure

The repository uses a dual-package approach to support both xUnit v2 and v3:

#### xUnit v2 Source Projects
- `src/Innago.Shared.UnitTesting.TestHelpers/` - Core test helpers (v2)
  - `ServiceVerifier.cs` - Verify DI service registration (type, lifetime, implementation)
  - `LogVerifier.cs` - Verify ILogger calls with Moq (level, message patterns, exceptions)
  - `PropertyChecker.cs` - Verify property characteristics (type, read/write, attributes, invariance)
  - `MethodChecker.cs` - Verify method signatures, parameters, exceptions, and mock usage

- `src/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry/` - OpenTelemetry helpers (v2)
  - `TraceVerifier.cs` - In-memory trace collection and verification for Activity-based tests

- `src/Innago.Shared.ServiceTesting.TestHelpers/` - Integration test base classes (v2)
  - `ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext>` - Base fixture for service tests with WebApplicationFactory and in-memory database
  - `ServiceTestBaseBase<TProgram, TDbContextFactory, TDbContext>` - Base test class that uses ServiceTestFixtureBase
  - `TestDatabaseContextFactoryBase<TContext>` - Factory for creating in-memory EF Core DbContext instances

#### xUnit v3 Wrapper Projects
- `src/Innago.Shared.UnitTesting.TestHelpers.v3/` - Links to UnitTesting.TestHelpers source, references xUnit v3
- `src/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3/` - Links to OpenTelemetry source, references xUnit v3
- `src/Innago.Shared.ServiceTesting.TestHelpers.v3/` - Links to ServiceTesting source, references xUnit v3

The v3 projects use `<Compile Include="..\{OriginalProject}\**\*.cs" />` to include source files from their v2 counterparts, ensuring code consistency while targeting different xUnit versions.

### Key Design Patterns

**ServiceVerifier Pattern**: Extension methods on `IServiceCollection` to verify service registration in unit tests. Validates service type, implementation type, and lifetime (Transient/Scoped/Singleton).

**LogVerifier Pattern**: Uses Moq to verify `ILogger<T>` calls. Supports string matching options (Equals, StartsWith, EndsWith, Contains, RegEx) and exception verification.

**PropertyChecker Pattern**: Expression-based property verification using `Expression<Func<object?>>`. Automatically generates test values for built-in types and supports attribute verification (Required, MaxLength, Range).

**MethodChecker Pattern**: Expression-based method verification including parameter types/defaults, return types, attributes, and Moq integration for verifying method calls on mocked dependencies.

**TraceVerifier Pattern**: Uses OpenTelemetry InMemoryExporter to collect Activity traces in tests. Provides IHost-based setup with automatic tracer configuration.

**ServiceTestFixtureBase Pattern**: xUnit collection fixture pattern for integration tests. Sets up WebApplicationFactory with in-memory database, configurable via abstract `ConfigureServices` method. Uses `IClassFixture<T>` or `ICollectionFixture<T>` pattern.

## CI/CD

The repository uses GitHub Actions with the Oui-DELIVER reusable workflow pattern:

- `.github/workflows/build-publish.yml` - Builds, tests, and publishes NuGet packages on push to main or tags
  - Runs tests from `tests/UnitTests/UnitTests.csproj`
  - Publishes signed NuGet packages with attestation
  - Minimum code coverage: 0% (configured via `minimumCoverage` parameter)

- `.github/workflows/merge-checks.yml` - Runs license compliance checks on PRs
  - Validates package licenses against allowed list
  - Configuration: `.github/actions/check-licenses-action/allowed-licenses.json` and `ignored-packages.json`

## Code Quality

All projects enforce:
- **Nullable reference types** enabled
- **Warnings as errors** in Release mode
- **Code analyzers**: SonarAnalyzer, BannedApiAnalyzers, PublicApiAnalyzers
- **Documentation**: XML documentation files required, auto-generated via DefaultDocumentation (disabled in CI)
- **Public API tracking**: `PublicAPI.Shipped.txt` and `PublicAPI.Unshipped.txt` files track API surface changes

## Testing Conventions

- Use **xUnit** as the test framework
- Use **AwesomeAssertions** for fluent assertions (not FluentAssertions)
- Use **Moq** for mocking
- Mark tests with `[UnitTest(nameof(ClassUnderTest))]` attribute from xunit.categories
- Test classes should be in namespace matching the library: `UnitTests.TestHelpers`
- All test helpers use expression-based APIs for type safety and refactorability

### Example Test Pattern
```csharp
[UnitTest(nameof(ServiceVerifier))]
public class ServiceVerifierTests
{
    [Fact]
    public void VerifyServiceShouldReturnServiceDescriptors()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<IMyType, MyType>();

        IEnumerable<ServiceDescriptor> actual = serviceCollection.VerifyService<IMyType>();

        actual.Should().NotBeEmpty();
    }
}
```

## Dependencies

### Common Dependencies (both v2 and v3)
- **AwesomeAssertions** 9.3.0
- **Moq** 4.20.72
- **Microsoft.Extensions.*** packages at 9.0.10
- **OpenTelemetry** 1.13.1 (OpenTelemetry packages)
- **Microsoft.AspNetCore.Mvc.Testing** 9.0.10 (ServiceTesting packages)
- **Microsoft.EntityFrameworkCore.InMemory** 9.0.10 (ServiceTesting packages)

### xUnit v2 Packages
- **xunit** 2.9.3
- **xunit.categories** (where applicable)

### xUnit v3 Packages
- **xunit.v3** 3.1.0
- **xunit.categories** 3.0.1 (where applicable)

The primary difference between v2 and v3 packages is the xUnit dependency version. All other dependencies remain the same.

## Target Framework

All projects target **.NET 9.0** with:
- `LangVersion`: latest
- Multi-platform support: `win-x64;osx-x64;osx-arm64;linux-arm64;linux-x64`
- `CopyLocalLockFileAssemblies`: true (ensures all dependencies are copied)
