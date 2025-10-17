using BookManagement.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Features;

public class GetPagedBooksHandler(BookManagementContext context)
{
    private readonly BookManagementContext _context = context;

    public async Task<IResult> Handle(GetPagedBooksRequest request)
    {
        var page = request.Page < 1 ? 1 : request.Page;
        var pageSize = request.PageSize is < 1 or > 100 ? 10 : request.PageSize;

        var totalCount = await _context.Books.CountAsync();

        var items = await _context.Books
            .OrderBy(b => b.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var response = new
        {
            page,
            pageSize,
            totalCount,
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
            items
        };

        return Results.Ok(response);
    }
}


