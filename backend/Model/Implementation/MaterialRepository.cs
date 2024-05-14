public class MaterialRepository : IMaterialRepository
{
    private readonly LibraryContext _context;

    public MaterialRepository(LibraryContext material)
    {
        _context = material;
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

    public void AddFavoriteMaterial(Favorite favorite)
    {
            _context.Add(favorite);
            _context.SaveChanges();
    }

    public List<Favorite> GetAllFavorite(int userId)
    {
        return _context.Favorites.ToList();
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