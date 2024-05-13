namespace WebApplication1.Controllers;

// Контроллер для работы со статьями
public class ArticleController : Controller
{
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }

    public IActionResult AddArticle(Article article)
    {
        _articleService.AddArticle(article);
        return Ok();
    }

    public IActionResult DeleteArticle(int id)
    {
        _articleService.DeleteArticle(id);
        return Ok();
    }

    public IActionResult GetAllArticles()
    {
        var articles = _articleService.GetAllArticles();
        return View(articles);
    }

    public IActionResult GetArticleById(int id)
    {
        var article = _articleService.GetArticleById(id);
        return View(article);
    }
}
