using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Events;

public sealed record BookCopyBorrowed(string BookTitle, CustomerId CustomerId, DateOnly DueDate) : IDomainEvent;