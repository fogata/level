using Level.Application.Dto.Mediator;
using Level.Application.Notification;
using MediatR;
using System;

namespace Level.Application.Mediators.ArticleItem.Insert
{
    public class InsertRequest : Notifiable, IRequest<EntityResult<InsertResponse>>
    {
        public int cartId { get; set; }
        public int articleId { get; set; }
        public int quantity { get; set; }

        public InsertRequest(ArticleItemPost item)
        {
            cartId = item.cartId;
            articleId = item.articleId;
            quantity = item.quantity;

            AddNotifications(new Contract()
                .IsGreaterThan(
                    0,cartId, "cartId", "cartId should not be empty or null.", NotificationCode.FieldMissing
                )
            );
        }
    }
}
