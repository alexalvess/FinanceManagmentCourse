using Domain.Modules.Budgets.Aggreagates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Transactions;

namespace Infrastructure.SqlServer.Databases.Configurations.Budgets;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.ToTable(nameof(Budget));

        builder.HasKey(budget => budget.Id);

        builder
            .Property(prop => prop.ReferencePeriod)
            .HasConversion(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime));

        builder
            .OwnsMany(
                account => account.Categories,
                categoryNavigationBuilder =>
                {
                    categoryNavigationBuilder.ToTable(nameof(Category));

                    categoryNavigationBuilder.Property<int>("Id").IsRequired();
                    categoryNavigationBuilder.HasKey("Id");

                    categoryNavigationBuilder
                        .OwnsMany(
                            account => account.Transactions,
                            transactionNavigationBuilder =>
                            {
                                transactionNavigationBuilder.ToTable(nameof(Transaction));

                                transactionNavigationBuilder.Property<int>("Id").IsRequired();
                                transactionNavigationBuilder.HasKey("Id");
                            }
                        );
                }
            );
    }
}
