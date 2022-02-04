using Level.Application.Notification;
using Level.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Level.Application.Mediators.ArticleItem.Insert
{
    public class InsertHandler : BaseHandler<InsertResponse>, IRequestHandler<InsertRequest, EntityResult<InsertResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private Actions _action = Actions.INSERT;
        private readonly IArticleItemRepository _articleItemRepository;

        public InsertHandler(IUnitOfWork unitOfWork, IArticleItemRepository articleItemRepository, ILogger<IEnumerable<InsertResponse>> logger)
            :base(logger)
        {
            _unitOfWork = unitOfWork;
            _articleItemRepository = articleItemRepository;
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
                Level.Domain.Entities.ArticleItem item = new Level.Domain.Entities.ArticleItem
                {
                    discount = 0,
                };
                
                await _articleItemRepository.InsertAsync(item);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Handle Insert ArticleItem; {ex.InnerException.Message ?? ex.Message}");
                result = ProcessException(result, ex); 
            }

            return result;
        }
    }
}
