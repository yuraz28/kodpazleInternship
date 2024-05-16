public interface IManagerRepository
{
    string AddUser(User user);
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
    string AuthUser(User user, string pass);
    public User GetUser(string login);
    string GetRole(string login);
}
