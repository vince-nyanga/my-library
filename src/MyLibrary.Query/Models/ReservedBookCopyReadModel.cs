namespace MyLibrary.Query.Models;

internal class ReservedBookCopyReadModel
{
    public Guid Id { get; init; }
    public Guid BookId { get; init; }
    public string CustomerId { get; init; }
    public DateTimeOffset ExpiryDate { get; init; }
    
    public virtual BookReadModel Book { get; set; }
}