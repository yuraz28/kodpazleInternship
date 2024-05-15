using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly LibraryContext _context;

    public UserRepository(LibraryContext user)
    {
        _context = user;
    }

    public async Task Add(User user)
    {
        var flag = _context.Users.AnyAsync(u => u.Login == user.Login);
        if(flag.Result)
        {
            Console.WriteLine("Account with login " + user.Login + " already exists."); 
            return;
        } 
        await _context.Users.AddAsync(user); 
        _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        _context.Users.Remove(await _context.Users.SingleOrDefaultAsync(x => x.ID == id));
        _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> Get(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(t => t.ID == id);
        return user;
    }

    public async Task<bool> Authorization(string login, string password)
    {
        User verify_context = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        if(verify_context != null) return true;
        return false;
    }
}