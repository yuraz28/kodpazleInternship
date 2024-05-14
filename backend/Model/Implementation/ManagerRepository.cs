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

        if(user.Email.Contains("@") 
            && user.Email.Contains(".")
            && user.Email.Length > 5
            && user.Email.Length < 50
            && domens.Any(d => user.Email.Split('.').Last().Contains(d)))
        {
            Console.WriteLine($"Email of {user.Name} is valid.");
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

    public List<Favorite> GetAllFavorite(int userId)
    {
        return _context.Favorites.ToList();
    }

    public void AddFavoriteMaterial(Favorite favorite)
    {
            _context.Add(favorite);
    }

    public void DeleteFavorite(int materialid, int userId)
    {
        _context.Favorites.Where(t => t.MaterialId == materialid && t.UserID == userId).ToList().ForEach(t => _context.Favorites.Remove(t));
        _context.SaveChanges();
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

    public void DeleteRate(int rateMail, int userId)
    {
        _context.Rates.Where(t => t.MaterialID == rateMail && t.UserID == userId).ToList().ForEach(t => _context.Rates.Remove(t));
        _context.SaveChanges(); 
    }

    public List<Rate> GetAllRates()
    {
        return _context.Rates.ToList();
    }
}