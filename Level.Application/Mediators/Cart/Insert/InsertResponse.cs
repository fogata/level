using Level.Application.Dto.Repository;
using Newtonsoft.Json;
using System;

namespace Level.Application.Mediators.Cart.Insert
{
    public class InsertResponse
    {
        public int id { get; set; }
        public Guid userId { get; set; }
        public decimal total { get; set; }

        public static explicit operator InsertResponse(CartSum value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            return JsonConvert.DeserializeObject<InsertResponse>(serializedValue);
        }
    }
}
