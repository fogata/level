using System;

namespace Level.Domain.Entities
{
    public class Discount
    {
        public int id { get; set; }
        public int articleId { get; set; }
        public Guid userId { get; set; }
        public string type { get; set; }
        public int total { get; set; }
    }
}
