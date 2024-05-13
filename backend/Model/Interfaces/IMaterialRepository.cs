public interface IMaterialRepository
{
    void AddMaterial(Material material);
    void DeleteMaterial(int id);
    List<Material> GetAllMaterials();
    Material GetMaterial(int id);
}