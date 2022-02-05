using Level.Model;
using Level.Presenters.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Level.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status502BadGateway, Type = typeof(ApiError))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ApiError))]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IBasePresenter _basePresenter;

        protected readonly int DEFAULT_PAGE_NUMBER = 1;
        protected readonly int DEFAULT_PAGE_SIZE;

        public BaseController(IConfiguration config, IMediator mediator, IBasePresenter basePresenter)
        {
            _mediator = mediator;
            _basePresenter = basePresenter;
            DEFAULT_PAGE_SIZE = int.TryParse(config.GetSection("DefaultPageSize").Value, out DEFAULT_PAGE_SIZE) ? DEFAULT_PAGE_SIZE : 10;
        }
    }
}
