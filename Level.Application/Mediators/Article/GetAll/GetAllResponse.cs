using Newtonsoft.Json;

namespace Level.Application.Mediators.Article.GetAll
{
    public class GetAllResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }

        public static explicit operator GetAllResponse(Domain.Entities.Articles value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<GetAllResponse>(serializedValue);
        }
    }
}
