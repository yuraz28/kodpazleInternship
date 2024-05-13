using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


[ApiController]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public Controller(ILogger<Controller> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpPost("api/account/register")]
    public async Task<IActionResult> Registered([FromBody] User user)
    {
        var u = new IdentityUser { UserName = user.Login, Email = user.Email};
        var result = await _userManager.CreateAsync(u, user.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(u, false);
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("api/account/show")]
    public IActionResult Show()
    {
        return Ok(_userManager.Users);
    }

    [HttpPost("api/account/auth")]
    public async Task<IActionResult> Auth([FromBody] User account)
    {
        var result = await _signInManager.PasswordSignInAsync(account.Login, account.Password, false, false);
        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest();
    }
}