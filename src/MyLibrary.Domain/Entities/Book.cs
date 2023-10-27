using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Book : AggregateRoot<BookId>
{
    private List<BorrowedBookCopy> _borrowedCopies = new();
    private List<BookCopyReservation> _reservedCopies = new();

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

    public ushort TotalCopies { get; private set; }

    public IReadOnlyCollection<BorrowedBookCopy> BorrowedCopies => _borrowedCopies.AsReadOnly();

    public IReadOnlyCollection<BookCopyReservation> ReservedCopies => _reservedCopies.AsReadOnly();

    public void RerseveCopy(Customer customer)
    {
        EnsureAvailableCopies();

        AvailableCopies -= 1;

        var reservation = new BookCopyReservation(Guid.NewGuid(), Id, customer.Id);
        _reservedCopies.Add(reservation);

        AddEvent(new BookReservationMade(this, customer));
    }

    public void ExpireReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        var availableCopies = AvailableCopies += 1;
        EnsureAvailableCopiesAreNotMoreThanTotalCopies(availableCopies);

        AvailableCopies = availableCopies;
        _reservedCopies.Remove(reservedCopy);

        AddEvent(new BookReservationExpired(this, reservedCopy));
    }

    public void CancelReservation(BookReservationId reservationId)
    {
        var reservedCopy = EnsureReservationExists(reservationId);

        var availableCopies = AvailableCopies += 1;
        EnsureAvailableCopiesAreNotMoreThanTotalCopies(availableCopies);

        AvailableCopies = availableCopies;
        _reservedCopies.Remove(reservedCopy);

        AddEvent(new BookReservationCancelled(this, reservedCopy));
    }

    public void BorrowCopy(Customer customer, DateOnly dueDate)
    {
        EnsureAvailableCopies();
        EnsureDueDateNotInThePast(dueDate);

        AvailableCopies -= 1;
        var borrowedBookCopy = new BorrowedBookCopy(Guid.NewGuid(), customer.Id, Id, dueDate);
        _borrowedCopies.Add(borrowedBookCopy);

        AddEvent(new BookCopyBorrowed(this, customer));
    }

    public void BorrowCopy(BookReservationId reservationId, DateOnly dueDate)
    {
        var reservation = EnsureReservationExists(reservationId);
        EnsureDueDateNotInThePast(dueDate);

        var borrowedBookCopy = new BorrowedBookCopy(Guid.NewGuid(), reservation.CustomerId, Id, dueDate);
        _borrowedCopies.Add(borrowedBookCopy);

        AddEvent(new ReservedBookBorrowed(this, reservation));
    }

    public void ReturnCopy(BorrowedBookId borrowedBookId)
    {
        var copy = EnsureBorrowedCopyExists(borrowedBookId);

        AvailableCopies += 1;
        _borrowedCopies.Remove(copy);

        AddEvent(new BookCopyReturned(this, copy));
    }

    private void EnsureAvailableCopiesAreNotMoreThanTotalCopies(ushort availableCopies)
    {
        if (availableCopies > TotalCopies)
        {
            throw new AvailableBookCopiesExceedTotalCopiesException(Id);
        }
    }

    private void EnsureAvailableCopies()
    {
        if (AvailableCopies == 0)
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
}