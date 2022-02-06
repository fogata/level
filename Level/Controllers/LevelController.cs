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
using System.Collections.Generic;
using System.Threading.Tasks;
using dtoMediators = Level.Application.Mediators;

namespace Level.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LevelController : BaseController
    {
        private readonly ICartPresenter _presenter;
        private readonly IDiscountPresenter _discountPresenter;
        private readonly IArticlePresenter _articlePresenter;
        private readonly IDeliveryPresenter _deliveryPresenter;

        public LevelController(IConfiguration config, IMediator mediator,  IBasePresenter basePresenter, 
            ICartPresenter cartPresenter, IDiscountPresenter discountPresenter, IArticlePresenter articlePresenter,
            IDeliveryPresenter deliveryPresenter)
            : base(config, mediator, basePresenter)
        {
            _presenter = cartPresenter;
            _discountPresenter = discountPresenter;
            _articlePresenter = articlePresenter;
            _deliveryPresenter = deliveryPresenter;
        }

        /// <summary>
        /// Get all Articles
        /// </summary>
        /// <param name="UserPersonId"></param>
        /// <returns></returns>
        [HttpGet("article")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartResponse))]
        public async Task<IActionResult> GetMyCarts()
        {

            var request = new dtoMediators.Article.GetAll.GetAllRequest();

            var mediator = await _mediator.Send(request);

            return _articlePresenter.GetArticleResult(mediator);
        }

        /// <summary>
        /// Get carts of specific user
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
        /// Save the cart of specific user
        /// </summary>
        /// <returns></returns>
        [HttpPost("cart/save")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllResponse))]
        public async Task<IActionResult> SaveCart([FromBody] CartPost requestDto)
        {
            var request = new InsertRequest(requestDto);
            var mediator = await _mediator.Send(request);

            return _presenter.GetInsertResult(mediator);
        }

        /// <summary>
        /// Save the discounts.
        /// </summary>
        /// <returns></returns>
        [HttpPost("discount/save")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(dtoMediators.Discount.Insert.InsertResponse))]
        public async Task<IActionResult> SaveDiscount([FromBody] List<DiscountPost> requestDto)
        {
            var request = new dtoMediators.Discount.Insert.InsertRequest(requestDto);
            var mediator = await _mediator.Send(request);

            return _discountPresenter.GetInsertResult(mediator);
        }

        /// <summary>
        /// Get delivery fees
        /// </summary>
        /// <param name="UserPersonId"></param>
        /// <returns></returns>
        [HttpGet("delivery")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartResponse))]
        public async Task<IActionResult> GetDiscounts()
        {

            var request = new dtoMediators.Delivery.GetAll.GetAllRequest();

            var mediator = await _mediator.Send(request);

            return _deliveryPresenter.GetDeliveryResult(mediator);
        }

    }
}
