using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class UserContrller : ControllerBase
{
    private readonly IMaterialRepository _materialRepository;

    public UserContrller(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    [HttpGet("/api/user/getallmaterial")]
    public IEnumerable<Material> GetMaterials()
    {
        return _materialRepository.GetAllMaterials();
    }

    [HttpPost("/api/user/addfavorite")]
    public IActionResult AddFavorite(int material, int user)
    {
        _materialRepository.AddFavoriteMaterial(material, user);
        return Ok();
    }

    [HttpPost("/api/user/rate")]
    public IActionResult AddRate([FromBody]RateMail Rate)
    {
        _materialRepository.AddRate(Rate);
        return Ok();
    }
}