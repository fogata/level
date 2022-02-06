using Level.Application.Mediators.Article.GetAll;
using Level.Application.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Level.Presenters.Interfaces
{
    public interface IArticlePresenter
    {
        IActionResult GetArticleResult(EntityResult<IEnumerable<GetAllResponse>> result);
    }
}
