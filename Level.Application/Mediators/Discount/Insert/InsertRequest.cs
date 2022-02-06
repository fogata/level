using Level.Application.Dto.Mediator;
using Level.Application.Notification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Level.Application.Mediators.Discount.Insert
{
    public class InsertRequest : Notifiable, IRequest<EntityResult<InsertResponse>>
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public List<DiscountPost> discountPosts { get; set; }

        public InsertRequest(List<DiscountPost> item)
        {
            discountPosts = item;
            userId = item.First().userId;

            AddNotifications(new Contract()
                .IsNotNullOrEmpty(
                    userId.ToString(), "userId", "quantity should not be empty,null or less than 0.", NotificationCode.FieldMissing
                )
            );

            foreach (var discount in item)
            {
                AddNotifications(new Contract()
                .IsLowerThan(0,discount.articleId, "articleId", "articleId should not be empty,null or less than 0.", NotificationCode.FieldMissing)
                .IsLowerThan(0,discount.total, "total", "total should not be empty,null or less than 0", NotificationCode.FieldMissing)
                .IsNotNullOrEmpty(discount.type, "type", "type should not be empty,null or less than 0.", NotificationCode.FieldMissing)
            );
            }
        }

    }
}
