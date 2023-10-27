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
        var bookId = new CustomerName(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}

public class EmailAddressTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenEmptyValue_ItShouldThrowEmptyEmailAddressException(string value)
    {
        // Act
        var act = () => new EmailAddress(value);
        
        // Assert
        act.Should().Throw<EmptyEmailAddressException>();
    }
    
    [Theory]
    [InlineData("t")]
    [InlineData("t@")]
    [InlineData("@.com")]
    public void GivenInvalidValue_ItShouldThrowInvalidEmailAddressException(string value)
    {
        // Act
        var act = () => new EmailAddress(value);
        
        // Assert
        act.Should().Throw<InvalidEmailAddressException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateEmailAddress()
    {
        // Arrange
        var value = new EmailAddresses().GetValue();
        
        // Act
        var bookId = new EmailAddress(value);
        
        // Assert
        bookId.Value.Should().Be(value);
    }
}