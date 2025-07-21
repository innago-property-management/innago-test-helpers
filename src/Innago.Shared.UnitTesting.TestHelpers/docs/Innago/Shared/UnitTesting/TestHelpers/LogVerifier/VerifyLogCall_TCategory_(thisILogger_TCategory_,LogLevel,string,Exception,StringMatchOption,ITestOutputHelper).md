### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[LogVerifier](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier')

## LogVerifier\.VerifyLogCall\<TCategory\>\(this ILogger\<TCategory\>, LogLevel, string, Exception, StringMatchOption, ITestOutputHelper\) Method

Verifies that a Log call has been made\.

```csharp
public static void VerifyLogCall<TCategory>(this Microsoft.Extensions.Logging.ILogger<TCategory> logger, Microsoft.Extensions.Logging.LogLevel expectedLogLevel, string expectedMessagePattern, System.Exception? exception=null, Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption matchOption=Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption.Equals, Xunit.Abstractions.ITestOutputHelper? testOutputHelper=null);
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).TCategory'></a>

`TCategory`

The logger category\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[TCategory](VerifyLogCall_TCategory_(thisILogger_TCategory_,LogLevel,string,Exception,StringMatchOption,ITestOutputHelper).md#Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).TCategory 'Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.VerifyLogCall\<TCategory\>\(this Microsoft\.Extensions\.Logging\.ILogger\<TCategory\>, Microsoft\.Extensions\.Logging\.LogLevel, string, System\.Exception, Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.StringMatchOption, Xunit\.Abstractions\.ITestOutputHelper\)\.TCategory')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The [Microsoft\.Extensions\.Logging\.ILogger&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')\. NOTE: The logger MUST BE [Moq\.Mock&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/moq.mock-1 'Moq\.Mock\`1')\-created\.

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).expectedLogLevel'></a>

`expectedLogLevel` [Microsoft\.Extensions\.Logging\.LogLevel](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel 'Microsoft\.Extensions\.Logging\.LogLevel')

The expected [Microsoft\.Extensions\.Logging\.LogLevel](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel 'Microsoft\.Extensions\.Logging\.LogLevel')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).expectedMessagePattern'></a>

`expectedMessagePattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The expected message pattern\.

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The expected [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')\. This is relevant for [Microsoft\.Extensions\.Logging\.LoggerExtensions\.LogError\(Microsoft\.Extensions\.Logging\.ILogger,Microsoft\.Extensions\.Logging\.EventId,System\.Exception,System\.String,System\.Object\[\]\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loggerextensions.logerror#microsoft-extensions-logging-loggerextensions-logerror(microsoft-extensions-logging-ilogger-microsoft-extensions-logging-eventid-system-exception-system-string-system-object[]) 'Microsoft\.Extensions\.Logging\.LoggerExtensions\.LogError\(Microsoft\.Extensions\.Logging\.ILogger,Microsoft\.Extensions\.Logging\.EventId,System\.Exception,System\.String,System\.Object\[\]\)')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).matchOption'></a>

`matchOption` [StringMatchOption](StringMatchOption/index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.StringMatchOption')

The [StringMatchOption](StringMatchOption/index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.StringMatchOption')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).testOutputHelper'></a>

`testOutputHelper` [Xunit\.Abstractions\.ITestOutputHelper](https://learn.microsoft.com/en-us/dotnet/api/xunit.abstractions.itestoutputhelper 'Xunit\.Abstractions\.ITestOutputHelper')

The [Xunit\.Abstractions\.ITestOutputHelper](https://learn.microsoft.com/en-us/dotnet/api/xunit.abstractions.itestoutputhelper 'Xunit\.Abstractions\.ITestOutputHelper')\. If supplied, the message patterns seen will be logged\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
[logger](VerifyLogCall_TCategory_(thisILogger_TCategory_,LogLevel,string,Exception,StringMatchOption,ITestOutputHelper).md#Innago.Shared.UnitTesting.TestHelpers.LogVerifier.VerifyLogCall_TCategory_(thisMicrosoft.Extensions.Logging.ILogger_TCategory_,Microsoft.Extensions.Logging.LogLevel,string,System.Exception,Innago.Shared.UnitTesting.TestHelpers.LogVerifier.StringMatchOption,Xunit.Abstractions.ITestOutputHelper).logger 'Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.VerifyLogCall\<TCategory\>\(this Microsoft\.Extensions\.Logging\.ILogger\<TCategory\>, Microsoft\.Extensions\.Logging\.LogLevel, string, System\.Exception, Innago\.Shared\.UnitTesting\.TestHelpers\.LogVerifier\.StringMatchOption, Xunit\.Abstractions\.ITestOutputHelper\)\.logger') instance is not created by Moq\.

### Example

```csharp
var logger = Mock.Of<ILogger<MyClass>>();
var instance = new MyClass(logger);
instance.DoSomething();

logger.VerifyLogCall(
    LogLevel.Information,
    "MyClass: ",
    matchOption: LogVerifier.StringMatchOption.StartsWith);
```