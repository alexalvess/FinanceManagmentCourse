namespace Application.Abstractions.Contracts;

public abstract record Message : ICommand
{
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.Now;
}
