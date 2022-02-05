using Level.Application.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Level.Presenters.Interfaces
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T, Y>(T result)
            where T : EntityResult<Y>
            where Y : class;
        IActionResult GetActionResult<T>(T result) where T : Result;
    }
}
