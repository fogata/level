using Level.Application.Dto.Mediator;
using Level.Application.Notification;
using MediatR;
using System;
using System.Collections.Generic;

namespace Level.Application.Mediators.Cart.Insert
{
    public class InsertRequest : Notifiable, IRequest<EntityResult<IEnumerable<InsertResponse>>>
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public List<ArticlesPost> articlesPosts { get; set; }

        public InsertRequest(CartPost item)
        {
            id = item.Id;
            userId = item.userId;
            articlesPosts = item.articlesPosts;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(
                    userId.ToString(),"userId", "quantity should not be empty,null or less than 0.", NotificationCode.FieldMissing
                )
            );
        }
    }
}
