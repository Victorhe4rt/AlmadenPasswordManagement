using AlmadenApi.Data;
using AlmadenApi.Data.Interface;
using AlmadenApi.Data.Repository;
using AlmadenApi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.SetIsOriginAllowed(origin => true)  
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



var enviromentDocker = new EnviromentDocker();
enviromentDocker.showAllEnvariment();


string connectionString = $"Server={enviromentDocker.DATABASE_HOST};" +  
                          $"Database={enviromentDocker.DATABASE_NAME};" +
                          $"User Id={enviromentDocker.DATABASE_USER};" +
                          $"Password={enviromentDocker.DATABASE_PASSWORD};" +
                          "TrustServerCertificate=True;";  

// string connectionString = $"Server=172.31.64.1,1433;" +  
//                           $"Database=AlmadenDB" +
//                           $"User Id=sa;" +
//                           $"Password=YourStrong!Passw0rd;" +
//                           "TrustServerCertificate=True;";  
                       

Console.WriteLine("\n \nConnection String: " + connectionString);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped);


builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IFolderRepository, FolderRepository>();
builder.Services.AddTransient<ILastPassCardRepository, LastPassCardRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); 
}

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();