using Microsoft.EntityFrameworkCore;

namespace aspmvc.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
