using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   
using Microsoft.AspNetCore.Identity;



public class UserController : ControllerBase
{
    private readonly IMaterialRepository _materialRepository;
    private readonly IUserRepository _userRepository;

    public UserController(IMaterialRepository materialRepository, IUserRepository userRepository)
    {
        _materialRepository = materialRepository;
        _userRepository = userRepository;
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
    public IActionResult AddRate([FromBody]Rate Rate)
    {
        _materialRepository.AddRate(Rate);
        return Ok();
    }

    [HttpPost("/api/user/auth")]
    public IActionResult Auth(string login, string password)
    {
        List<User> users = _userRepository.GetAllUsers();

        User us = users.FirstOrDefault(t => t.Name == login && t.Password == password);

        var flag = _userRepository.VerifyUser(us);
        if (flag) return Ok();
        return NotFound();
    }
}