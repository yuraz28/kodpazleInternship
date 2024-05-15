public interface IMaterialRepository
{
    void AddMaterial(Material material);
    void DeleteMaterial(int id);
    List<Material> GetAllMaterials();
    Material GetMaterial(int id);
    void AddFavoriteMaterial(int materialId, int userId);
    void EditMaterial(EditMaterial material);
    void AddRate(Rate rateMail);
}