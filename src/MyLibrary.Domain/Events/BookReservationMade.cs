using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationMade(string BookTitle, string CustomerId, DateTimeOffset ExpiryDate) : IDomainEvent;