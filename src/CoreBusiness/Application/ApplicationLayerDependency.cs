using Application.Abstractions.Ports.Handlers;
using Application.Contracts;
using Application.Modules.Accounts.CommandHandles;
using Application.Modules.Budgtes.CommandHandles;
using Application.Modules.Budgtes.QueryHandles;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationLayerDependency
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<Command.CreateAccountCommand>, CreateAccountHandler>();
        services.AddTransient<ICommandHandler<Command.RegisterBudgetCommand>, RegisterBudgetHandler>();
        services.AddTransient<ICommandHandler<Command.AddCategoryCommand>, AddCategoryHandler>();
        
        services.AddTransient<IQueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>>, ListCategoryHandler>();
    }
}
