using Level.Application.Dto.Repository;
using Newtonsoft.Json;

namespace Level.Application.Mediators.Cart.GetAll
{
    public class GetAllResponse
    {
        public int id { get; set; }
        public decimal total { get; set; }

        public static explicit operator GetAllResponse(CartSum value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<GetAllResponse>(serializedValue);
        }
    }
}
