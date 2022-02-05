using Level.Application.Mediators.Cart.GetAll;
using Newtonsoft.Json;

namespace Level.Application.Dto
{
    public class CartResponse
    {
        public int id { get; set; }
        public decimal total { get; set; }

        public static explicit operator CartResponse(GetAllResponse value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            return JsonConvert.DeserializeObject<CartResponse>(serializedValue);
        }

       
    }
}
