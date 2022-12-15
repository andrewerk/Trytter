using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Channels;
using Domain;

namespace Infrastructure.Data
{
    public class TrytterContext : DbContext, ITrytterContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public TrytterContext(DbContextOptions<TrytterContext> options) : base(options) { }
        public TrytterContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=trytter_db;User=SA;Password=Password12!;TrustServerCertificate=True");
            }
        }
    }
}
