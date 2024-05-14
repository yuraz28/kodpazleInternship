public class UserRepository : IUserRepository
{
    private readonly LibraryContext _context;

    public UserRepository(LibraryContext user)
    {
        _context = user;
    }

    public void AddUser(User user)
    {
        if(_context.Users.Any(u => u.Email == user.Email))
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
            Console.WriteLine($"Email of {user.Login} is valid.");
            _context.Users.Add(user); 
            _context.SaveChanges();
        }
        else
        {
            return;
        }
    }

    public void DeleteUser(int id)
    {
        _context.Users.Where(t => t.ID == id).ToList().ForEach(t => _context.Users.Remove(t));
        _context.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(int id)
    {
        return _context.Users.FirstOrDefault(t => t.ID == id);
    }

    public bool VerifyUser(User user)
    {
        User verify_context = _context.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
        if(verify_context != null)
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