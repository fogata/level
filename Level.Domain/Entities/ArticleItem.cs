using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level.Domain.Entities
{
    public class ArticleItem
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public int articleId { get; set; }
        public Articles articles { get; set; }
        public int quantity { get; set; }
        public string  discountType { get; set; }
        public decimal discount { get; set; }

        [Ignore]
        public Cart cart { get; set; }
    }
}
