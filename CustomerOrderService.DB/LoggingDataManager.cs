using CustomerOrderService.Entities;
using CustomerOrderService.IDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderService.DB
{
    public class LoggingDataManager : ILoggingDataManager
    {
        private readonly AppDbContext _context;
        public LoggingDataManager(AppDbContext context) => _context = context;

        public void LogError(string message, string? stackTrace)
        {
            _context.ErrorLogs.Add(new ErrorLog { Message = message, StackTrace = stackTrace });
            _context.SaveChanges();
        }

        public  void LogAudit(string action, string entity, string? details = null)
        {
            _context.AuditLogs.Add(new AuditLog { Action = action, Entity = entity, Details = details });
            _context.SaveChanges();
        }
    }
}
