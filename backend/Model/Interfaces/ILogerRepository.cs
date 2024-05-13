public interface ILogerRepository
{
    void AddLoger(Loger loger);
    Loger GetLogByUserID(int id);
    List<Loger> GetAllLoger();
    Loger GetLoger(int id);
    List<Loger> GetLogerByAction(string action);
}
