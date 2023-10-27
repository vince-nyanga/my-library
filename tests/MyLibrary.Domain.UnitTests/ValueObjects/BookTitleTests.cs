using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class BookTitleTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenEmptyValue_ItShouldThrowEmptyBookTitleException(string value)
    {
        // Act
        var act = () => new BookTitle(value);
        
        // Assert
        act.Should().Throw<EmptyBookTitleException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateBookTitle()
    {
        // Arrange
        var value = new MnemonicString().GetValue();
        
        // Act
        var bookId = new BookTitle(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}