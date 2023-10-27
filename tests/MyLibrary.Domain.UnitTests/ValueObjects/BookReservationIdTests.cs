using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class BookReservationIdTests
{
    [Fact]
    public void GivenEmptyValue_ItShouldThrowEmptyBookReservationIdException()
    {
        // Arrange
        var value = Guid.Empty;
        
        // Act
        var act = () => new BookReservationId(value);
        
        // Assert
        act.Should().Throw<EmptyBookReservationIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateBookReservationId()
    {
        // Arrange
        var value = Guid.NewGuid();
        
        // Act
        var bookId = new BookReservationId(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}