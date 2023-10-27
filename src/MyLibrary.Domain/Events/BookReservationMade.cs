using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Domain.Events;

public record BookReservationMade(Book Book, Customer Customer) : IDomainEvent;