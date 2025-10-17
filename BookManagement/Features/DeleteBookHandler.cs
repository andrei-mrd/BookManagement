using BookManagement.Persistence;

namespace BookManagement.Features;

public class DeleteAllBookHandler(BookManagementContext dbContext)
{
    private readonly BookManagementContext _dbContext = dbContext;

    public async Task<IResult> Handle(DeleteBookRequest request)
    {
        
    }
}