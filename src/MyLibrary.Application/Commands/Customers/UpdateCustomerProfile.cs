using MyLibrary.Application.Abstractions.Auth;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Abstractions.Repositories;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Commands.Customers;

public sealed record UpdateCustomerProfile(string Name, string EmailAddress) : ICommand;

internal sealed class UpdateCustomerProfileHandler : ICommandHandler<UpdateCustomerProfile>
{
    private readonly IUserContextProvider _userContextProvider;
    private readonly ICustomerRepository _repository;

    public UpdateCustomerProfileHandler(IUserContextProvider userContextProvider, ICustomerRepository repository)
    {
        _userContextProvider = userContextProvider;
        _repository = repository;
    }

    public async ValueTask HandleAsync(UpdateCustomerProfile command)
    {
        var customer = await _repository.GetAsync(_userContextProvider.UserId);

        if (customer is not null)
        {
            customer.UpdateName(command.Name);
            customer.UpdateEmailAddress(command.EmailAddress);
            await _repository.UpdateAsync(customer);
            return;
        }

        customer = new Customer(_userContextProvider.UserId, command.Name, command.EmailAddress);
        await _repository.AddAsync(customer);
    }
}