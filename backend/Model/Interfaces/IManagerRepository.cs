public interface IManagerRepository
{
    void Add(Material article);
    void Delete(int id);
    List<Material> GetAll();
    Material Get(int id);
    List<Favorite> GetAllFavorite(int userId);
    void AddFavorite(Favorite favorite);
    void DeleteFavorite(int materialid, int userId);
    void EditMaterial(EditMaterial material);
    void AddRate(Rate rateMail);
    void DeleteRate(int rateMail, int userId);
    public List<Rate> GetAllRates();
}
