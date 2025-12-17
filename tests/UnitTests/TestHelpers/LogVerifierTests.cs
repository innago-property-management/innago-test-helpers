namespace UnitTests.TestHelpers;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Innago.Shared.UnitTesting.TestHelpers;

[UnitTest(nameof(LogVerifier))]
public class LogVerifierTests
{
    private readonly ITestOutputHelper outputHelper;
    private readonly ILogger<MyClass> logger;
    private readonly MyClass instance;

    public LogVerifierTests(ITestOutputHelper outputHelper)
    {
        this.outputHelper = outputHelper;
        this.logger = Mock.Of<ILogger<MyClass>>(MockBehavior.Loose);
        Mock.Get(this.logger).Setup(logger1 => logger1.IsEnabled(It.IsAny<LogLevel>())).Returns(true);
        this.instance = new MyClass(this.logger);
    }

    public static IEnumerable<object[]> StringMatchOptionsValues()
    {
        IEnumerable<LogVerifier.StringMatchOption> values = Enum.GetValues<LogVerifier.StringMatchOption>();

        var value = 0;

        foreach (LogVerifier.StringMatchOption stringMatchOption in values)
        {
            yield return new object[] { stringMatchOption, value++ };
        }
    }

    [Theory]
    [MemberData(nameof(StringMatchOptionsValues))]
    public void StringMatchOptions(LogVerifier.StringMatchOption stringMatchOption, int value)
    {
        ((int)stringMatchOption).Should().Be(value);
    }

