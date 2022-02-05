using Level.Application.Notification;
using Level.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Level.Application.Mediators.Discount.Insert
{
    public class InsertHandler : BaseHandler<InsertResponse>, IRequestHandler<InsertRequest, EntityResult<InsertResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private Actions _action = Actions.INSERT;
        private readonly IDiscountRepository _discountRepository;

        public InsertHandler(IUnitOfWork unitOfWork, IDiscountRepository discountRepository, ILogger<IEnumerable<InsertResponse>> logger)
        : base(logger)
        {
            _unitOfWork = unitOfWork;
            _discountRepository = discountRepository;
        }

        public async Task<EntityResult<InsertResponse>> Handle(InsertRequest request, CancellationToken cancellationToken)
        {
            var result = new EntityResult<InsertResponse>(_action, request.Notifications);


            if (result.Invalid)
            {
                result.Error = ErrorCode.UnprocessableEntity;
                return result;
            }

            try
            {
                foreach (var item in request.discountPosts)
                {
                    Domain.Entities.Discount discount = new Domain.Entities.Discount
                    {
                        id = request.id,
                        userId = request.userId,
                        articleId = item.articleId,
                        total = item.total,
                        type = item.type
                    };

                    var save = await _discountRepository.InsertAsync(discount);
                    await _unitOfWork.SaveAsync();
                }

                result.Entity = new InsertResponse();


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
