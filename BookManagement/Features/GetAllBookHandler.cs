using BookManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Features;

public class GetAllBookHandler(BookManagementContext context)
{
    private readonly BookManagementContext _context = context;
    
    public async Task<IResult> Handle(GetAllBookRequest request)
    {
        var books = await _context.Books.ToListAsync();
        return Results.Ok(books);
    }
}