    [Fact]
    public void VerifyLogCallShouldThrowIfLoggerNotMock()
    {
        var nullLogger = new NullLogger<MyClass>();
        var myClass = new MyClass(nullLogger);

        myClass.DoAndLogInfo();

        Action act = () => nullLogger.VerifyLogCall(LogLevel.Information, string.Empty);

        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(LogVerifier.StringMatchOption.Equals, "MyClass: DoAndLogInfo 1")]
    [InlineData(LogVerifier.StringMatchOption.StartsWith, "MyClass: ")]
    [InlineData(LogVerifier.StringMatchOption.EndsWith, "DoAndLogInfo 1")]
    [InlineData(LogVerifier.StringMatchOption.Contains, "DoAndLogInfo")]
    [InlineData(LogVerifier.StringMatchOption.RegEx, ".*DoAndLogInfo \\d+")]
    public void VerifyLogCallShouldNotThrowIfMatch(LogVerifier.StringMatchOption matchOption, string pattern)
    {
        this.instance.DoAndLogInfo();

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Information,
            pattern,
            matchOption: matchOption,
            testOutputHelper: this.outputHelper);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(LogVerifier.StringMatchOption.Equals, "MyClass: DoAndLogInfo 1")]
    [InlineData(LogVerifier.StringMatchOption.StartsWith, "MyClass: ")]
    [InlineData(LogVerifier.StringMatchOption.EndsWith, "DoAndLogInfo 1")]
    [InlineData(LogVerifier.StringMatchOption.Contains, "DoAndLogInfo")]
    [InlineData(LogVerifier.StringMatchOption.RegEx, ".*DoAndLogInfo \\d+")]
    public void VerifyLogCallShouldThrowIfWrongLevel(LogVerifier.StringMatchOption matchOption, string pattern)
    {
        this.instance.DoAndLogInfo();

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Debug,
            pattern,
            matchOption: matchOption,
            testOutputHelper: this.outputHelper);

        act.Should().Throw<MockException>();
    }

    [Theory]
    [InlineData(LogVerifier.StringMatchOption.Equals, "MyClass: DoAndLogTrace 1")]
    [InlineData(LogVerifier.StringMatchOption.StartsWith, "MyClass: ")]
    [InlineData(LogVerifier.StringMatchOption.EndsWith, "DoAndLogTrace 1")]
    [InlineData(LogVerifier.StringMatchOption.Contains, "DoAndLogTrace")]
    [InlineData(LogVerifier.StringMatchOption.RegEx, ".*DoAndLogTrace \\d+")]
    public void VerifyLogCallShouldNotThrowIfMatchTrace(LogVerifier.StringMatchOption matchOption, string pattern)
    {
        this.instance.DoAndLogTrace();

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Trace,
            pattern,
            matchOption: matchOption,
            testOutputHelper: this.outputHelper);

        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(LogVerifier.StringMatchOption.Equals, "MyClass: DoAndLogError message")]
    [InlineData(LogVerifier.StringMatchOption.StartsWith, "MyClass: ")]
    [InlineData(LogVerifier.StringMatchOption.EndsWith, "DoAndLogError message")]
    [InlineData(LogVerifier.StringMatchOption.Contains, "DoAndLogError")]
    [InlineData(LogVerifier.StringMatchOption.RegEx, ".*DoAndLogError \\w+")]
    public void VerifyLogCallShouldNotThrowIfMatchWithException(LogVerifier.StringMatchOption matchOption, string pattern)
    {
        var e = new Exception("message");
        this.instance.DoAndLogError(e);

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Error,
            pattern,
            e,
            matchOption: matchOption,
            testOutputHelper: this.outputHelper);

        act.Should().NotThrow();
    }

    [Fact]
    public void VerifyLogCallShouldThrowIfUnknownMatchOption()
    {
        this.instance.DoAndLogInfo();

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Information,
            "MyClass: DoAndLogInfo 1",
            matchOption: (LogVerifier.StringMatchOption)999);

        act.Should().Throw<MockException>();
    }

    [Theory]
    [InlineData(LogVerifier.StringMatchOption.Equals, "MyClass: DoAndLogError2 message")]
    [InlineData(LogVerifier.StringMatchOption.StartsWith, "MyClass: ")]
    [InlineData(LogVerifier.StringMatchOption.EndsWith, "DoAndLogError2 message")]
    [InlineData(LogVerifier.StringMatchOption.Contains, "DoAndLogError2")]
    [InlineData(LogVerifier.StringMatchOption.RegEx, ".*DoAndLogError2 \\w+")]
    public void VerifyLogCallShouldBeAbleToHandleDefinedErrors(LogVerifier.StringMatchOption matchOption, string pattern)
    {
        var e = new Exception("message");
        this.instance.DoAndLogError2(e);

        Action act = () => this.logger.VerifyLogCall(
            LogLevel.Error,
            pattern,
            e,
            matchOption: matchOption,
            testOutputHelper: this.outputHelper);

        act.Should().NotThrow();
    }

    public class MyClass
    {
        internal const string LogTemplate = $"{nameof(MyClass)}: {{Method}} {{Value}}";

        private readonly ILogger<MyClass> logger;

        public MyClass(ILogger<MyClass> logger)
        {
            this.logger = logger;
        }

        public void DoAndLogInfo()
        {
            this.logger.LogInformation(MyClass.LogTemplate, nameof(this.DoAndLogInfo), 1);
        }

        public void DoAndLogTrace()
        {
            this.logger.LogTrace(MyClass.LogTemplate, nameof(this.DoAndLogTrace), 1);
        }

        public void DoAndLogError(Exception e)
        {
            this.logger.LogError(e, MyClass.LogTemplate, nameof(this.DoAndLogError), e.Message);
        }

        public void DoAndLogError2(Exception e)
        {
            this.logger.MyClassError(e, nameof(this.DoAndLogError2));
        }
    }
}

internal static class LogMessages
{
    internal static void MyClassError(this ILogger<LogVerifierTests.MyClass> logger, Exception exception, string method) =>
        LogMessages.MyClassErrorDefinition(logger, method, exception.Message, exception);

    private static Action<ILogger, string, string, Exception> MakeDefinition(string formatString)
    {
        return LoggerMessage.Define<string, string>(LogLevel.Error, new EventId(0), formatString);
    }

    private static readonly Action<ILogger, string, string, Exception> MyClassErrorDefinition = MakeDefinition(LogVerifierTests.MyClass.LogTemplate);
}
