using Newtonsoft.Json;

namespace Level.Application.Mediators.Delivery.GetAll
{
    public class GetAllResponse
    {
        public int id { get; set; }
        public decimal minPrice { get; set; }
        public decimal maxPrice { get; set; }
        public decimal price { get; set; }

        public static explicit operator GetAllResponse(Domain.Entities.Delivery value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<GetAllResponse>(serializedValue);
        }
    }
}
