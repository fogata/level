using System.Collections.Generic;
using System.Linq;

namespace Level.Application.Notification
{
    public abstract class Notifiable
    {
        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool Invalid => _notifications.Any();

        public bool Valid => !Invalid;

        protected Notifiable()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string property, string message, NotificationCode code = NotificationCode.FieldInvalid)
        {
            _notifications.Add(new Notification(property, message, code));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params Notifiable[] items)
        {
            foreach (Notifiable item in items)
            {
                AddNotifications(item);
            }
        }

        public void Clear()
        {
            _notifications.Clear();
        }
    }
}
