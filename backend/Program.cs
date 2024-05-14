using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddSingleton<IMaterialRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IMaterialRepository materialRepository = new MaterialRepository(libraryContext);

    return materialRepository;
});

builder.Services.AddSingleton<IManagerRepository>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
    optionsBuilder.UseSqlite("Data Source=LibraryDataBase.db"); 
    var libraryContext = new LibraryContext(optionsBuilder.Options);
    libraryContext.Database.EnsureCreated(); 
    IManagerRepository materialRepository = new ManagerRepository(libraryContext);

    return materialRepository;
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

app.Run();
