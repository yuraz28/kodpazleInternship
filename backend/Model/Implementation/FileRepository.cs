using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class FileRepository : IFileRepository
{
    private readonly FileContext _context;

    public FileRepository(FileContext context)
    {
        _context = context;
    }

    public async Task AddAsync(FileRecord fileRecord)
    {
        _context.FileRecords.Add(fileRecord);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteFileAsync(int id)
    {
       var fileRecord = await _context.FileRecords.FirstOrDefaultAsync(fr => fr.Id == id);
       if (fileRecord!= null)
        {
           // Удаление файла из системы
           File.Delete(fileRecord.FilePath);

           // Обновление записи в базе данных
           _context.FileRecords.Remove(fileRecord);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<List<FileRecord>> GetAllAsync()
    {
        return await _context.FileRecords.ToListAsync();
    }

    public async Task<IEnumerable<FileRecord>> GetByArticleIdAsync(int articleId)
    {
        return await _context.FileRecords.Where(fr => fr.ArticleId == articleId).ToListAsync();
    }
}