namespace MyLibrary.Query.Books.Dtos;

public abstract record Book
{
    public Guid Id { get; init; }
    public string Title { get; init; }
}