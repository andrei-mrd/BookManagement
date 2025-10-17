namespace BookManagement.Features;

public record CreateBookRequest(string Title, string Author, int YearPublished);