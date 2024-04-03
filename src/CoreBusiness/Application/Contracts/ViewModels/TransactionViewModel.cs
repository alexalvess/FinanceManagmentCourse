namespace Application.Contracts.ViewModels;

public record TransactionViewModel(Guid AccountId, string Category, DateTime CreateAt, string Description, decimal Value)
{
}
