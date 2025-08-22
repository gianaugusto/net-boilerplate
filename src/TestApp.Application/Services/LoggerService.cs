using Microsoft.Extensions.Logging;
using System;

namespace TestApp.Application.Services
{
    public class LoggerService
    {
        private readonly ILogger<LoggerService> _logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.LogError(exception, message);
        }
    }
}
