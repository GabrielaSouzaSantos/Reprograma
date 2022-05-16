using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=DESKTOP-Q91FTM5\\SQLEXPRESS;Database=Reprograma;Integrated Security=True");
        }
    }
}