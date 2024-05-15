﻿public class ManagerRepository : IManagerRepository
{
    private readonly LibraryContext _context;

    public ManagerRepository(LibraryContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        if(_context.Users.Any(u => u.Email == user.Email))
        {
            Console.WriteLine("Account with email " + user.Email + " already exists."); 
            return;
        } 

        string [] domens = new string[3] {"ru", "com", "com"};

        _context.Users.Add(user);
        _context.SaveChanges();

        // if(user.Email.Contains("@") 
        //     && user.Email.Contains(".")
        //     && user.Email.Length > 5
        //     && user.Email.Length < 50
        //     && domens.Any(d => user.Email.Split('.').Last().Contains(d)))
        // {
        //     Console.WriteLine($"Email of {user.Name} is valid.");
        //     _context.Users.Add(user); 
        //     _context.SaveChanges();
        // }
        // else
        // {
        //     return;
        // }
    }

    // public void DeleteUser(int id)
    // {
    //     _context.Users.Where(t => t.ID == id).ToList().ForEach(t => _context.Users.Remove(t));
    //     _context.SaveChanges();
    // }

    public bool DeleteUser(int id)
    {
        var u = _context.Users.FirstOrDefault(t => t.ID == id);
        if (u != null)
        {
            _context.Users.Where(t => t.ID == id).ToList().ForEach(t => _context.Users.Remove(t));
            _context.SaveChanges();
            return true;
        }

        return false;

    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User GetUser(int id)
    {
        return _context.Users.FirstOrDefault(t => t.ID == id);
    }

    public User GetUser(string login, string password)
    {
        return _context.Users.FirstOrDefault(t => t.Name == login && t.Password == password);
    }

    public void AddMaterial(Material material)
    {
        _context.Materials.Add(material);
        _context.SaveChanges();
    }

    public void DeleteMaterial(int id)
    {
        _context.Materials.Where(t => t.ID == id).ToList().ForEach(t => _context.Materials.Remove(t));
        _context.SaveChanges();
    }

    public List<Material> GetAllMaterials()
    {
        return _context.Materials.ToList();
    }

    public Material GetMaterial(int id)
    {
        return _context.Materials.FirstOrDefault(t => t.ID == id);
    }

    public void AddFavoriteMaterial(int materialId, int userId)
    {
        
            var entity = _context.Users.FirstOrDefault(item => item.ID == userId);

            if (entity != null)
            {
                entity.FavouritesMaterials.Add(materialId);
                _context.SaveChanges();
            }
        
    }

    public void EditMaterial(EditMaterial material)
    {
        
            var entity = _context.Materials.FirstOrDefault(item => item.ID == material.ID);

            if (entity != null)
            {
                if (material.Name != null) entity.Name = material.Name;
                if (material.Information != null) entity.Information = material.Information;
                if (material.UrlImage != null) entity.UrlImage = material.UrlImage;
                _context.SaveChanges();
            }
        
    }

    public void AddRate(Rate rateMail)
    {
        _context.Rates.Add(rateMail);
    }

public bool AuthUser(User user)
{
    if (user == null || string.IsNullOrEmpty(user.Name))
    {
        Console.WriteLine("User object is null or username is empty.");
        return false;
    }

    User foundUser = _context.Users.FirstOrDefault(u => u.Name == user.Name);

    if(foundUser!= null)
    {
        if (string.IsNullOrEmpty(user.Password) || user.Password!= foundUser.Password)
        {
            Console.WriteLine("Account not verified due to incorrect password.");
            return false;
        }
        else
        {
            Console.WriteLine("Account verified.");
            return true;    
        }
    }
    else 
    {
        Console.WriteLine("Account not verified because user does not exist.");
        return false; 
    }  
  }
}