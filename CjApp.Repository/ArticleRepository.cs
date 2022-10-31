using CjApp.IRepository;
using CjApp.Model;
using SqlSugar;

namespace CjApp.Repository;

public class ArticleRepository : BaseRepository<Article>, IArticleRepository
{
    public ArticleRepository(ISqlSugarClient context = null) : base(context)
    {
    }
}