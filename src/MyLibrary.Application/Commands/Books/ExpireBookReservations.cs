using MyLibrary.Application.Abstractions.Commands;
using MyLibrary.Application.Repositories;

namespace MyLibrary.Application.Commands.Books;

public sealed record ExpireBookReservations : ICommand;

internal sealed class ExpireBookReservationsHandler : ICommandHandler<ExpireBookReservations>
{
    private readonly IBookRepository _bookRepository;

    public ExpireBookReservationsHandler(IBookRepository bookRepository)
        => _bookRepository = bookRepository;

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

