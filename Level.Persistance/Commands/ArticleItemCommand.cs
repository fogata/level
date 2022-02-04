using Level.Domain.Entities;
using Level.Domain.Repositories;
using System.Threading.Tasks;

namespace Level.Persistance.Commands
{
    public class ArticleItemCommand : IArticleItemRepository
    {
        private readonly LevelDbContext context;

        public ArticleItemCommand(LevelDbContext context)
        {
            this.context = context;
        }
        public void Delete(ArticleItem value)
        {
            context.ArticleItems.Remove(value);
        }

        public async Task InsertAsync(ArticleItem value)
        {
            await context.ArticleItems.AddAsync(value);
        }
    }
}
