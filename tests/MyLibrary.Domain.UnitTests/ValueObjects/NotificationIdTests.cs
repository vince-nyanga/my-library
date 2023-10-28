using FluentAssertions;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.ValueObjects;
using Xunit;

namespace MyLibrary.Domain.UnitTests.ValueObjects;

public class NotificationIdTests
{
    [Fact]
    public void GivenEmptyValue_ItShouldThrowEmptyNotificationIdException()
    {
        // Arrange
        var value = Guid.Empty;
        
        // Act
        var act = () => new NotificationId(value);
        
        // Assert
        act.Should().Throw<EmptyNotificationIdException>();
    }

    [Fact]
    public void GivenValidValue_ItShouldCreateNotificationId()
    {
        // Arrange
        var value = Guid.NewGuid();
        
        // Act
        var notificationId = new NotificationId(value);
        
        // Assert
        notificationId.Value.Should().Be(value);
    }
}