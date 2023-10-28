using MyLibrary.Domain.Abstractions;

namespace MyLibrary.Domain.Events;

public sealed record BookCopyReturned(string BookTitle, string CustomerId) : IDomainEvent;