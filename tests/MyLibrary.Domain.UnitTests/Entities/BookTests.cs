using FluentAssertions;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.UnitTests.Extensions;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.Entities;

public class BookTests
{
    [Fact]
    public void GivenAvailableCopies_Reserve_ShouldReserveACopy()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        
        // Act
        book.ReserveCopy(customer);
        
        // Assert
        book.GetAvailableCopies().Should().Be(1);
        book.Events.FindRaisedEvent<BookReservationMade>().Should().NotBeNull();
    }

    private static Book CreateBook(ushort availableCopies)
        => new(Guid.NewGuid(), new MnemonicString().GetValue(), availableCopies);

    private static Customer CreateCustomer()
        => new(Guid.NewGuid(), new RealNames().GetValue(), new EmailAddresses().GetValue());
}