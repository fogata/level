using Level.Application.Mediators.Cart.Insert;
using Newtonsoft.Json;
using System;

namespace Level.Application.Dto
{
    public class CartInsertResponse
    {
        public int id { get; set; }
        public decimal total { get; set; }

        public static explicit operator CartInsertResponse(InsertResponse value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<CartInsertResponse>(serializedValue);
        }
    }
}
