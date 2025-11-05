# Innago.Shared.UnitTesting.TestHelpers

Helper methods to make TDD and Unit Testing easier/faster.

## xUnit Version Support

This repository provides packages for both xUnit v2 and xUnit v3. Choose the version that matches your project's xUnit dependency:

### xUnit v2 Packages (xunit 2.9.x)
```xml
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers" Version="0.1.0" />
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry" Version="0.1.0" />
<PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers" Version="0.1.0" />
```

### xUnit v3 Packages (xunit.v3 3.1.x)
```xml
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.v3" Version="0.1.0" />
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3" Version="0.1.0" />
<PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers.v3" Version="0.1.0" />
```

**Important:** The `.v3` packages are separate NuGet packages with different package IDs. They share the same source code but target different xUnit versions. See [MIGRATION.md](MIGRATION.md) for guidance on upgrading from v2 to v3.

## Installation

Choose the appropriate package based on your xUnit version:

### For xUnit v2 Projects
```bash
dotnet add package Innago.Shared.UnitTesting.TestHelpers
dotnet add package Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry
dotnet add package Innago.Shared.ServiceTesting.TestHelpers
```

### For xUnit v3 Projects
```bash
dotnet add package Innago.Shared.UnitTesting.TestHelpers.v3
dotnet add package Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3
dotnet add package Innago.Shared.ServiceTesting.TestHelpers.v3
```

## Package Descriptions

All packages are available in both v2 and v3 variants:

- **UnitTesting.TestHelpers** - Core unit testing utilities including ServiceVerifier, LogVerifier, PropertyChecker, and MethodChecker
- **UnitTesting.TestHelpers.OpenTelemetry** - OpenTelemetry testing utilities with TraceVerifier for Activity-based testing
- **ServiceTesting.TestHelpers** - Service/integration testing utilities with WebApplicationFactory and in-memory database support

## Documentation

[Unit Testing Test Helpers](src/Innago.Shared.UnitTesting.TestHelpers/docs/Innago.Shared.UnitTesting.TestHelpers.md)

[OpenTelemetry Test Helpers](src/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry/docs/Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.md)

[Service/Integration Testing Test Helpers](src/Innago.Shared.ServiceTesting.TestHelpers/docs/Innago.Shared.ServiceTesting.TestHelpers.md)

[Migration Guide (v2 to v3)](MIGRATION.md)
