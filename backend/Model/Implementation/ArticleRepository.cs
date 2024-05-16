using Microsoft.EntityFrameworkCore;

public class ArticleRepository : IArticleRepository
{
    private readonly LibraryContext _context;

    public ArticleRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task Add(Article material)
    {
        await _context.Articles.AddAsync(material);
        _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        if (await _context.Articles.FirstOrDefaultAsync(x => x.ID == id) != null)
        {
            _context.Articles.Remove(await _context.Articles.SingleOrDefaultAsync(x => x.ID == id));
            _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<Article>> GetAll()
    {
        var articles = await _context.Articles.ToListAsync();
        return articles;
    }

    public async Task<Article> Get(int id)
    {
        var article = await _context.Articles.FirstOrDefaultAsync(t => t.ID == id);
        return article;
    }

    public async Task<List<Favorite>> GetAllFavorite(int userId)
    {
        var favorites = await _context.Favorites.ToListAsync();
        return favorites;
    }

    public async Task AddFavorite(Favorite favorite)
    {
            await _context.Favorites.AddAsync(favorite);
            _context.SaveChangesAsync();
    }

    public async Task DeleteFavorite(int materialID, int userID)
    {
        _context.Favorites.Remove(await _context.Favorites.SingleOrDefaultAsync(x => x.UserID == userID && x.MaterialID == materialID));
        _context.SaveChangesAsync();
    }

    public async Task EditArticle(EditArticle material)
    {
            var entity = _context.Articles.FirstOrDefault(item => item.ID == material.ID);

            if (entity != null)
            {
                if (material.Name != null) entity.Name = material.Name;
                if (material.Information != null) entity.Information = material.Information;
                // if (material.UrlImage != null) entity.UrlImage = material.UrlImage;
                _context.SaveChangesAsync();
            }
    }

    public async Task AddRate(Rate rate)
    {
        await _context.Rates.AddAsync(rate);
        _context.SaveChangesAsync();
        // var rates = _context.Rates.Where(x => x.ArticleID == rateMail.ArticleID);
        // var entity = _context.Articles.FirstOrDefault(item => item.ID == rateMail.ArticleID);
        // entity.Rateing = rates.Sum(IEnumerable<int>);
    }

    public async Task DeleteRate(int articleId, int userId)
    {
        _context.Rates.Remove(await _context.Rates.SingleOrDefaultAsync(x => x.UserID == userId && x.ArticleID == articleId));
        _context.SaveChangesAsync();
    }

    public async Task<List<Rate>> GetAllRates()
    {
        var rates = await _context.Rates.ToListAsync();
        return rates;
    }
}
