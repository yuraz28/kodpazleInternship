public interface IArticleRepository
{
    void Add(Article material);
    void Delete(int id);
    List<Article> GetAll();
    Article Get(int id);
    List<Favorite> GetAllFavorite(int userId);
    void AddFavorite(Favorite favorite);
    void DeleteFavorite(int materialid, int userId);
    void EditArticle(EditArticle material);
    void AddRate(Rate rateMail);
    void DeleteRate(int rateMail, int userId);
    public List<Rate> GetAllRates();
}
