namespace MyLibrary.Domain.Abstractions;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }
}