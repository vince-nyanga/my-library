using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class CustomerIdTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenEmptyValue_ItShouldThrowEmptyCustomerIdException(string value)
    {
        // Act
        var act = () => new CustomerId(value);
        
        // Assert
        act.Should().Throw<EmptyCustomerIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateCustomerId()
    {
        // Arrange
        var value = new MnemonicString().GetValue();
        
        // Act
        var customerId = new CustomerId(value);
        
        // Assert
        customerId.Value.Should().Be(value);
    }
}