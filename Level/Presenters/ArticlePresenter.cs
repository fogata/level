using Level.Application.Dto;
using Level.Application.Mediators.Article.GetAll;
using Level.Application.Notification;
using Level.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Level.Presenters
{
    public class ArticlePresenter : BasePresenter, IArticlePresenter
    {
        
        public IActionResult GetArticleResult(EntityResult<IEnumerable<GetAllResponse>> result)
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
            : new JsonResult(result.Entity.Select(x => (ArticleResponse)x));

        }
    }
}
