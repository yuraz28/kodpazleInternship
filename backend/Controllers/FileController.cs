using Microsoft.AspNetCore.Mvc;

[ApiController]
public class FileController : ControllerBase
{
    private readonly IFileRepository _fileRepository;

    public FileController(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }

    [HttpGet("/api/fileall")]
    public async Task<List<FileRecord>> AllFile()
    {
        return await _fileRepository.GetAllAsync();
    }

    [HttpGet("/api/file")]
    public async Task<ActionResult<IEnumerable<string>>> GetFilesByID(int articleID)
    {
        var fileRecords = await _fileRepository.GetByArticleIdAsync(articleID);
        if (!fileRecords.Any())
        {
            return NotFound($"Статья не была найдена");
        }
        var filePaths = fileRecords.Select(fr => fr.FilePath).ToList();
        return Ok(filePaths);
    }

    [HttpPost("/api/file")]
    public async Task<IActionResult> UploadFile(IFormFile file, int articleID)
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
        catch
        {
            return BadRequest($"Файл с таким именем уже существует: {file.FileName}");
        }

        var fileRecord = new FileRecord {FilePath = filePath, ArticleId = articleID};
        await _fileRepository.AddAsync(fileRecord);

        return Ok(new {Message = "Файл успешно загружен и сохранен.", FilePath = filePath, ArticleId = articleID});
    }

    [HttpDelete("/api/file")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (await _fileRepository.DeleteFileAsync(id)) return Ok();
        return NotFound();
    }
}