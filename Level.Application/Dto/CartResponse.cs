using Level.Application.Mediators.Cart.GetAll;

namespace Level.Application.Dto
{
    public class CartResponse
    {
        public int id { get; set; }
        public decimal total { get; set; }

        public static explicit operator CartResponse(GetAllResponse v)
        {
            return new CartResponse
            {
                id = v.id,
                total = v.total
            };
        }
    }
}
