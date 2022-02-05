using Level.Application.Dto;
using Level.Application.Mediators.Cart.GetAll;
using Level.Application.Mediators.Cart.Insert;
using Level.Application.Notification;
using Level.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Level.Presenters
{
    public class CartPresenter : BasePresenter, ICartPresenter
    {
        public IActionResult GetInsertResult(EntityResult<IEnumerable<InsertResponse>> result)
        {
            var urlBuilder =
                   new UriBuilder()
                   {
                       Path = $"",
                       Query = null,
                   };

            string url = urlBuilder.ToString();

            return result.Invalid ? base.GetActionResult(result) : new CreatedResult(url, (CartInsertResponse)result.Entity);
        }

        public IActionResult GetCartResult(EntityResult<IEnumerable<GetAllResponse>> result)
        {
            var urlBuilder =
                   new UriBuilder()
                   {
                       Path = $"",
                       Query = null,
                   };

            string url = urlBuilder.ToString();

            return result.Invalid
            ? base.GetActionResult(result)
            : new JsonResult(result.Entity.Select(x => (CartResponse)x));

        }
    }
}
