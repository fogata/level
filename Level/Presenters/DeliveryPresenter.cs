using Level.Application.Dto;
using Level.Application.Mediators.Delivery.GetAll;
using Level.Application.Notification;
using Level.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Level.Presenters
{
    public class DeliveryPresenter : BasePresenter, IDeliveryPresenter
    {
       
        public IActionResult GetDeliveryResult(EntityResult<IEnumerable<GetAllResponse>> result)
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
            : new JsonResult(result.Entity.Select(x => (GetAllResponse)x));

        }
    }
}
