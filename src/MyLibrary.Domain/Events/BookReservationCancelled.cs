using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationCancelled(Book Book, BookCopyReservation Reservation) : IDomainEvent;