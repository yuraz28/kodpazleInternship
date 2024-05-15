using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => 
{ 
    options.AddDefaultPolicy(builder => 
    { 
        builder.WithOrigins("http://192.168.161.232") // Замените на ваш домен 
              .AllowAnyHeader() 
              .AllowAnyMethod() 
              .AllowCredentials(); 
    }); 
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IUserRepository userRepository = new UserRepository(libraryContext);

    return userRepository;
});

builder.Services.AddSingleton<IArticleRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IArticleRepository articleRepository = new ArticleRepository(libraryContext);

    return articleRepository;
});

builder.Services.AddSingleton<IUserRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IUserRepository userRepository = new UserRepository(libraryContext);

    return userRepository;
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

app.MapControllers();

app.UseCors();

app.Run();
