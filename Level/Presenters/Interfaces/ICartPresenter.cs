using Level.Application.Mediators.Cart.GetAll;
using Level.Application.Mediators.Cart.Insert;
using Level.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Level.Presenters.Interfaces
{
    public interface ICartPresenter
    {
        IActionResult GetInsertResult(EntityResult<IEnumerable<InsertResponse>> result);

        IActionResult GetCartResult(EntityResult<IEnumerable<GetAllResponse>> result);
    }
}
