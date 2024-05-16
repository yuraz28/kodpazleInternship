public interface IArticleRepository
{
    Task Add(Article material);
    Task<bool> Delete(int id);
    Task<List<Article>> GetAll();
    Task<Article> Get(int id);
    Task<List<Favorite>> GetAllFavorite(int userId);
    Task AddFavorite(Favorite favorite);
    Task DeleteFavorite(int materialid, int userId);
    Task EditArticle(EditArticle material);
    Task AddRate(Rate rateMail);
    Task DeleteRate(int articleId, int userId);
    Task<List<Rate>> GetAllRates();
}
