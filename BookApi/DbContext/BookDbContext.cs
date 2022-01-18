using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace BookApi.DbContext;
using Microsoft.EntityFrameworkCore;
public class BookDbContext:DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) {}
    public DbSet<Book> BookStore { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite(@"Data Source=C:\Users\xCoDeR\RiderProjects\webApi\BookApi\BookApi.db;Version=3;");
        //optionsBuilder.UseSqlite(optionsBuilder);
        base.OnConfiguring(optionsBuilder.UseSqlite(@"Data Source=C:\Users\xCoDeR\RiderProjects\webApi\BookApi\BookApi.db;"));
    }

}