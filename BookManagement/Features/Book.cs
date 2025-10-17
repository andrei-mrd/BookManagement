using System.Xml;

namespace BookManagement.Features;

public record Book(Guid Id, string Title, string Author, int YearPublished);