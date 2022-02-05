using Level.Application.Interfaces.Queries;
using Level.Application.Notification;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Level.Application.Mediators.Delivery.GetAll
{
    public class GetAllHandler : BaseHandler<IEnumerable<GetAllResponse>>, IRequestHandler<GetAllRequest, EntityResult<IEnumerable<GetAllResponse>>>
    {
        private readonly Actions _action = Actions.GETALL;
        private readonly IDeliveryQuery _deliveryQuery;

        public GetAllHandler(ILogger<IEnumerable<GetAllResponse>> logger, IDeliveryQuery deliveryQuery)
            : base(logger)
        {
            _deliveryQuery= deliveryQuery;
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
                var articles = await _deliveryQuery.GetAllAsync();

                result.Entity = articles.Select(x => (GetAllResponse)x).ToList();
            }
            catch (Exception ex)
            {
                result = ProcessException(result, ex);
            }

            return result;
        }
    }
}
