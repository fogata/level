using System;
using System.Collections.Generic;

namespace Level.Domain.Entities
{
    public class Order
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public int cartId { get; set; }
        public ICollection<Cart> carts { get; set; }
    }
}
