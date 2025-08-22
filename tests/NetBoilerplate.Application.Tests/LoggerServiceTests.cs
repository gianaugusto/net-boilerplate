using Microsoft.Extensions.Logging;
using Moq;
using NetBoilerplate.Application.Services;
using System;
using Xunit;

namespace NetBoilerplate.Application.Tests
{
    public class LoggerServiceTests
    {
        private readonly Mock<ILogger<LoggerService>> _loggerMock;
        private readonly LoggerService _loggerService;

        public LoggerServiceTests()
        {
            _loggerMock = new Mock<ILogger<LoggerService>>();
            _loggerService = new LoggerService(_loggerMock.Object);
        }

        [Fact]
        public void LogInformation_LogsMessage()
        {
            // Arrange
            var message = "Test information message";

            // Act
            _loggerService.LogInformation(message);

            // Assert
            _loggerMock.Verify(logger => logger.LogInformation(message), Times.Once);
        }

        [Fact]
        public void LogError_LogsErrorWithException()
        {
            // Arrange
            var message = "Test error message";
            var exception = new Exception("Test exception");

            // Act
            _loggerService.LogError(message, exception);

            // Assert
            _loggerMock.Verify(logger => logger.LogError(exception, message), Times.Once);
        }
    }
}
