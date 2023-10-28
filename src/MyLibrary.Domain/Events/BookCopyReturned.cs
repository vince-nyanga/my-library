using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

internal sealed record BookCopyReturned(Book Book, BorrowedBookCopy Copy) : IDomainEvent;