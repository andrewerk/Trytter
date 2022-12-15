using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Data
{
    public interface ITrytterContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public int SaveChanges();
    }
}
