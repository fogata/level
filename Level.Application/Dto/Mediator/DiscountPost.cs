using System;

namespace Level.Application.Dto.Mediator
{
    public class DiscountPost
    {
        public Guid userId { get; set; }
        public int articleId { get; set; }
        public string type { get; set; }
        public int total { get; set; }
    }
}
