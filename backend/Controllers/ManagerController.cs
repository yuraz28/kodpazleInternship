using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class ManagerContorller : ControllerBase
{
    private readonly IManagerRepository _manager;
    private readonly IUserRepository _userRepository;

    public ManagerContorller(IManagerRepository managerRepository, IUserRepository userRepository)
    {
        _manager = managerRepository;
        _userRepository = userRepository;
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

    [HttpPost("/api/manager/addfavorite")]
    public IActionResult AddFavorite(int material, int user)
    {
        _manager.AddFavoriteMaterial(material, user);
        return Ok();
    }

    [HttpPut("/api/manager/rate")]
    public IActionResult AddRate([FromBody] Rate Rate)
    {
        _manager.AddRate(Rate);
        return Ok();
    }

    [HttpGet("/api/manager/getalluser")]
    public List<User> GetAllUsers()
    {
        return _manager.GetAllUsers();
    }

    [HttpPost("/api/user/register")]
    public IActionResult Register([FromBody] User user)
    {
        _userRepository.AddUser(user);
        return Ok();
    }

    [HttpDelete("/api/user/delete")]
    public IActionResult DeleteUser(int IdUser)
    {
        var flag = _userRepository.DeleteUser(IdUser);
        if (flag)
        {
            return Ok();
        }
        return NotFound();
    }
}