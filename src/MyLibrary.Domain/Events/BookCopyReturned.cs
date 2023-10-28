using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

internal sealed record BookCopyReturned(string BookTitle, string CustomerId) : IDomainEvent;