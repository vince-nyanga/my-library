using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Book : AggregateRoot<BookId>
{
    private Book()
    {
    }
    
    public Book(BookId id, BookTitle title, ushort availableCopies)
    {
        Id = id;
        Title = title;
        AvailableCopies = availableCopies;
    }

    /// <summary>
    /// Gets or sets the book title
    /// </summary>
    public BookTitle Title { get; private set; }
    
    /// <summary>
    /// Gets or sets the available copies.
    /// </summary>
    public ushort AvailableCopies { get; private set; }

    /// <summary>
    /// Reserves a book for a customer
    /// </summary>
    /// <param name="customer"></param>
    public void Rerseve(Customer customer)
    {
        EnsureAvailableCopies();

        AvailableCopies -= 1;
        
        AddEvent(new BookReservationMade(this, customer));
    }

    private void EnsureAvailableCopies()
    {
        if (AvailableCopies == 0)
        {
            throw new BookCopiesUnavailableException(Id);
        }
    }
}