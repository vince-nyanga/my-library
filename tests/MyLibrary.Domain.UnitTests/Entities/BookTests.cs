using FluentAssertions;
using MyLibrary.Domain.Entities;
using MyLibrary.Domain.Events;
using MyLibrary.Domain.Exceptions;
using MyLibrary.Domain.UnitTests.Extensions;
using Tynamix.ObjectFiller;
using Xunit;

namespace MyLibrary.Domain.UnitTests.Entities;

public class BookTests
{
    [Fact]
    public void ReserveCopy_WhenCopiesAreAvailable_ShouldReserveACopy()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        
        // Act
        book.ReserveCopy(customer.Id);
        
        // Assert
        book.GetAvailableCopies().Should().Be(1);
        book.Events.FindRaisedEvent<BookReservationMade>().Should().NotBeNull();
    }

    [Fact]
    public void ReserveCopy_WhenCopiesAreUnavailable_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(0);
        var customer = CreateCustomer();
        
        // Act
        var reserveCopy = () => book.ReserveCopy(customer.Id);
        
        // Assert
        reserveCopy.Should().Throw<BookCopiesUnavailableException>();
        book.Events.Should().BeEmpty();
    }
    
    [Fact]
    public void ReserveCopy_WhenCustomerHasAlreadyReservedCopy_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(1);
        var customer = CreateCustomer();
        book.ReserveCopy(customer.Id);
        
        // Act
        var reserveCopy = () => book.ReserveCopy(customer.Id);
        
        // Assert
        reserveCopy.Should().Throw<CustomerAlreadyReservedOrBorrowedBookException>();
    }
    
    [Fact]
    public void ReserveCopy_WhenCustomerHasAlreadyBorrowedCopy_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        book.BorrowCopy(customer.Id, DateOnly.FromDateTime(DateTime.Today.AddDays(1)));
        
        // Act
        var reserveCopy = () => book.ReserveCopy(customer.Id);
        
        // Assert
        reserveCopy.Should().Throw<CustomerAlreadyReservedOrBorrowedBookException>();
    }
    
    [Fact]
    public void ExpireReservation_WhenReservationIdDoesNotExist_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        var reservationId = Guid.NewGuid();
        
        // Act
        var expireReservation = () => book.ExpireReservation(new MnemonicString().GetValue());
        
        // Assert
        expireReservation.Should().Throw<BookReservationNotFoundException>();
        book.Events.Should().BeEmpty();
    }

    [Fact]
    public void ExpireReservation_WhenReservationExists_ShouldIncreaseAvailableCopies()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        book.ReserveCopy(customer.Id);
        
        // Act
        book.ExpireReservation(customer.Id);
        
        // Assert
        book.GetAvailableCopies().Should().Be(2);
        book.Events.FindRaisedEvent<BookReservationExpired>().Should().NotBeNull();
    }
    
    [Fact]
    public void CancelReservation_WhenReservationIdDoesNotExist_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        
        // Act
        var expireReservation = () => book.CancelReservation(new MnemonicString().GetValue());
        
        // Assert
        expireReservation.Should().Throw<BookReservationNotFoundException>();
        book.Events.Should().BeEmpty();
    }

    [Fact]
    public void CancelReservation_WhenReservationExists_ShouldIncreaseAvailableCopies()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        book.ReserveCopy(customer.Id);
        
        // Act
        book.CancelReservation(customer.Id);
        
        // Assert
        book.GetAvailableCopies().Should().Be(2);
        book.Events.FindRaisedEvent<BookReservationCancelled>().Should().NotBeNull();
    }
    
    [Fact]
    public void BorrowCopy_WhenCopiesAreAvailable_ShouldReserveACopy()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        var dueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        
        // Act
        book.BorrowCopy(customer.Id, dueDate);
        
        // Assert
        book.GetAvailableCopies().Should().Be(1);
        book.Events.FindRaisedEvent<BookCopyBorrowed>().Should().NotBeNull();
    }
    
    [Fact]
    public void BorrowCopy_WhenCustomerHasAlreadyBorrowed_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        var dueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        book.BorrowCopy(customer.Id, dueDate);
        
        // Act
        var borrowCopy = () => book.BorrowCopy(customer.Id, dueDate);
        
        // Assert
        borrowCopy.Should().Throw<CustomerAlreadyReservedOrBorrowedBookException>();
    }
    
    [Fact]
    public void BorrowCopy_WhenCopiesAreUnavailable_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(0);
        var customer = CreateCustomer();
        var dueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        
        // Act
        var borrowCopy = () => book.BorrowCopy(customer.Id, dueDate);
        
        // Assert
        borrowCopy.Should().Throw<BookCopiesUnavailableException>();
        book.Events.Should().BeEmpty();
    }
    
    
    [Fact]
    public void BorrowCopy_WhenDueDateIsInThePast_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        var dueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-7));
        
        // Act
        var borrowCopy = () => book.BorrowCopy(customer.Id, dueDate);
        
        // Assert
        borrowCopy.Should().Throw<DueDateInThePastException>();
        book.Events.Should().BeEmpty();
    }
    
    [Fact]
    public void ReturnCopy_WhenBorrowedBookIdDoesNotExists_ShouldThrowException()
    {
        // Arrange
        var book = CreateBook(2);
        var borrowedBookId = Guid.NewGuid();
        
        // Act
        var expireReservation = () => book.ReturnCopy(borrowedBookId);
        
        // Assert
        expireReservation.Should().Throw<BorrowedBookCopyNotFoundException>();
        book.Events.Should().BeEmpty();
    }

    [Fact]
    public void ReturnCopy_WhenBorrowedBookIdExists_ShouldIncreaseAvailableCopies()
    {
        // Arrange
        var book = CreateBook(2);
        var customer = CreateCustomer();
        var dueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        book.BorrowCopy(customer.Id, dueDate);
        var borrowedBookId = book.CopiesNotReturned.Single().Id;
        
        // Act
        book.ReturnCopy(borrowedBookId);
        
        // Assert
        book.GetAvailableCopies().Should().Be(2);
        book.CopiesNotReturned.Should().BeEmpty();
        book.Events.FindRaisedEvent<BookCopyReturned>().Should().NotBeNull();
    }

    private static Book CreateBook(ushort availableCopies)
        => new(Guid.NewGuid(), new MnemonicString().GetValue(), availableCopies);

    private static Customer CreateCustomer()
        => new(new MnemonicString().GetValue(), new RealNames().GetValue(), new EmailAddresses().GetValue());
}