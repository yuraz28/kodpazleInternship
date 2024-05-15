public class ArticleRepository : IArticleRepository
{
    private readonly LibraryContext _context;

    public ArticleRepository(LibraryContext context)
    {
        _context = context;
    }

    public void Add(Article material)
    {
        _context.Articles.Add(material);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Articles.Where(t => t.ID == id).ToList().ForEach(t => _context.Articles.Remove(t));
        _context.SaveChanges();
    }

    public List<Article> GetAll()
    {
        return _context.Articles.ToList();
    }

    public Article Get(int id)
    {
        return _context.Articles.FirstOrDefault(t => t.ID == id);
    }

    public List<Favorite> GetAllFavorite(int userId)
    {
        return _context.Favorites.ToList();
    }

    public void AddFavorite(Favorite favorite)
    {
            _context.Add(favorite);
    }

    public void DeleteFavorite(int materialid, int userId)
    {
        _context.Favorites.Where(t => t.MaterialId == materialid && t.UserID == userId).ToList().ForEach(t => _context.Favorites.Remove(t));
        _context.SaveChanges();
    }

    public void EditArticle(EditArticle material)
    {
            var entity = _context.Articles.FirstOrDefault(item => item.ID == material.ID);

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
        _context.Rates.Where(t => t.ArticleID == rateMail && t.UserID == userId).ToList().ForEach(t => _context.Rates.Remove(t));
        _context.SaveChanges(); 
    }

    public List<Rate> GetAllRates()
    {
        return _context.Rates.ToList();
    }
}
