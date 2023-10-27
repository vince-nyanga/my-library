using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class CustomerNameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenEmptyValue_ItShouldThrowEmptyCustomerNameException(string value)
    {
        // Act
        var act = () => new CustomerName(value);
        
        // Assert
        act.Should().Throw<EmptyCustomerNameException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateCustomerName()
    {
        // Arrange
        var value = new MnemonicString().GetValue();
        
        // Act
        var customerName = new CustomerName(value);
        
        // Assert
        customerName.Value.Should().Be(value);
    }
}