using BookManagement.Features;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Persistence;

public class BookManagementContext(DbContextOptions<BookManagementContext> options): DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}