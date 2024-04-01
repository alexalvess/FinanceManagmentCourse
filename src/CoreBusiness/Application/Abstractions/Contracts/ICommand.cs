namespace Application.Abstractions.Contracts;

public interface ICommand
{
    DateTimeOffset Timestamp { get; }
}
