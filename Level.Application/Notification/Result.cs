using System.Collections.Generic;

namespace Level.Application.Notification
{
    public class Result : Notifiable
    {
        public Actions Action { get; private set; }
        public ErrorCode? Error { get; set; }

        public Result(Actions action)
        {
            Error = null;
            Action = action;
        }

        public Result(Actions action, IReadOnlyCollection<Notification> notifications)
            : this(action)
        {
            AddNotifications(notifications);
        }

        public Result(Actions action, IReadOnlyCollection<Notification> notifications, ErrorCode error)
            : this(action)
        {
            Error = error;
            AddNotifications(notifications);
        }

        public void AddNotification(string error)
        {
            AddNotification(null, error);
        }
        public void AddNotification(string error, ErrorCode errorCode)
        {
            AddNotification(null, error);
            Error = errorCode;
        }
        public void AddNotification(string error, ErrorCode code, ErrorCode errorCode)
        {
            AddNotification(null, error, code);
            Error = errorCode;
        }
        public void AddNotification(string property, string message, ErrorCode errorCode)
        {
            AddNotification(property, message);
            Error = errorCode;
        }
        public void AddNotification(string property, string message, NotificationCode code, ErrorCode errorCode)
        {
            AddNotification(property, message, code);
            Error = errorCode;
        }
        public void AddNotification(Notification notification, ErrorCode errorCode)
        {
            AddNotification(notification);
            Error = errorCode;
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications, ErrorCode errorCode)
        {
            AddNotifications(notifications);
            Error = errorCode;
        }
    }
}
