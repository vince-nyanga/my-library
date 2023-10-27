using MyLibrary.Domain.Abstractions;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Domain.Entities;

public sealed class Customer : AggregateRoot<CustomerId>
{
    private CustomerName _name;
    private EmailAddress _emailAddress;

    private Customer()
    {
    }

    public Customer(CustomerId id, CustomerName name, EmailAddress emailAddress)
    {
        Id = id;
        _name = name;
        _emailAddress = emailAddress;
    }
}