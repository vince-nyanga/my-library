using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationExpired(Guid BookId, string BookTitle, string CustomerId) : IDomainEvent;