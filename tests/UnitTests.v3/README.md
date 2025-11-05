# UnitTests.v3 - xUnit v3 Test Project

This test project is configured for xUnit v3 but currently cannot build due to dependency conflicts.

## Issue

The v3 test helper library projects (Innago.Shared.UnitTesting.TestHelpers.v3 and Innago.Shared.UnitTesting.TestHelpers.OpenTelemetry.v3) are currently using linked source files from their v2 counterparts:

```xml
<Compile Include="..\Innago.Shared.UnitTesting.TestHelpers\**\*.cs" ... />
```

This causes type conflicts because:
1. The linked v2 source code references xUnit v2 types (e.g., `Xunit.Abstractions.ITestOutputHelper`)
2. The v3 project references xUnit v3 types (e.g., `Xunit.ITestOutputHelper`)
3. Both sets of types exist simultaneously, causing ambiguity errors

## Solution

To fix this, the v3 test helper library projects need to:

1. Have their source code physically copied (not linked) from v2 projects
2. Update all xUnit v2 references to v3 equivalents:
   - `Xunit.Abstractions.ITestOutputHelper` → `Xunit.ITestOutputHelper`
   - `using Xunit.Abstractions;` → `using Xunit;`
   - Review and update any other v2-specific APIs

3. The main changes from v2 to v3:
   - `ITestOutputHelper` moved from `Xunit.Abstractions` to `Xunit` namespace
   - Test projects must be executables (`<OutputType>Exe</OutputType>`)
   - Library projects referencing xUnit should use `xunit.v3.extensibility.core` instead of `xunit.v3`

## Current Build Error

```
error CS0104: 'ITestOutputHelper' is an ambiguous reference between
'Xunit.Abstractions.ITestOutputHelper' and 'Xunit.ITestOutputHelper'
```

This error occurs because the test helper libraries are mixing v2 and v3 types through linked files.
