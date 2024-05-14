public interface IArticleRepository
{
    void AddMaterial(Material material);
    void DeleteMaterial(int id);
    List<Material> GetAllMaterials();
    Material GetMaterial(int id);
    List<Favorite> GetAllFavorite(int userId);
    void AddFavoriteMaterial(Favorite favorite);
    void DeleteFavorite(int materialid, int userId);
    void EditMaterial(EditMaterial material);
    void AddRate(Rate rateMail);
    void DeleteRate(int rateMail, int userId);
    public List<Rate> GetAllRates();
}
