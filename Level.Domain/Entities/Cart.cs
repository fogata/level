using System;

namespace Level.Domain.Entities
{
    public class Cart
    {
        public int id { get; set; }
        public int articleId { get; set; }
        public Guid userId { get; set; }
        public int quantity { get; set; }
    }
}
