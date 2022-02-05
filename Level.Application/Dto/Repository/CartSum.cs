namespace Level.Application.Dto.Repository
{
    public class CartSum
    {
        public int id { get; set; }

        public int articleId { get; set; }
        public decimal total { get; set; }
    }
}
