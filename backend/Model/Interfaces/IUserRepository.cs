public interface IUserRepository
{
    void Add(User user);
    void Delete(int id);
    List<User> GetAll();
    User Get(int id);
    bool Authorization(string login, string password);
} 