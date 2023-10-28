using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Book : AggregateRoot<BookId>
{
    private BookTitle _title;
    private ushort _availableCopies;
    private ushort _totalCopies;
    private List<BorrowedBookCopy> _borrowedCopies = new();
    private List<BookCopyReservation> _reservedCopies = new();

    private Book()
    {
    }

    public Book(BookId id, BookTitle title, ushort totalCopies)
    {
        Id = id;
        _title = title;
        _totalCopies = totalCopies;
        _availableCopies = totalCopies;
    }

    public void ReserveCopy(Customer customer)
    {
        EnsureAvailableCopies();

        _availableCopies -= 1;

        var reservation = new BookCopyReservation(Guid.NewGuid(), Id, customer.Id);
        _reservedCopies.Add(reservation);
        EnsureStockBalances();

        AddEvent(new BookReservationMade(this, customer));
    }

    public void ExpireReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        _availableCopies = _availableCopies += 1;
        _reservedCopies.Remove(reservedCopy);
        EnsureStockBalances();

        AddEvent(new BookReservationExpired(this, reservedCopy));
    }

    public void CancelReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        _availableCopies = _availableCopies += 1;
        _reservedCopies.Remove(reservedCopy);
        EnsureStockBalances();

        AddEvent(new BookReservationCancelled(this, reservedCopy));
    }

    public void BorrowCopy(Customer customer, DateOnly dueDate)
    {
        EnsureAvailableCopies();
        EnsureDueDateNotInThePast(dueDate);

        _availableCopies -= 1;
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

        _availableCopies += 1;
        _borrowedCopies.Remove(copy);
        EnsureStockBalances();
        
        copy.Return();
        AddEvent(new BookCopyReturned(this, copy));
    }

    internal ushort GetAvailableCopies()
        => _availableCopies;

    internal IReadOnlyCollection<BookCopyReservation> GetReservedCopies()
        => _reservedCopies.AsReadOnly();

    internal IReadOnlyCollection<BorrowedBookCopy> GetUnreturnedBorrowedCopies()
        => _borrowedCopies.Where(b => !b.IsReturned).ToImmutableArray();

    private void EnsureAvailableCopies()
    {
        if (_availableCopies == 0)
        {
            throw new BookCopiesUnavailableException(Id);
        }
    }

    private BookCopyReservation EnsureReservationExists(BookReservationId reservationId)
    {
        var reservationCopy = _reservedCopies.SingleOrDefault(r => r.Id == reservationId);

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
        var borrowedCopy = _borrowedCopies.SingleOrDefault(r => r.Id == borrowedBookId);

        if (borrowedCopy is null)
        {
            throw new BorrowedBookCopyNotFoundException(Id, borrowedBookId);
        }

        return borrowedCopy;
    }

    private void EnsureStockBalances()
    {
        var totalStock = _availableCopies + _reservedCopies.Count + GetUnreturnedBorrowedCopies().Count;

        if (totalStock != _totalCopies)
        {
            throw new BookStockNotBalancingException(Id, _totalCopies, (ushort)totalStock);
        }
    }
}