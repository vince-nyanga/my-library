using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookReservationCancelled(Guid BookId, string BookTitle, string CustomerId) : IDomainEvent;