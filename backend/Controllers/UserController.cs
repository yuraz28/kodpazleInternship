using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class UserController : ControllerBase
{
    private readonly IUserRepository _user;

    public UserController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet("/api/user")]
    public async Task<IEnumerable<User>> GetAll()
    {
        var users = await _user.GetAll();
        return users;
    }

    [HttpPost("/api/user")]
    public async Task<IActionResult> Add([FromBody] User user)
    {
        _user.Add(user);
        return Ok();
    }

    [HttpDelete("/api/user")]
    public async Task<IActionResult> Delete([FromBody] int id)
    {

        _user.Delete(id);
        return Ok("Пользователь удалён");
    }

    [HttpPost("/api/authorization")]
    public async Task<IActionResult> Authorization(string login, string password)
    {
        var flag = await _user.Authorization(login, password);
        if (flag) return Ok("Авторизирован");
        return NotFound("Не авторизирован");
    }
}