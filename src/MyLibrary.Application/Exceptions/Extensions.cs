using MyLibrary.Domain.Exceptions;

namespace MyLibrary.Application.Exceptions;

internal static class Extensions
{
    public static Exception ToApplicationException(this Exception exception)
    {
        switch (exception)
        {
            case BookStockNotBalancingException:
                return new InternalErrorException();
            case BookCopiesUnavailableException:
            case CustomerAlreadyReservedOrBorrowedBookException:
            case BookCopyAlreadyReturnedException:
            case NotificationAlreadyReadException:
                return new ConflictingStateException(exception.Message);
            case DueDateInThePastException:
            case EmptyBookIdException:
            case EmptyBookTitleException:
            case EmptyCustomerIdException:
            case EmptyBookReservationIdException:
            case EmptyCustomerNameException:
            case EmptyNotificationIdException:
            case EmptyNotificationMessageException:
            case InvalidEmailAddressException:
            case EmptyEmailAddressException:
            case EmptyBorrowedBookIdException:
                return new ValidationException(exception.Message);
            case BookReservationNotFoundException:
            case NotificationNotFoundException:
            case BorrowedBookCopyNotFoundException:
                return new EntityNotFoundException(exception.Message);
        }

        return exception;
    }
}