using Level.Application.Notification;
using MediatR;
using System.Collections.Generic;

namespace Level.Application.Mediators.Delivery.GetAll
{
    public class GetAllRequest : Notifiable, IRequest<EntityResult<IEnumerable<GetAllResponse>>>
    {
    }
}
