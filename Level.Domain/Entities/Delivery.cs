namespace Level.Domain.Entities
{
    public  class Delivery
    {
        public int id { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        public decimal price { get; set; }
    }
}
