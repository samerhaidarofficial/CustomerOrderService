using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerOrderService.Logging
{
    public class ErrorLogger
    {
        private readonly ILogger<ErrorLogger> _logger;

        public ErrorLogger(ILogger<ErrorLogger> logger)
        {
            _logger = logger;
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        public void LogAudit(string message)
        {
            _logger.LogInformation($"[AUDIT] {message}");
        }
    }
}
