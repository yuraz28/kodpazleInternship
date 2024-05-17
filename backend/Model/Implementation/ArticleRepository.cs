﻿using Microsoft.EntityFrameworkCore;

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
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        if (await _context.Articles.FirstOrDefaultAsync(x => x.ID == id) != null)
        {
            _context.Articles.Remove(await _context.Articles.SingleOrDefaultAsync(x => x.ID == id));
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
    }

    public async Task DeleteFavorite(int materialID, int userID)
    {
        _context.Favorites.Remove(await _context.Favorites.SingleOrDefaultAsync(x => x.UserID == userID && x.MaterialID == materialID));
        await _context.SaveChangesAsync();
    }

    public async Task EditArticle(EditArticle material)
    {
            var entity = _context.Articles.FirstOrDefault(item => item.ID == material.ID);

            if (entity != null)
            {
                if (material.Name != null) entity.Name = material.Name;
                if (material.Information != null) entity.Information = material.Information;
                await _context.SaveChangesAsync();
            }
    }

    public async Task AddRate(Rate rate)
    {
        await _context.Rates.AddAsync(rate);
        await _context.SaveChangesAsync();
        List<Rate> rates = new List<Rate>();
        rates = _context.Rates.Where(x => x.ArticleID == rate.ArticleID).ToList();
        var entity = await _context.Articles.FirstOrDefaultAsync(item => item.ID == rate.ArticleID);
        entity.Rating = rates.Sum(x => x.ID) / rates.Count();
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRate(int articleId, int userId)
    {
        _context.Rates.Remove(await _context.Rates.SingleOrDefaultAsync(x => x.UserID == userId && x.ArticleID == articleId));
        await _context.SaveChangesAsync();
    }

    public async Task<List<Rate>> GetAllRates()
    {
        var rates = await _context.Rates.ToListAsync();
        return rates;
    }
}