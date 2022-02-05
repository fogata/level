using Level.Domain.Entities;
using Level.Domain.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Level.Persistance.Commands
{
    public class DiscountCommand : IDiscountRepository
    {
        private readonly LevelDbContext context;

        public DiscountCommand(LevelDbContext context)
        {
            this.context = context;
        }
        public void Delete(Discount value)
        {
            context.Discounts.Remove(value);
        }

        public async Task<Discount> InsertAsync(Discount value)
        {
            EntityEntry<Discount> modelResponse;

            if (!value.id.Equals(0))
            {

                var model = await context.Discounts.FindAsync(value.id);
                model.type = value.type;
                model.userId = value.userId;
                model.articleId = value.articleId;
                model.total = value.total;
                modelResponse = context.Discounts.Update(model);
                
            }
            else
            {
                modelResponse = await context.Discounts.AddAsync(value);
            }

            return modelResponse.Entity;

        }
    }
}
