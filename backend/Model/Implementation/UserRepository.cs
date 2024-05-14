using Microsoft.AspNetCore.Http.HttpResults;

public class UserRepository : IUserRepository
{
    private readonly LibraryContext _user;

    public UserRepository(LibraryContext user)
    {
        _user = user;
    }

    public void AddUser(User user)
    {
        if(_user.Users.Any(u => u.Email == user.Email))
        {
            Console.WriteLine("Account with email " + user.Email + " already exists."); 
            return;
        } 

        string [] domens = new string[3] {"ru", "com", "com"};

        if(user.Email.Contains("@") 
            && user.Email.Contains(".")
            && user.Email.Length > 5
            && user.Email.Length < 50
            && domens.Any(d => user.Email.Split('.').Last().Contains(d)))
        {
            Console.WriteLine($"Email of {user.Name} is valid.");
            _user.Users.Add(user); 
            _user.SaveChanges();
        }
        else
        {
            return;
        }
    }

    public bool DeleteUser(int id)
    {
        var u = _user.Users.FirstOrDefault(t => t.ID == id);
        if (u != null)
        {
            _user.Users.Where(t => t.ID == id).ToList().ForEach(t => _user.Users.Remove(t));
            _user.SaveChanges();
            return true;
        }

        return false;

    }

    public List<User> GetAllUsers()
    {
        return _user.Users.ToList();
    }

    public User GetUser(int id)
    {
        return _user.Users.FirstOrDefault(t => t.ID == id);
    }

    public bool VerifyUser(User user)
    {
        User verify_user = _user.Users.FirstOrDefault(u => u.Name == user.Email && u.Password == user.Password);
        if(verify_user != null)
        {
            Console.WriteLine("Account verified.");
            return true;    
        }
        else 
        {
            Console.WriteLine("Account not verified."); 
            return false; 
        }  
    }
}