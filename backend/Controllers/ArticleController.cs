using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class ArticleContorller : ControllerBase
{
    private readonly IArticleRepository _article;

    public ArticleContorller(IArticleRepository article)
    {
        _article = article;
    }

    [HttpGet("/api/article")]
    public async Task<IEnumerable<Article>> GetAll()
    {
        var articles = await _article.GetAll();
        return articles;
    }

    [HttpPost("/api/article")]
    public async Task<IActionResult> Add([FromBody] Article article)
    {
        _article.Add(article);
        return Ok();
    }

    [HttpDelete("/api/article")]
    public async Task<IActionResult> Delete([FromBody] int articleId)
    {
        if(await _article.Delete(articleId)) return Ok($"Статья с ID={articleId} была удалена.");
        return NotFound("Статья с ID={articleId} не была найдена.");

    }

    [HttpPut("/api/article")]
    public async Task<IActionResult> Edit([FromBody] EditArticle article)
    {
        await _article.EditArticle(article);
        return Ok("Статья была отредактированна.");
    }

    [HttpGet("/api/favorites")]
    public async Task<IEnumerable<Favorite>> GetAllFavorite(int userId)
    {
        var favorite = await _article.GetAllFavorite(userId);
        return favorite;
    }

    [HttpPost("/api/favorites")]
    public async Task<IActionResult> AddFavorite([FromBody] Favorite favorite)
    {
        await _article.AddFavorite(favorite);
        return Ok("Статья была добавленна в избранное.");
    }

    [HttpDelete("/api/favorites")]
    public async Task<IActionResult> DeleteFavorite(int materialId, int userId)
    {
        await _article.DeleteFavorite(materialId, userId);
        return Ok("Статья была удалена из избранного.");
    }

    [HttpGet("/api/rate")]
    public async Task<IEnumerable<Rate>> GetAllReat()
    {
        var rate = await _article.GetAllRates();
        return rate;
    }

    [HttpPost("/api/rate")]
    public async Task<IActionResult> AddRate([FromBody] Rate Rate)
    {
        await _article.AddRate(Rate);
        return Ok("Статье была дана оценка.");
    }

    [HttpDelete("/api/rate")]
    public async Task<IActionResult> DeleteRate(int articleId, int UserId)
    {
        await _article.DeleteRate(articleId, UserId);
        return Ok();
    }
    
}