using Level.Application.Notification;
using MediatR;
using System;
using System.Collections.Generic;

namespace Level.Application.Mediators.Cart.GetAll
{
    public class GetAllRequest : Notifiable, IRequest<EntityResult<IEnumerable<GetAllResponse>>>
    {
        public Guid UserPersonId { get; set; }

        public GetAllRequest(Guid userPersonId)
        {
            UserPersonId = userPersonId;

            AddNotifications(new Contract()
                .AreNotEquals(userPersonId, Guid.Empty, "Request.Header.Authorization", "Authorization token with invalid person id.", NotificationCode.FieldInvalid)
            );
        }
    }
}
