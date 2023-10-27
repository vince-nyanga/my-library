using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

public sealed record BookReservationMade(Book Book, Customer Customer) : IDomainEvent;