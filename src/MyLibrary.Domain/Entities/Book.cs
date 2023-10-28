using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Book : AggregateRoot<BookId>
{
    private readonly List<BorrowedBookCopy> _borrowedCopies = new();
    private readonly List<BookCopyReservation> _reservedCopies = new();
    
    private Book()
    {
    }

    public Book(BookId id, BookTitle title, ushort totalCopies)
    {
        Id = id;
        Title = title;
        TotalCopies = totalCopies;
        AvailableCopies = totalCopies;
    }
    
    public BookTitle Title { get; private set; }
    public ushort AvailableCopies { get; private set; }
    public ushort TotalCopies { get; init; }
    
    public IReadOnlyCollection<BorrowedBookCopy> BorrowedCopies
    {
        get => _borrowedCopies.AsReadOnly();
        init => _borrowedCopies = value.ToList();
    }

    public IReadOnlyCollection<BookCopyReservation> ReservedCopies
    {
        get => _reservedCopies.AsReadOnly();
        init => _reservedCopies = value.ToList();
    }

    public void ReserveCopy(Customer customer)
    {
        EnsureAvailableCopies();

        AvailableCopies -= 1;

        var reservation = new BookCopyReservation(Guid.NewGuid(), Id, customer.Id);
        _reservedCopies.Add(reservation);
        EnsureStockBalances();

        AddEvent(new BookReservationMade(this, customer));
    }

    public void ExpireReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        AvailableCopies = AvailableCopies += 1;
        _reservedCopies.Remove(reservedCopy);
        EnsureStockBalances();

        AddEvent(new BookReservationExpired(this, reservedCopy));
    }

    public void CancelReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        AvailableCopies = AvailableCopies += 1;
        _reservedCopies.Remove(reservedCopy);
        EnsureStockBalances();

        AddEvent(new BookReservationCancelled(this, reservedCopy));
    }

    public void BorrowCopy(Customer customer, DateOnly dueDate)
    {
        EnsureAvailableCopies();
        EnsureDueDateNotInThePast(dueDate);

        AvailableCopies -= 1;
        var borrowedBookCopy = new BorrowedBookCopy(Guid.NewGuid(), customer.Id, Id, dueDate);
        _borrowedCopies.Add(borrowedBookCopy);
        EnsureStockBalances();

        AddEvent(new BookCopyBorrowed(this, customer));
    }

    public void BorrowCopy(BookReservationId reservationId, DateOnly dueDate)
    {
        var reservation = EnsureReservationExists(reservationId);
        EnsureDueDateNotInThePast(dueDate);

        var borrowedBookCopy = new BorrowedBookCopy(Guid.NewGuid(), reservation.CustomerId, Id, dueDate);
        _borrowedCopies.Add(borrowedBookCopy);
        _reservedCopies.Remove(reservation);
        EnsureStockBalances();

        AddEvent(new ReservedBookBorrowed(this, reservation));
    }

    public void ReturnCopy(BorrowedBookId borrowedBookId)
    {
        var copy = EnsureBorrowedCopyExists(borrowedBookId);

        AvailableCopies += 1;
        _borrowedCopies.Remove(copy);
        EnsureStockBalances();
        
        copy.Return();
        AddEvent(new BookCopyReturned(this, copy));
    }

    internal ushort GetAvailableCopies()
        => AvailableCopies;

    public IReadOnlyCollection<BorrowedBookCopy> GetUnreturnedBorrowedCopies()
        => BorrowedCopies.Where(b => !b.IsReturned).ToImmutableArray();

    private void EnsureAvailableCopies()
    {
        if (AvailableCopies == 0)
        {
            throw new BookCopiesUnavailableException(Id);
        }
    }

    private BookCopyReservation EnsureReservationExists(BookReservationId reservationId)
    {
        var reservationCopy = ReservedCopies.SingleOrDefault(r => r.Id == reservationId);

        if (reservationCopy is null)
        {
            throw new BookReservationNotFoundException(Id, reservationId);
        }

        return reservationCopy;
    }

    private static void EnsureDueDateNotInThePast(DateOnly dueDate)
    {
        if (dueDate < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new DueDateInThePastException(dueDate);
        }
    }

    private BorrowedBookCopy EnsureBorrowedCopyExists(BorrowedBookId borrowedBookId)
    {
        var borrowedCopy = BorrowedCopies.SingleOrDefault(r => r.Id == borrowedBookId);

        if (borrowedCopy is null)
        {
            throw new BorrowedBookCopyNotFoundException(Id, borrowedBookId);
        }

        return borrowedCopy;
    }

    private void EnsureStockBalances()
    {
        var totalStock = AvailableCopies + ReservedCopies.Count + GetUnreturnedBorrowedCopies().Count;

        if (totalStock != TotalCopies)
        {
            throw new BookStockNotBalancingException(Id, TotalCopies, (ushort)totalStock);
        }
    }
}