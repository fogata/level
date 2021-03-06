using Level.Application.Mediators.Discount.Insert;
using Level.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Level.Presenters.Interfaces
{
    public interface IDiscountPresenter
    {
        IActionResult GetInsertResult(EntityResult<InsertResponse> result);

    }
}
