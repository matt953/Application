using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Entity
{
    public class DataContext : DbContext
    {
        private IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetSection("ConnectionStrings")["Database"]);
        }

        public DbSet<User> Projects { get; set; }
    }
}
