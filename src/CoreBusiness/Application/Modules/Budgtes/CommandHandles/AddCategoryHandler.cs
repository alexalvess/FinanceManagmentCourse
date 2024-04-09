using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using Domain.Modules.Budgets.Aggreagates;
using Domain.Modules.Budgets.ValueObjects.Categories;

namespace Application.Modules.Budgtes.CommandHandles;

public class AddCategoryHandler : CommandHandler<Command.AddCategoryCommand>
{
    private readonly IFinanceManagementRepository _repository;

    public AddCategoryHandler(IFinanceManagementRepository repository)
        => _repository = repository;

    public override async Task Handle(Command.AddCategoryCommand command, CancellationToken cancellationToken)
    {
        Category category = new(command.Name, command.Limit);
        await _repository.InsertAsync(category, cancellationToken);
    }
}
