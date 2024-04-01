namespace Application.Abstractions.Contracts;

public abstract class Message : ICommand
{
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.Now;
}
