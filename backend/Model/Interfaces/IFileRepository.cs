using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFileRepository
{
    Task AddAsync(FileRecord fileRecord);
    Task<bool> DeleteFileAsync(int id);
    Task<List<FileRecord>> GetAllAsync();
    Task<IEnumerable<FileRecord>> GetByArticleIdAsync(int articleId); // Новый метод
}