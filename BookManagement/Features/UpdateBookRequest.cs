namespace BookManagement.Features;

public record UpdateBookRequest(Guid Id, string Title, string Author, int YearPublished);