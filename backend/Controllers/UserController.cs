namespace WebApplication1.Controllers;

// Контроллер для работы с пользователями
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult CreateUser(User user)
    {
        _userService.CreateUser(user);
        return Ok();
    }

    public IActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);
        return Ok();
    }

    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return View(users);
    }

    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        return View(user);
    }
}
