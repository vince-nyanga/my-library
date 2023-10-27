using MyLibrary.Application.Abstractions.Commands;

namespace MyLibrary.Application.Commands.Books;

public sealed record AddBook(Guid Id, string Title, ushort TotalCopies) : ICommand;