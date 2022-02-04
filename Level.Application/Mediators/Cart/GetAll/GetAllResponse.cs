using Newtonsoft.Json;

namespace Level.Application.Mediators.Cart.GetAll
{
    public class GetAllResponse
    {
        public int id { get; set; }
        public int quantity { get; set; }

        public static explicit operator GetAllResponse(Level.Domain.Entities.Cart value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<GetAllResponse>(serializedValue);
        }
    }
}
