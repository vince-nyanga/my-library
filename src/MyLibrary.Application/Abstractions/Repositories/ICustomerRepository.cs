using MyLibrary.Domain.Entities;
using MyLibrary.Domain.ValueObjects;

namespace MyLibrary.Application.Abstractions.Repositories;

internal interface ICustomerRepository
{
    ValueTask<Customer> GetAsync(CustomerId id);
    ValueTask AddAsync(Customer customer);
    ValueTask UpdateAsync(Customer customer);
}