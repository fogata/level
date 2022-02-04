using Level.Domain.Entities;
using System.Threading.Tasks;

namespace Level.Domain.Repositories
{
    public  interface IArticleItemRepository
    {
        Task InsertAsync(ArticleItem value);
        void Delete(ArticleItem value);
    }
}
