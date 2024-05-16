using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFileRecordRepository
{
    Task AddAsync(FileRecord fileRecord);
    Task<IEnumerable<FileRecord>> GetAllAsync();
    Task<IEnumerable<FileRecord>> GetByArticleIdAsync(int articleId); // Новый метод
}