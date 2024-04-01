using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profile;
using Domain.Modules.Accounts.ValueObjects.Address;
using Domain.Modules.Accounts.ValueObjects.Transactions;
using Domain.Modules.Budgets.Aggreagates;
using Domain.Modules.Budgets.ValueObjects.Categories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SqlServer.Databases.Contexts;

public class FinanceManagmentContext : DbContext
{
    #region Account
    public DbSet<Account> Accounts { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
	#endregion

	#region Budget
	public DbSet<Budget> Budgets { get; set; }

	public DbSet<Category> Categories { get; set; }
	#endregion

	public FinanceManagmentContext(DbContextOptions options) 
		: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
		=> modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		=> configurationBuilder
			.Properties<string>()
			.AreUnicode(false)
			.HaveMaxLength(1024);
}
