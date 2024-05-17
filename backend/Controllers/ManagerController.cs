using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  


public class ManagerContorller : ControllerBase
{
    private readonly IManagerRepository _manager;

    public ManagerContorller(IManagerRepository managerRepository)
    {
        _manager = managerRepository;
    }

    [HttpGet("/api/user/getalluser")]
    public List<User> GetAllUsers()
    {
        return _manager.GetAllUsers();
    }

    [HttpPost("/api/user/register")]
    public async Task<IActionResult> Register([FromBody] AddingUser us)
    {
        var user = new User("Участник", us.Name, us.Email, us.Password, [0]);
        var answer = await _manager.AddUser(user);
        if (answer == "Логин, почта или пароль не соответствуют требованиям") return BadRequest("Логин, почта или пароль не соответствуют требованиям");
        else if (answer == "Пользователь с такой почтой уже существует") return Unauthorized("Пользователь с такой почтой уже существует");
        else return Ok("Пользователь успешно добавлен");
    }

    public class AddingUser
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    [HttpDelete("/api/user/delete")]
    public async Task<IActionResult> DeleteUser(int IdUser)
    {
        await _manager.DeleteUser(IdUser);
        return Ok();
    }

    [HttpPost("/api/user/auth")]
    public async Task<IActionResult> Auth([FromBody] UserK u)
    {
        User user = await _manager.GetUser(u.Email);
        if (user !=  null)
        {
            if (await _manager.AuthUser(user, u.Password) == "Пользователь авторизован") 
            {
                return Ok();
            } 
            else if (await _manager.AuthUser(user, u.Password) == "Неверный пароль") 
            {
                return BadRequest("Неверный пароль"); 
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
        public string? Email { get; set; }
        public string? Password { get; set; }
    }


    [HttpGet("api/user/getrole")]
    public IActionResult GetRoleUser(string email)
    {
        if (_manager.GetRole(email) != null)
        {
            return Ok(_manager.GetRole(email));
        }
        else 
        {
            return NotFound("Пользователь не найден");
        }
    }

    [HttpPost("api/user/addpeople")]
    public async Task<IActionResult> AddPeople([FromBody] User user)
    {
        if (user !=  null)
        {
            if (await _manager.AuthUser(user, user.Password) == "Пользователь авторизован") 
            {
                return Ok();
            } 
            else if (await _manager.AuthUser(user, user.Password) == "Неверный пароль") 
            {
                return BadRequest("Неверный пароль"); 
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
}