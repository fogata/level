using Level.Application.Notification;
using Level.Model;
using Level.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Level.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public virtual IActionResult GetActionResult<T>(T result)
            where T : Result
        {
            if (result.Invalid)
            {
                return CreateErrorResult(result);
            }

            return new OkResult();
        }

        public virtual IActionResult GetActionResult<T, Y>(T result)
            where Y : class
            where T : EntityResult<Y>
        {
            if (result.Error != null)
            {
                return CreateErrorResult(result);
            }

            return new OkObjectResult(result.Entity);
        }

        protected virtual IActionResult CreateErrorResult<T>(T result)
            where T : Result
        {
            var errorBody = ApiError.FromResult(result);
            return result.Error switch
            {
                ErrorCode.BadRequest => new BadRequestObjectResult(errorBody),
                ErrorCode.Unauthorized => new UnauthorizedObjectResult(errorBody),
                ErrorCode.NotFound => new NotFoundObjectResult(errorBody),
                ErrorCode.Forbidden => new ObjectResult(errorBody) { StatusCode = (int)HttpStatusCode.Forbidden },
                ErrorCode.UnprocessableEntity => new UnprocessableEntityObjectResult(errorBody),
                _ => new BadRequestObjectResult(errorBody),
            };
        }
    }
}
