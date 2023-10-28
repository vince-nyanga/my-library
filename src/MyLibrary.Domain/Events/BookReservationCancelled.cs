using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationCancelled(string BookTitle, string CustomerName) : IDomainEvent;