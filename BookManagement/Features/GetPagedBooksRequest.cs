namespace BookManagement.Features;

public record GetPagedBooksRequest(int Page = 1, int PageSize = 10);


