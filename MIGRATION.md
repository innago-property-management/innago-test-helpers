# Migration Guide: xUnit v2 to v3

This guide helps you migrate your test projects from using the xUnit v2 test helper packages to the xUnit v3 versions.

## Overview

The test helper library is available in two parallel versions:
- **v2 packages** - Compatible with xUnit 2.9.x
- **v3 packages** - Compatible with xUnit v3 3.1.x

Both versions share identical source code and APIs. The only difference is the xUnit dependency version.

## When to Migrate

Migrate to v3 packages when:
- You are upgrading your test project to xUnit v3
- You are starting a new project and want to use xUnit v3
- You need features only available in xUnit v3

Stay on v2 packages when:
- Your project uses xUnit 2.x and you don't plan to upgrade
- You need compatibility with other libraries that depend on xUnit 2.x

## Migration Steps

### Step 1: Update xUnit Dependencies

First, upgrade your xUnit packages to v3:

```xml
<!-- Remove xUnit v2 packages -->
<PackageReference Include="xunit" Version="2.9.3" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />

<!-- Add xUnit v3 packages -->
<PackageReference Include="xunit.v3" Version="3.1.0" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.1.0" />
```

If you use xunit.categories:
```xml
<!-- Remove v2 -->
<PackageReference Include="xunit.categories" Version="2.0.8" />

<!-- Add v3 -->
<PackageReference Include="xunit.categories" Version="3.0.1" />
```

### Step 2: Update Test Helper Package References

Replace the v2 test helper packages with their v3 equivalents:

```xml
<!-- Remove v2 packages -->
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers" Version="0.1.0" />
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry" Version="0.1.0" />
<PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers" Version="0.1.0" />

<!-- Add v3 packages -->
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.v3" Version="0.1.0" />
<PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3" Version="0.1.0" />
<PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers.v3" Version="0.1.0" />
```

### Step 3: Update Using Statements (if needed)

In most cases, no code changes are required. The v3 packages use the same namespaces as v2:

```csharp
// These remain unchanged
using Innago.Shared.UnitTesting.TestHelpers;
using Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry;
using Innago.Shared.ServiceTesting.TestHelpers;
```

### Step 4: Build and Test

Build your project and run your tests:

```bash
dotnet build
dotnet test
```

All tests should pass without modification. If you encounter issues, verify that all xUnit-related packages have been updated to v3.

## Package Mapping Reference

| xUnit v2 Package | xUnit v3 Package |
|-----------------|------------------|
| `Innago.Shared.UnitTesting.TestHelpers` | `Innago.Shared.UnitTesting.TestHelpers.v3` |
| `Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry` | `Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3` |
| `Innago.Shared.ServiceTesting.TestHelpers` | `Innago.Shared.ServiceTesting.TestHelpers.v3` |

## What Changes Between v2 and v3

### Package-Level Changes
- **Package ID**: Adds `.v3` suffix (e.g., `Innago.Shared.UnitTesting.TestHelpers.v3`)
- **xUnit Dependency**: References `xunit.v3` 3.1.0 instead of `xunit` 2.9.3
- **xunit.categories**: Uses version 3.0.1 instead of 2.0.8 (where applicable)

### What Stays the Same
- **Source Code**: Identical implementation and APIs
- **Namespaces**: Same namespace structure
- **Assembly Names**: Same assembly names (note: not the package name)
- **API Surface**: All classes, methods, and signatures remain unchanged
- **Dependencies**: All non-xUnit dependencies remain the same

## Example Migration

### Before (xUnit v2)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="xunit" Version="2.9.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
    <PackageReference Include="xunit.categories" Version="2.0.8" />
    <PackageReference Include="Innago.Shared.UnitTesting.TestHelpers" Version="0.1.0" />
    <PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers" Version="0.1.0" />
  </ItemGroup>
</Project>
```

### After (xUnit v3)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="xunit.v3" Version="3.1.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="3.1.0" />
    <PackageReference Include="xunit.categories" Version="3.0.1" />
    <PackageReference Include="Innago.Shared.UnitTesting.TestHelpers.v3" Version="0.1.0" />
    <PackageReference Include="Innago.Shared.ServiceTesting.TestHelpers.v3" Version="0.1.0" />
  </ItemGroup>
</Project>
```

## Test Code Example

Your test code remains completely unchanged:

```csharp
using Innago.Shared.UnitTesting.TestHelpers;
using Xunit;

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

This code works identically with both v2 and v3 packages.

## Troubleshooting

### Mixed Version Errors

If you see errors about mixed xUnit versions, ensure all xUnit-related packages are either v2 or v3:

```
Error: Package 'xunit 2.9.3' is not compatible with 'xunit.v3 3.1.0'
```

**Solution**: Ensure you've updated all xUnit packages to v3, including transitive dependencies.

### Cannot Find Type or Namespace

If you see "The type or namespace 'TestHelpers' could not be found":

**Solution**: Verify you've added the correct v3 package reference with the `.v3` suffix.

### Assembly Load Errors

If you see assembly load errors at runtime:

**Solution**: Clean your bin and obj directories and rebuild:
```bash
dotnet clean
dotnet build
```

## Rollback Instructions

If you need to rollback to v2:

1. Restore xUnit v2 packages
2. Restore test helper v2 packages (remove `.v3` suffix)
3. Clean and rebuild

## Additional Resources

- [xUnit v3 Migration Guide](https://xunit.net/docs/v3-alpha-migration)
- [Test Helpers Documentation](README.md)
- [Repository Issues](https://github.com/innago-property-management/test-helpers/issues)

## Questions?

If you encounter issues during migration, please open an issue in the repository with:
- Your project's .csproj file
- The error message or unexpected behavior
- Steps to reproduce the issue
