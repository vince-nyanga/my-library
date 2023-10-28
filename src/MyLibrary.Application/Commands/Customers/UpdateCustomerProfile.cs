using MyLibrary.Application.Abstractions.Commands;

namespace MyLibrary.Application.Commands.Customers;

public sealed record UpdateCustomerProfile(string Name, string EmailAddress) : ICommand;