using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class BookIdTests
{
    [Fact]
    public void GivenEmptyValue_ItShouldThrowEmptyBookIdException()
    {
        // Arrange
        var value = Guid.Empty;
        
        // Act
        var act = () => new BookId(value);
        
        // Assert
        act.Should().Throw<EmptyBookIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateBookId()
    {
        // Arrange
        var value = Guid.NewGuid();
        
        // Act
        var bookId = new BookId(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}