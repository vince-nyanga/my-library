using MyLibrary.Query.Abstractions;
using MyLibrary.Query.Models;

namespace MyLibrary.Query.Books;

public record GetAllBooks : IQuery<IReadOnlyCollection<BookReadModel>>;