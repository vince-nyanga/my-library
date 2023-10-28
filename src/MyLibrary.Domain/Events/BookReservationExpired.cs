using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationExpired(string BookTitle, string CustomerId) : IDomainEvent;