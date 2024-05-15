using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;   


public class UserController : ControllerBase
{
    private readonly IUserRepository _context;

    public UserController(IUserRepository context)
    {
        _context = context;
    }

    [HttpGet("/api/user/getall")]
    public IEnumerable<User> GetAll()
    {
        return _context.GetAll();
    }

    [HttpPost("/api/user/add")]
    public IActionResult Add([FromBody] User user)
    {
        _context.Add(user);
        return Ok();
    }

    [HttpDelete("/api/user/delete")]
    public IActionResult Delete([FromBody] int id)
    {
        _context.Delete(id);
        return Ok();
    }

    [HttpPost("/api/user/authorization")]
    public IActionResult Authorization(string login, string password)
    {
        if (_context.Authorization(login, password)) return Ok("Авторизировани");
        return BadRequest("Не авторизировани");
    }
}