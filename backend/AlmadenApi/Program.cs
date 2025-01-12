using AlmadenApi.Data;
using AlmadenApi.Data.Interface;
using AlmadenApi.Data.Repository;
using AlmadenApi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IUserRepository,UserRepository>();
builder.Services.AddTransient<IFolderRepository,FolderRepository>();
builder.Services.AddTransient<ILastPassCardRepository,LastPassCardRepository>();

    
var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.Run();



