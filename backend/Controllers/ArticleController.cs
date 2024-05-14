using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class ArticleContorller : ControllerBase
{
    private readonly IManagerRepository _manager;

    public ArticleContorller(IManagerRepository managerRepository)
    {
        _manager = managerRepository;
    }

    [HttpPost("/api/manager/addmaterial")]
    public IActionResult AddMaterial([FromBody] Material material)
    {
        _manager.AddMaterial(material);
        return Ok();
    }

    [HttpDelete("/api/manager/deletematerial")]
    public IActionResult DeleteMaterial([FromBody] int materialId)
    {
        _manager.DeleteMaterial(materialId);
        return Ok();
    }

    [HttpPost("/api/manager/editematerial")]
    public IActionResult EditMaterial([FromBody] EditMaterial material)
    {
        _manager.EditMaterial(material);
        return Ok();
    }

    [HttpGet("/api/manager/getallmaterial")]
    public IEnumerable<Material> GetMaterials()
    {
        return _manager.GetAllMaterials();
    }

    [HttpGet("/api/manager/getallfavorites")]
    public IEnumerable<Favorite> GetAllFavorite(int userId)
    {
        return _manager.GetAllFavorite(userId);
    }

    [HttpPost("/api/manager/addfavorite")]
    public IActionResult AddFavorite([FromBody] Favorite favorite)
    {
        _manager.AddFavoriteMaterial(favorite);
        return Ok();
    }

    [HttpDelete("/api/manager/deletefavorite")]
    public IActionResult DeleteFavorite(int materialId, int userId)
    {
        _manager.DeleteFavorite(materialId, userId);
        return Ok();
    }

    [HttpGet("/api/manager/getallrate")]
    public IEnumerable<Rate> GetAllReat()
    {
        return _manager.GetAllRates();
    }

    [HttpPut("/api/manager/rate")]
    public IActionResult AddRate([FromBody] Rate Rate)
    {
        _manager.AddRate(Rate);
        return Ok();
    }

    [HttpDelete("/api/manager/deleterate")]
    public IActionResult DeleteRate(int RateId, int UserId)
    {
        _manager.DeleteRate(RateId, UserId);
        return Ok();
    }
}