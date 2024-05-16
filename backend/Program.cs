using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS for specific origins
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(builder =>
//     {
//         builder.WithOrigins("http://192.168.161.33:5050") // Allow your frontend origin
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });

builder.Services.AddCors(options => 
    { 
        options.AddPolicy("AllowSpecificOrigin", 
            builder => builder.WithOrigins("http://127.0.0.1:5500") 
                            .AllowAnyHeader() 
                            .AllowAnyMethod()); 
    }); 

// // Your existing service registrations
// builder.Services.AddSingleton<IMaterialRepository>(provider =>
// {
//     var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
//     optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
//     var libraryContext = new LibraryContext(optionsBuilder.Options);
//     libraryContext.Database.EnsureCreated(); 
//     IMaterialRepository materialRepository = new MaterialRepository(libraryContext);

//     return materialRepository;
// });

builder.Services.AddSingleton<IManagerRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IManagerRepository managerRepository = new ManagerRepository(libraryContext);

    return managerRepository;
});

builder.Services.AddSingleton<IFileRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<FileContext>();
    optionsBuilder.UseSqlite("Data Source=FileRecords.db"); 
    var fileContext = new FileContext(optionsBuilder.Options);
    fileContext.Database.EnsureCreated(); 
    IFileRepository fileRepository = new FileRepository(fileContext);

    return fileRepository;
});

builder.Services.AddSingleton<IArticleRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=ArticlesDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IArticleRepository articleRepository = new ArticleRepository(libraryContext);

    return articleRepository;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.MapControllers();

app.Run();