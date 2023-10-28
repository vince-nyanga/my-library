using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationExpired(Book Book, BookCopyReservation Reservation) : IDomainEvent;