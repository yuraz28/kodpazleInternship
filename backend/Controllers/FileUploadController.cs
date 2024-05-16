using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using YourNamespace;
 // Импортируйте пространство имен для IFileRecordRepository

[Route("api/[controller]")]
[ApiController]
public class FileUploadController : ControllerBase
{
    private readonly IFileRecordRepository _fileRecordRepository;

    public FileUploadController(IFileRecordRepository fileRecordRepository)
    {
        _fileRecordRepository = fileRecordRepository;
    }

    [HttpGet("/api/file")]
    public async Task<ActionResult<IEnumerable<string>>> GetFilesForArticle(int articleId)
    {
        var fileRecords = await _fileRecordRepository.GetByArticleIdAsync(articleId);
        if (!fileRecords.Any())
        {
            return NotFound($"No files found for article with ID {articleId}.");
        }

        var filePaths = fileRecords.Select(fr => fr.FilePath).ToList();
        return Ok(filePaths);
    }

    [HttpPost("/api/file")]
    public async Task<IActionResult> UploadFile(IFormFile file, int articleId)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Файл не был предоставлен.");

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "File", file.FileName);

        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
        catch (IOException ex)
        {
            return BadRequest($"Файл с таким именем уже существует: {file.FileName}");
        }

        var fileRecord = new FileRecord { FilePath = filePath, ArticleId = articleId };
        await _fileRecordRepository.AddAsync(fileRecord);

        return Ok(new { Message = "Файл успешно загружен и сохранен.", FilePath = filePath, ArticleId = articleId });
    }
}