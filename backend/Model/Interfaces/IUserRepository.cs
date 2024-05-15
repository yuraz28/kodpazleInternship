public interface IUserRepository
{
    Task Add(User user);
    Task Delete(int id);
    Task<List<User>> GetAll();
    Task<User> Get(int id);
    Task<bool> Authorization(string login, string password);
} 