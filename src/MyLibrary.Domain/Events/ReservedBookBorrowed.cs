using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

public sealed record ReservedBookBorrowed(Book Book, BookCopyReservation Reservation) : IDomainEvent;