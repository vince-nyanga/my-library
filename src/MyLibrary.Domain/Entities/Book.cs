using System.Collections.Immutable;
using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

internal sealed class Book : AggregateRoot<BookId>
{
    private readonly List<BorrowedBookCopy> _borrowedCopies = new();
    private readonly List<ReservedBookCopy> _reservedCopies = new();
    
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

    public IReadOnlyCollection<ReservedBookCopy> ReservedCopies
    {
        get => _reservedCopies.AsReadOnly();
        init => _reservedCopies = value.ToList();
    }

    public void ReserveCopy(CustomerId customerId)
    {
        EnsureCustomerHasNotBorrowedOrReservedACopy(customerId);
        EnsureAvailableCopies();

        AvailableCopies -= 1;

        var reservation = new ReservedBookCopy(Guid.NewGuid(), Id, customerId);
        _reservedCopies.Add(reservation);
        EnsureStockBalances();

        AddEvent(new BookReservationMade(Title,customerId));
    }

    public void ExpireReservation(CustomerId customerId)
    {
        var reservedCopy = EnsureReservationExists(customerId);
        RemoveReservation(reservedCopy);
        AddEvent(new BookReservationExpired(Title, reservedCopy.CustomerId));
    }

    public void CancelReservation(CustomerId customerId)
    {
        var reservation = EnsureReservationExists(customerId);
        RemoveReservation(reservation);
        AddEvent(new BookReservationCancelled(Title, customerId));
    }
    
    public void BorrowCopy(CustomerId customerId, DateOnly dueDate)
    {
        var possibleReservation = ReservedCopies.SingleOrDefault(r => r.CustomerId == customerId);
        if (possibleReservation is not null)
        {
            RemoveReservation(possibleReservation);
        }
        
        EnsureCustomerHasNotBorrowedOrReservedACopy(customerId);
        EnsureAvailableCopies();
        EnsureDueDateNotInThePast(dueDate);

        AvailableCopies -= 1;
        var borrowedBookCopy = new BorrowedBookCopy(Guid.NewGuid(), customerId, Id, dueDate);
        _borrowedCopies.Add(borrowedBookCopy);
        EnsureStockBalances();

        AddEvent(new BookCopyBorrowed(Title, customerId, dueDate));
    }
    
    public void ReturnCopy(BorrowedBookId borrowedBookId)
    {
        var copy = EnsureBorrowedCopyExists(borrowedBookId);

        AvailableCopies += 1;
        _borrowedCopies.Remove(copy);
        EnsureStockBalances();
        
        copy.Return();
        AddEvent(new BookCopyReturned(Title, copy.CustomerId));
    }

    internal ushort GetAvailableCopies()
        => AvailableCopies;

    private void RemoveReservation(ReservedBookCopy reservedCopy)
    {
        AvailableCopies = AvailableCopies += 1;
        _reservedCopies.Remove(reservedCopy);
        EnsureStockBalances();
    }

    private void EnsureAvailableCopies()
    {
        if (AvailableCopies == 0)
        {
            throw new BookCopiesUnavailableException(Id);
        }
    }

    private ReservedBookCopy EnsureReservationExists(CustomerId customerId)
    {
        var reservationCopy = ReservedCopies.SingleOrDefault(r => r.CustomerId == customerId);

        if (reservationCopy is null)
        {
            throw new BookReservationNotFoundException(Id, customerId);
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

    internal IReadOnlyCollection<BorrowedBookCopy> CopiesNotReturned =>
        _borrowedCopies.Where(c => !c.IsReturned).ToImmutableArray();

    private void EnsureStockBalances()
    {
        var totalStock = AvailableCopies + ReservedCopies.Count + CopiesNotReturned.Count;

        if (totalStock != TotalCopies)
        {
            throw new BookStockNotBalancingException(Id, TotalCopies, (ushort)totalStock);
        }
    }

    private void EnsureCustomerHasNotBorrowedOrReservedACopy(CustomerId customerId)
    {
        if (ReservedCopies.Any(r => r.CustomerId == customerId))
        {
            throw new CustomerAlreadyReservedOrBorrowedBookException(Id, customerId);
        }
        
        EnsureCustomerHasNotBorrowedCopy(customerId);
    }

    private void EnsureCustomerHasNotBorrowedCopy(CustomerId customerId)
    {
        if (CopiesNotReturned.Any(c => c.CustomerId == customerId))
        {
            throw new CustomerAlreadyReservedOrBorrowedBookException(Id, customerId);
        }
    }
}