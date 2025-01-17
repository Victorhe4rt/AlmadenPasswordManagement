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
        private readonly IConfiguration _configuration;
        public DbSet<LastPassCard> LastPassCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }


        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // Imprime a connection string
            Console.WriteLine($"Connection String: {connectionString}");

            optionsBuilder.UseSqlServer(connectionString);
        }



    }
}