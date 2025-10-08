using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.IDB
{
    public interface ILoggingDataManager
    {
        void LogError(string message, string? stackTrace);
        void LogAudit(string action, string entity, string? details = null);
    }
}
