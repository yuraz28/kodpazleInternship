public class MaterialRepository : IMaterialRepository
{
    private readonly LibraryContext _material;

    public MaterialRepository(LibraryContext material)
    {
        _material = material;
    }

    public void AddMaterial(Material material)
    {
        _material.Materials.Add(material);
        _material.SaveChanges();
    }

    public void DeleteMaterial(int id)
    {
        _material.Materials.Where(t => t.ID == id).ToList().ForEach(t => _material.Materials.Remove(t));
        _material.SaveChanges();
    }

    public List<Material> GetAllMaterials()
    {
        return _material.Materials.ToList();
    }

    public Material GetMaterial(int id)
    {
        return _material.Materials.FirstOrDefault(t => t.ID == id);
    }
}