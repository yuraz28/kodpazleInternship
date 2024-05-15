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
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500") // Allow your frontend origin
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Important if you're making requests with credentials
    });
});

// Your existing service registrations
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
    IManagerRepository managerRepository = new ManagerRepository(libraryContext);

    return managerRepository;
});

var app = builder.Build();

// Apply CORS policy globally
app.UseCors();

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