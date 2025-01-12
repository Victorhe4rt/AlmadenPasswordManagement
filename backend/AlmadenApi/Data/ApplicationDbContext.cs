using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AlmadenApi.Data
{
    public class ApplicationDbContext:DbContext
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
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        

        
    }
}