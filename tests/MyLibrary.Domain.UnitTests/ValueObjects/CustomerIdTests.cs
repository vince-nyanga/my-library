using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class CustomerIdTests
{
    [Fact]
    public void GivenEmptyValue_ItShouldThrowEmptyCustomerIdException()
    {
        // Arrange
        var value = Guid.Empty;
        
        // Act
        var act = () => new CustomerId(value);
        
        // Assert
        act.Should().Throw<EmptyCustomerIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateCustomerId()
    {
        // Arrange
        var value = Guid.NewGuid();
        
        // Act
        var bookId = new CustomerId(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}