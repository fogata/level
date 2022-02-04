using Level.Application.Mediators.Article.GetAll;

namespace Level.Application.Dto
{
    public class ArticleResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public static explicit operator ArticleResponse(GetAllResponse v)
        {
            return new ArticleResponse
            {
                id = v.id,
                name = v.name,
                price = v.price
            };
        }
    }
}
