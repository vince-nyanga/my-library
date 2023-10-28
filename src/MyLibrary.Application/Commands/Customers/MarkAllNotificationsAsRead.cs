using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Application.Exceptions;

namespace MyLibrary.Application.Commands.Customers;

public sealed record MarkAllNotificationsAsRead : ICommand;

internal sealed class MarkAllNotificationsAsReadHandler : ICommandHandler<MarkAllNotificationsAsRead>
{
    private readonly ICustomerRepository _repository;
    private readonly IUserContextProvider _userContextProvider;

    public MarkAllNotificationsAsReadHandler(ICustomerRepository repository, IUserContextProvider userContextProvider)
    {
        _repository = repository;
        _userContextProvider = userContextProvider;
    }

    public async ValueTask HandleAsync(MarkAllNotificationsAsRead command)
    {
        var customer = await _repository.GetAsync(_userContextProvider.UserId);

        if (customer is null)
        {
            throw new EntityNotFoundException(
                $"Customer with ID {_userContextProvider.UserId} does not exist. Please update your profile.");
        }
        
        customer.MarkAllNotificationsAsRead();

        await _repository.UpdateAsync(customer);
    }
}