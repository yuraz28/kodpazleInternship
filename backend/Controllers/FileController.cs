using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    private readonly IFileRepository _fileRecordRepository;

    public FileController(IFileRepository fileRecordRepository)
    {
        _fileRecordRepository = fileRecordRepository;
    }

    [HttpGet("/api/fileall")]
    public async Task<List<FileRecord>> AllFile()
    {
        return await _fileRecordRepository.GetAllAsync();
    }

    [HttpGet("/api/file")]
    public async Task<ActionResult<IEnumerable<string>>> GetFilesByID(int articleId)
    {
        var fileRecords = await _fileRecordRepository.GetByArticleIdAsync(articleId);
        if (!fileRecords.Any())
        {
            return NotFound($"Статья не была найдена");
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

    [HttpDelete("/api/file")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (await _fileRecordRepository.DeleteFileAsync(id)) return Ok();
        return NotFound();
    }
}