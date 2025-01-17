using AspBlog.Data;
using AspBlog.Models;
using FirstWeb_MVC.Interfaces;

namespace FirstWeb_MVC.Repositories
{
    public class ArticleRepository(ApplicationDbContext dbContext) : BaseRepository<Article>(dbContext), IArticleRepository
    {
    }
}
