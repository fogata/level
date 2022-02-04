using Level.Application.Notification;
using Microsoft.Extensions.Logging;
using System;

namespace Level.Application.Extension
{
    public static class ExceptionExtensions
    {
        public static EntityResult<T> ProcessException<T>(this Exception ex, EntityResult<T> result, ILogger logger) where T : class
        {
            logger.LogError(ex, ex.Message);
            result.AddNotification(new Notification.Notification("Response.Exception.Message", ex.Message, NotificationCode.UnexpectedErrorUnexpected));
            result.Error = ErrorCode.InternalServerError;

            return result;
        }
       
    }
}
