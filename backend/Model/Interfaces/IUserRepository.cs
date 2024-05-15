public interface IUserRepository
{
    void AddUser(User user);
    void DeleteUser(int id);
    List<User> GetAllUsers();
    User GetUser(int id);
    bool VerifyUser(User user);
} 