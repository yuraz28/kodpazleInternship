using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class ArticleContorller : ControllerBase
{
    private readonly IArticleRepository _context;

    public ArticleContorller(IArticleRepository articleRepository)
    {
        _context = articleRepository;
    }

    [HttpGet("/api/manager/getallmaterial")]
    public IEnumerable<Article> GetMaterials()
    {
        return _context.GetAll();
    }

    [HttpPost("/api/manager/addmaterial")]
    public IActionResult Add([FromBody] Article article)
    {
        _context.Add(article);
        return Ok();
    }

    [HttpDelete("/api/manager/deletematerial")]
    public IActionResult DeleteMaterial([FromBody] int articleId)
    {
        _context.Delete(articleId);
        return Ok();
    }

    [HttpPut("/api/manager/editematerial")]
    public IActionResult EditMaterial([FromBody] EditArticle article)
    {
        _context.EditArticle(article);
        return Ok();
    }

    [HttpGet("/api/manager/getallfavorites")]
    public IEnumerable<Favorite> GetAllFavorite(int userId)
    {
        return _context.GetAllFavorite(userId);
    }

    [HttpPost("/api/manager/addfavorite")]
    public IActionResult AddFavorite([FromBody] Favorite favorite)
    {
        _context.AddFavorite(favorite);
        return Ok();
    }

    [HttpDelete("/api/manager/deletefavorite")]
    public IActionResult DeleteFavorite(int materialId, int userId)
    {
        _context.DeleteFavorite(materialId, userId);
        return Ok();
    }

    [HttpGet("/api/manager/getallrate")]
    public IEnumerable<Rate> GetAllReat()
    {
        return _context.GetAllRates();
    }

    [HttpPost("/api/manager/rate")]
    public IActionResult AddRate([FromBody] Rate Rate)
    {
        _context.AddRate(Rate);
        return Ok();
    }

    [HttpDelete("/api/manager/deleterate")]
    public IActionResult DeleteRate(int RateId, int UserId)
    {
        _context.DeleteRate(RateId, UserId);
        return Ok();
    }
}