namespace Innago.Shared.UnitTesting.TestHelpers;

using System;
using System.Text.RegularExpressions;

using FluentAssertions;

using JetBrains.Annotations;

using Microsoft.Extensions.Logging;

using Moq;

using Xunit.Abstractions;

/// <summary>
///     Verifies that a message is logged.
/// </summary>
[PublicAPI]
public static class LogVerifier
{
    /// <summary>
    ///     String Match Option.
    /// </summary>
    public enum StringMatchOption
    {
        /// <summary>
        ///     string.Equals
        /// </summary>
        Equals,

        /// <summary>
        ///     string.StartsWith
        /// </summary>
        StartsWith,

        /// <summary>
        ///     string.EndsWith
        /// </summary>
        EndsWith,

        /// <summary>
        ///     string.Contains
        /// </summary>
        Contains,

        /// <summary>
        ///     Regex.IsMatch
        /// </summary>
        RegEx,
    }

    /// <summary>
    ///     Verifies that a Log call has been made.
    /// </summary>
    /// <param name="logger">
    ///     The <see cref="ILogger{T}"/>. NOTE: The logger MUST BE <see cref="Mock{T}"/>-created.
    /// </param>
    /// <param name="expectedLogLevel">
    ///     The expected <see cref="LogLevel"/>.
    /// </param>
    /// <param name="expectedMessagePattern">
    ///     The expected message pattern.
    /// </param>
    /// <param name="exception">
    ///     The expected <see cref="Exception"/>. This is relevant for <see cref="LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception?,string?,object?[])"/>.
    /// </param>
    /// <param name="matchOption">
    ///     The <see cref="StringMatchOption"/>.
    /// </param>
    /// <param name="testOutputHelper">
    ///     The <see cref="ITestOutputHelper"/>. If supplied, the message patterns seen will be logged.
    /// </param>
    /// <typeparam name="TCategory">
    ///     The logger category.
    /// </typeparam>
    /// <exception cref="ArgumentException">
    ///     <paramref name="logger"/> instance is not created by Moq.
    /// </exception>
    /// <example>
    /// <code>
    /// var logger = Mock.Of&lt;ILogger&lt;MyClass>>();
    /// var instance = new MyClass(logger);
    /// instance.DoSomething();
    /// 
    /// logger.VerifyLogCall(
    ///     LogLevel.Information,
    ///     "MyClass: ",
    ///     matchOption: LogVerifier.StringMatchOption.StartsWith);
    /// </code>
    /// </example>
    /// <example>
    /// <code>
    /// logger.VerifyLogCall(
    ///     LogLevel.Error,
    ///     exception.Message,
    ///     exception,
    ///     matchOption: LogVerifier.StringMatchOption.EndsWith,
    ///     testOutputHelper: outputHelper);
    /// </code>
    /// </example>
    public static void VerifyLogCall<TCategory>(
        this ILogger<TCategory> logger,
        LogLevel expectedLogLevel,
        string expectedMessagePattern,
        Exception? exception = null,
        StringMatchOption matchOption = StringMatchOption.Equals,
        ITestOutputHelper? testOutputHelper = null
    )
    {
        Mock<ILogger<TCategory>> mock = Mock.Get(logger);
        mock.Should().NotBeNull();

        Func<LogLevel, bool> logLevelMatcher = MatchLogLevel;

        Func<object, Type, bool> messageMatcher = MatchMessage;

        mock.Verify(l => l.Log(
                It.Is<LogLevel>(level => logLevelMatcher(level)),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((obj, type) => messageMatcher(obj, type)),
                exception ?? It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);

        // ReSharper disable once SeparateLocalFunctionsWithJumpStatement
        bool MatchLogLevel(LogLevel level) => level == expectedLogLevel;

        bool MatchMessage(object pattern, Type _)
        {
            string matchText = pattern.ToString() ?? string.Empty;
            testOutputHelper?.WriteLine($"Actual message pattern: {matchText}");

            return matchOption switch
            {
                StringMatchOption.Equals => string.Equals(matchText, expectedMessagePattern, StringComparison.InvariantCulture),
                StringMatchOption.StartsWith => matchText.StartsWith(expectedMessagePattern, StringComparison.InvariantCulture),
                StringMatchOption.EndsWith => matchText.EndsWith(expectedMessagePattern, StringComparison.InvariantCulture),
                StringMatchOption.Contains => matchText.Contains(expectedMessagePattern),
                StringMatchOption.RegEx => new Regex(expectedMessagePattern).IsMatch(matchText),
                _ => false,
            };
        }
    }
}