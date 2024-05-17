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

    public static string LoadTextFromFile(string filePath)
    {
        string result = string.Empty;

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                result = reader.ReadToEnd();
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Файл не найден: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }

        return result;
    }

    [HttpPost("/api/updateposttext")]
    public IActionResult UpdatePostText([FromBody] PostData postData)
    {
        try
        {
            // Путь к исходному файлу
            string originalFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Model/Data/defolt.html");

            // Чтение содержимого исходного файла
            string htmlContent = System.IO.File.ReadAllText(originalFilePath);

            // Изменение содержимого
            htmlContent = htmlContent.Replace("<!--Будет основной текст-->", $"{postData.NewText}");
            htmlContent = htmlContent.Replace("<!--Имя статьи-->", $"{postData.Name}");


            // Путь к новому файлу, основанный на данных от клиента
            string newFileName = $"{postData.Name}.html";
            string newPath = Path.Combine(Directory.GetCurrentDirectory(), "Model/Data/posts", newFileName);

            // Сохранение измененного содержимого в новом файле
            System.IO.File.WriteAllText(newPath, htmlContent);

            return Ok($"Файл '{newFileName}' успешно создан и сохранен.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    } 