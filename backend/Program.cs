using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddSingleton<IAccountManager>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<AccountContext>();
    optionsBuilder.UseSqlite("Data Source=AccountDataBase.db"); 
    var accountContext = new AccountContext(optionsBuilder.Options);
    accountContext.Database.EnsureCreated();  
    IAccountManager accountManager = new AccountManager(accountContext);

    return accountManager;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
