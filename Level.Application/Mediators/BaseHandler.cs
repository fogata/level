using Level.Application.Notification;
using Microsoft.Extensions.Logging;
using OpenTracing;
using System;
using Level.Application.Extension;

namespace Level.Application.Mediators
{
    public class BaseHandler<T> : IBaseHandler
        where T : class
    {
        protected readonly ILogger _logger;

        public BaseHandler(ILogger logger)
        {
            _logger = logger;
        }
        protected EntityResult<T> ProcessException(EntityResult<T> result, Exception ex)
        {
            return ex.ProcessException(result, _logger);
        }
        
        protected bool IsBusinessError(NotificationCode code)
        {
            switch (code)
            {
                case NotificationCode.TransactionDenied:
                case NotificationCode.TransactionHeld:
                    return true;
                default:
                    return false;
            }
        }
        protected bool IsBusinessError(string code)
        {
            switch (code)
            {
                case "125":
                    return true;
                default:
                    return false;
            }
        }
    }
}
