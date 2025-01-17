using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AlmadenApi.Data
{
  public class ApplicationDbContext : DbContext
    {
        public DbSet<LastPassCard> LastPassCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured) 
        //     {
        //         var configuration = new ConfigurationBuilder()
        //             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //             .Build();

        //         var connectionString = configuration.GetConnectionString("DefaultConnection");

        //         Console.WriteLine($"Connection String: {connectionString}");

        //         optionsBuilder.UseSqlServer(connectionString);
        //     }
        // }
    }
}