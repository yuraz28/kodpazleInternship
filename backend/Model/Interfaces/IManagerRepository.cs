public interface IManagerRepository
{
    void AddUser(User user);
    bool DeleteUser(int id);
    List<User> GetAllUsers();
    User GetUser(int id);
    void AddMaterial(Material material);
    void DeleteMaterial(int id);
    List<Material> GetAllMaterials();
    Material GetMaterial(int id);
    void AddFavoriteMaterial(int materialId, int userId);
    void EditMaterial(EditMaterial material);
    void AddRate(Rate rateMail);
    bool AuthUser(User user);
    public User GetUser(string login, string password);
}
