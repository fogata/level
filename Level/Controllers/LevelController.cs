using Level.Application.Dto;
using Level.Application.Dto.Mediator;
using Level.Application.Mediators.Cart.GetAll;
using Level.Application.Mediators.Cart.Insert;
using Level.Presenters.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Level.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LevelController : BaseController
    {
        private readonly ICartPresenter _presenter;

        public LevelController(IConfiguration config, IMediator mediator,  IBasePresenter basePresenter, ICartPresenter cartPresenter)
            : base(config, mediator, basePresenter)
        {
            _presenter = cartPresenter;
        }

        /// <summary>
        /// Request carts of specific user
        /// </summary>
        /// <param name="UserPersonId"></param>
        /// <returns></returns>
        [HttpGet("cart")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartResponse))]
        public async Task<IActionResult> GetMyCarts([FromQuery] Guid UserPersonId)
        {
            
            var request = new GetAllRequest(UserPersonId);

            var mediator = await _mediator.Send(request);

            return _presenter.GetCartResult(mediator);
        }

        /// <summary>
        /// Transfer money from the principal account to the card virtual account
        /// </summary>
        /// <returns></returns>
        [HttpPost("cart/save")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllResponse))]
        public async Task<IActionResult> RunRecharge([FromBody] CartPost requestDto)
        {
            var request = new InsertRequest(requestDto);
            var mediator = await _mediator.Send(request);

            return _presenter.GetInsertResult(mediator);
        }
    }
}
