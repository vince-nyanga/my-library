using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Exceptions;
using MyLibrary.Application.Repositories;

namespace MyLibrary.Application.Commands.Customers;

public sealed record MarkNotificationAsRead(Guid NotificationId) : ICommand;

internal sealed class MarkNotificationAsReadHandler : ICommandHandler<MarkNotificationAsRead>
{
    private readonly ICustomerRepository _repository;
    private readonly IUserContextProvider _userContextProvider;

    public MarkNotificationAsReadHandler(ICustomerRepository repository, IUserContextProvider userContextProvider)
    {
        _repository = repository;
        _userContextProvider = userContextProvider;
    }

    public async ValueTask HandleAsync(MarkNotificationAsRead command)
    {
        var customer = await _repository.GetAsync(_userContextProvider.UserId);

        if (customer is null)
        {
            throw new EntityNotFoundException(
                $"Customer with ID {_userContextProvider.UserId} does not exist. Please update your profile.");
        }
        
        customer.MarkNotificationAsRead(command.NotificationId);

        await _repository.UpdateAsync(customer);
    }
}