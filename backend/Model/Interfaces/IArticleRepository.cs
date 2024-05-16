public interface IArticleRepository
{
    Task Add(Article material);
    Task<bool> Delete(int id);
    Task<List<Article>> GetAll();
    Task<Article> Get(int id);
    Task<List<Favorite>> GetAllFavorite(int userId);
    Task AddFavorite(Favorite favorite);
    Task DeleteFavorite(int materialID, int userID);
    Task EditArticle(EditArticle material);
    Task AddRate(Rate rate);
    Task DeleteRate(int articleID, int userID);
    Task<List<Rate>> GetAllRates();
}
