using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class ManagerRepository : IManagerRepository
{
    private readonly LibraryContext _context;

    public ManagerRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<string> AddUser(User user)
    {
        if(_context.Users.Any(u => u.Email == user.Email))
        {
            return "Пользователь с такой почтой уже существует";
        } 

        string [] domens = new string[3] {"ru", "com", "com"};

        if(user.Email.Contains("@") 
            && user.Email.Contains(".")
            && user.Email.Length > 5
            && user.Email.Length < 50
            && domens.Any(d => user.Email.Split('.').Last().Contains(d)))
        {
            await _context.Users.AddAsync(user); 
            await _context.SaveChangesAsync();
            return "Пользователь добавлен";
        }
        else
        {
            return "Логин, почта или пароль не соответствуют требованиям";
        }
    }

    public async Task<bool> DeleteUser(int id)
    {
        var u = _context.Users.FirstOrDefault(t => t.ID == id);
        if (u != null)
        {
            _context.Users.Where(t => t.ID == id).ToList().ForEach(t => _context.Users.Remove(t));
            await _context.SaveChangesAsync();
            return true;
        }

        return false;

    }

    

    public List<User> GetAllUsers()
    {
        return _context.Users.Where(t => t.Role == "Участник").ToList();
    }

    public Task<User> GetUser(int id)
    {
        return _context.Users.FirstOrDefaultAsync(t => t.ID == id);
    }

    public Task<User> GetUser(string email)
    {
        return _context.Users.FirstOrDefaultAsync(t => t.Email == email);
    }

    // public void AddRate(Rate rateMail)
    // {
    //     _context.Rates.AddAsync(rateMail);
    // }

public async Task<string> AuthUser(User user, string pass)
{
    if (user == null || string.IsNullOrEmpty(user.Name))
    {
        //Console.WriteLine("User object is null or username is empty.");
        return "User null";
    }

    User foundUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name);
    if(foundUser != null)
    {
        if (user.Password != pass)
        {
            //Console.WriteLine("Account not verified due to incorrect password.");
            return "Неверный пароль";
        }
        if (user.Name == foundUser.Name && user.Password == pass)
        {
            //Console.WriteLine("Account verified.");
            return "Пользователь авторизован";    
        }
        else 
        {
            return "";
        }
    }
    else 
    {
        //Console.WriteLine("Account not verified because user does not exist.");
        return "Пользователь не найден"; 
    }  
  }

  public string GetRole(string login)
  {
    return _context.Users.FirstOrDefault(t => t.Email == login).Role;
  }

}