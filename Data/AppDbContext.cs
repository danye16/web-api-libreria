using libreria_JDPC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace libreria_JDPC.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
