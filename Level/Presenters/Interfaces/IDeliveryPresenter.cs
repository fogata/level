using Level.Application.Mediators.Delivery.GetAll;
using Level.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Level.Presenters.Interfaces
{
    public interface IDeliveryPresenter
    {
        IActionResult GetDeliveryResult(EntityResult<IEnumerable<GetAllResponse>> result);
    }
}
