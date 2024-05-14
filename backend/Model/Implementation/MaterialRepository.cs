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

    public void AddFavoriteMaterial(int materialId, int userId)
    {
        using (_context)
        {
            var entity = _context.Users.FirstOrDefault(item => item.ID == userId);

            if (entity != null)
            {
                entity.FavouritesMaterials.Add(materialId);
                _context.SaveChanges();
            }
        }
    }

    public void EditMaterial(EditMaterial material)
    {
        using (_context)
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
    }

    public void AddRate(RateMail rateMail)
    {
        using (_context)
        {
            var entity = _context.Materials.FirstOrDefault(item => item.ID == rateMail.MaterialID);

            if (entity != null)
            {
                entity.Rating.Add(rateMail.Rate);
                entity.RatingIdUser.Add(rateMail.UserID);
                _context.SaveChanges();
            }
        }
    }
}