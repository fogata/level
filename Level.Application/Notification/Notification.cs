namespace Level.Application.Notification
{
    public sealed class Notification
    {
        public string Property
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }

        public NotificationCode Code
        {
            get;
            private set;
        }

        public Notification(string property, string message, NotificationCode code = NotificationCode.FieldInvalidFormat)
        {
            Property = property;
            Message = message;
            Code = code;
        }
    }
}
