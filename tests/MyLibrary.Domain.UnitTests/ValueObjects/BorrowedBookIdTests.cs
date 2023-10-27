using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class BorrowedBookIdTests
{
    [Fact]
    public void GivenEmptyValue_ItShouldThrowEmptyBorrowedBookIdException()
    {
        // Arrange
        var value = Guid.Empty;
        
        // Act
        var act = () => new BorrowedBookId(value);
        
        // Assert
        act.Should().Throw<EmptyBorrowedBookIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateBorrowedBookId()
    {
        // Arrange
        var value = Guid.NewGuid();
        
        // Act
        var bookId = new BorrowedBookId(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}