using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicLibrary.Web.UI.Administration.Helpers
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger<Controller> _logger;
        public ErrorHandler(ILogger<Controller> logger)
        {
            _logger = logger;
        }
        public void HandleErrorException(string message)
        {
            _logger.LogError($"An error has occured : {message}");
        }

        public void LogError(string message)
        {
            _logger.LogError($"An error has occured: {message}");
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation($"Info: {message}");
        }
    }
}
