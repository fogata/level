using Level.Application.Interfaces.Queries;
using Level.Application.Notification;
using Level.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Level.Application.Mediators.Cart.Insert
{
    public class InsertHandler : BaseHandler<IEnumerable<InsertResponse>>, IRequestHandler<InsertRequest, EntityResult<IEnumerable<InsertResponse>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private Actions _action = Actions.INSERT;
        private readonly ICartRepository _cartRepository;
        private readonly ICartQuery _cartQuery;

        public InsertHandler(IUnitOfWork unitOfWork, ICartRepository cartRepository, ICartQuery cartQuery, ILogger<IEnumerable<InsertResponse>> logger)
        : base(logger)
        {
            _unitOfWork = unitOfWork;
            _cartRepository = cartRepository;
            _cartQuery = cartQuery;
        }


        public async Task<EntityResult<IEnumerable<InsertResponse>>> Handle(InsertRequest request, CancellationToken cancellationToken)
        {
            var result = new EntityResult<IEnumerable<InsertResponse>>(_action, request.Notifications);


            if (result.Invalid)
            {
                result.Error = ErrorCode.UnprocessableEntity;
                return result;
            }

            try
            {
                foreach (var item in request.articlesPosts)
                {
                    Domain.Entities.Cart cart = new Domain.Entities.Cart
                    {
                        id = request.id,
                        articleId = item.articleId,
                        quantity = item.quantity,
                        userId = request.userId
                    };

                    var save = await _cartRepository.InsertAsync(cart);
                    await _unitOfWork.SaveAsync();
                }

                
                var query = await _cartQuery.GetAllAsync(request.userId);

                result.Entity = query.Select(x => (InsertResponse)x).ToList();


            }
            catch (Exception ex)
            {
                _logger.LogError($"Handle Insert Cart; {ex.InnerException.Message ?? ex.Message}");
                result = ProcessException(result, ex);
            }

            return result;
        }
    }
}
