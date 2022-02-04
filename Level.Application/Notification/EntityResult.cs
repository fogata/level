using System.Collections.Generic;

namespace Level.Application.Notification
{
    public class EntityResult<T> : Result where T : class
    {
        public EntityResult(Actions action, IReadOnlyCollection<Notification> notifications)
            : base(action, notifications)
        {
        }

        public EntityResult(Actions action, IReadOnlyCollection<Notification> notifications, T entity)
            : base(action, notifications)
        {
            Entity = entity;
        }

        public T Entity { get; set; }
    }
}
