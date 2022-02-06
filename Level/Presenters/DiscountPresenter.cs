using Level.Application.Mediators.Discount.Insert;
using Level.Application.Notification;
using Level.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Level.Presenters
{
    public class DiscountPresenter : BasePresenter, IDiscountPresenter
    {
        public IActionResult GetInsertResult(EntityResult<InsertResponse> result)
        {
            var urlBuilder =
                   new UriBuilder()
                   {
                       Path = $"",
                       Query = null,
                   };

            string url = urlBuilder.ToString();

            return result.Invalid ? base.GetActionResult(result) : new CreatedResult(url, (InsertResponse)result.Entity);
        }

    }
}
