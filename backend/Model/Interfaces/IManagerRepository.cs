public interface IManagerRepository
{
    Task<string> AddUser(User user);
    Task<bool> DeleteUser(int id);
    List<User> GetAllUsers();
    Task<User> GetUser(int id);
    // void AddMaterial(Material material);
    // void DeleteMaterial(int id);
    // List<Material> GetAllMaterials();
    // Material GetMaterial(int id);
    // void AddFavoriteMaterial(int materialId, int userId);
    // void EditMaterial(EditMaterial material);
    //void AddRate(Rate rateMail);
    Task<string> AuthUser(User user, string pass);
    public Task<User> GetUser(string login);
    string GetRole(string login);
}
