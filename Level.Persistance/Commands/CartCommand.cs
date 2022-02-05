using Level.Domain.Entities;
using Level.Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Level.Persistance.Commands
{
    public class CartCommand : ICartRepository
    {
        private readonly LevelDbContext context;

        public CartCommand(LevelDbContext context)
        {
            this.context = context;
        }
        public void Delete(Cart value)
        {
            context.Carts.Remove(value);
        }

        public async Task<Cart> InsertAsync(Cart value)
        {
            EntityEntry<Cart> modelResponse;

            if (!value.id.Equals(0))
            {

                var model = await context.Carts.FindAsync(value.id);
                model.quantity = value.quantity;
                modelResponse = context.Carts.Update(model);
                
            }
            else
            {
                modelResponse = await context.Carts.AddAsync(value);
            }

            return modelResponse.Entity;

        }
    }
}
