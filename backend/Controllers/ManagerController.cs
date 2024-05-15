using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  


public class ManagerContorller : ControllerBase
{
    private readonly IManagerRepository _manager;
    //private readonly IUserRepository _userRepository;

    public ManagerContorller(IManagerRepository managerRepository)
    {
        _manager = managerRepository;
        //_userRepository = userRepository;
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
    public IActionResult Register([FromBody] AddingUser us)
    {
        var user = new User("Участник", us.Name, us.Email, us.Password, [0]);
        _manager.AddUser(user);
        return Ok();
    }

    public class AddingUser
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    [HttpDelete("/api/user/delete")]
    public IActionResult DeleteUser(int IdUser)
    {
        _manager.DeleteUser(IdUser);
        return Ok();
    }

    [HttpPost("/api/user/auth")]
    public IActionResult Auth([FromBody] UserK u)
    {
        User user = _manager.GetUser(u.Login);
        if (user !=  null) // Проверяем, найден ли пользователь
        {
            if (_manager.AuthUser(user, u.Password) == "Пользователь авторизован") 
            {
                return Ok();
            } 
            else if (_manager.AuthUser(user, u.Password) == "Неверный пароль") 
            {
                return BadRequest("Неверный пароль"); // Возвращаем текстовое сообщение "Неверный пароль"
            } 
            else
            {
                return BadRequest("Неверное имя или неверный пароль");
            }
        }
        else 
        {
           return NotFound("Пользователь не найден");
        }
    }

    public class UserK
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }


    [HttpGet("api/user/getrole")]
    public IActionResult GetRoleUser(string login)
    {
        if (_manager.GetRole(login) != null)
        {
            return Ok(_manager.GetRole(login));
        }
        else 
        {
            return NotFound("Пользователь не найден");
        }
    }
}