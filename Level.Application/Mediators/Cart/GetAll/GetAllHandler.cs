using Level.Application.Dto.Repository;
using Level.Application.Interfaces.Queries;
using Level.Application.Notification;
using Level.Domain.Enum;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Level.Application.Mediators.Cart.GetAll
{
    public class GetAllHandler : BaseHandler<IEnumerable<GetAllResponse>>, IRequestHandler<GetAllRequest, EntityResult<IEnumerable<GetAllResponse>>>
    {
        private readonly Actions _action = Actions.GETALL;
        private readonly ICartQuery _cartQuery;
        private readonly IDeliveryQuery _deliveryQuery;
        private readonly IDiscountQuery _discountQuery;
        public GetAllHandler(ILogger<IEnumerable<GetAllResponse>> logger, ICartQuery cartQuery, 
            IDeliveryQuery deliveryQuery, IDiscountQuery discountQuery)
            : base(logger)
        {
            _cartQuery = cartQuery;
            _deliveryQuery = deliveryQuery;
            _discountQuery = discountQuery;
        }

        public async Task<EntityResult<IEnumerable<GetAllResponse>>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var result = new EntityResult<IEnumerable<GetAllResponse>>(_action, request.Notifications);
            
            if (result.Invalid)
            {
                result.Error = ErrorCode.BadRequest;
                return result;
            }

            try
            {
                var cartItems = await _cartQuery.GetAllAsync(
                    request.UserPersonId);

                var discountApply = await ApplyDiscount(cartItems, request.UserPersonId);

                var taxCalculated = await CalculateDeliveryFees(discountApply);


                result.Entity = taxCalculated.Select(x => (GetAllResponse)x).ToList();
            }
            catch (Exception ex)
            {
                result = ProcessException(result, ex);
            }

            return result;
        }

        private async Task<IEnumerable<CartSum>> CalculateDeliveryFees(IEnumerable<CartSum> cartSums)
        {
            var delivery = await  _deliveryQuery.GetAllAsync();
            foreach (var item in cartSums)
            {
                var tax = delivery.Where(t => item.total <= t.minPrice || item.total <= t.maxPrice).FirstOrDefault();
                item.total = Decimal.Add(item.total, tax?.price ?? 0);
            }

            return cartSums;
        }

        private async Task<IEnumerable<CartSum>> ApplyDiscount(IEnumerable<CartSum> cartSums, Guid userID)
        {
            var discount = await _discountQuery.GetAllAsync(userID);
            foreach (var item in cartSums)
            {
                var tax = discount.Where(d => d.articleId == item.articleId).FirstOrDefault();
                if(tax != null)
                {
                    var discountType = (DiscountType)Enum.Parse(typeof(DiscountType), tax.type);
                    if(discountType == DiscountType.percentage)
                    {
                        decimal discountTotal = (item.total * tax.total / 100);
                        item.total = Decimal.Subtract(item.total, discountTotal);
                    }
                    else
                    {
                        item.total = Decimal.Subtract(item.total, tax.total);
                    }
                }
                
            }

            return cartSums;
        }
    }
}
