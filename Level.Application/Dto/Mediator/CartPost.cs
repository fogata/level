using System;
using System.Collections.Generic;

namespace Level.Application.Dto.Mediator
{
    public  class CartPost
    {
        public int Id { get; set; }
        public Guid userId { get; set; }

        public List<ArticlesPost> articlesPosts { get; set; }
    }
}
