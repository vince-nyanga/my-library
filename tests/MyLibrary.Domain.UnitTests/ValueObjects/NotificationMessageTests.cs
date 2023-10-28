using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class NotificationMessageTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GivenEmptyValue_ItShouldThrowEmptyNotificationMessageException(string value)
    {
        // Act
        var act = () => new NotificationMessage(value);
        
        // Assert
        act.Should().Throw<EmptyNotificationMessageException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateNotificationMessage()
    {
        // Arrange
        var value = new MnemonicString().GetValue();
        
        // Act
        var notificationMessage = new NotificationMessage(value);
        
        // Assert
        notificationMessage.Value.Should().Be(value);
    }
}