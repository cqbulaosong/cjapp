using CjApp.IRepository;
using CjApp.IService;
using CjApp.Model;

namespace CjApp.Service;

public class ArticleService : BaseService<Article>, IArticleService
{
    private readonly IArticleRepository _iArticleRepository;
    public ArticleService(IArticleRepository iArticleRepository)
    {
        _iBaseRepository = iArticleRepository;
        _iArticleRepository = iArticleRepository;
    }
}