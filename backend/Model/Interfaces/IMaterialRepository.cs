public interface IMaterialRepository
{
    void AddMaterial(Material material);
    void DeleteMaterial(int id);
    List<Material> GetAllMaterials();
    Material GetMaterial(int id);
    void AddFavoriteMaterial(Favorite favorite);
    List<Favorite> GetAllFavorite(int userId);
    void DeleteFavorite(int materialid, int userId);
    void EditMaterial(EditMaterial material);
    void AddRate(Rate rateMail);
    void DeleteRate(int rateMail, int userId);
    public List<Rate> GetAllRates();
}