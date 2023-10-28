using System.Collections.Immutable;
using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Repositories;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Commands.Books;

public sealed record ExpireBookReservations : ICommand;

internal sealed class ExpireBookReservationsHandler : ICommandHandler<ExpireBookReservations>
{
    private readonly IReservedBookRepository _reservedBookRepository;
    private readonly IBookRepository _bookRepository;

    public ExpireBookReservationsHandler(IReservedBookRepository reservedBookRepository, IBookRepository bookRepository)
    {
        _reservedBookRepository = reservedBookRepository;
        _bookRepository = bookRepository;
    }

    public async ValueTask HandleAsync(ExpireBookReservations command)
    {
        var books = await _bookRepository.GetWithExpiredReservationsAsync();
        
        foreach (var book in books)
        {
            book.ExpireAll();
        }

        await _bookRepository.SaveManyAsync(books);
    }
}

