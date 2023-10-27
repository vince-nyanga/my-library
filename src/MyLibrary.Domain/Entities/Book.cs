using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Book : AggregateRoot<BookId>
{
    private BookTitle _title;
    private ushort _availableCopies;
    
    private Book()
    {
    }
    
    public Book(BookId id, BookTitle title, ushort availableCopies)
    {
        Id = id;
        _title = title;
        _availableCopies = availableCopies;
    }
}