using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookCopyReturned(Guid BookId,string BookTitle, string CustomerId) : IDomainEvent;