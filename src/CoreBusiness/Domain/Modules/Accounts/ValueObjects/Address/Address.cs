using Domain.Modules.Accounts.Aggregates;

namespace Domain.Modules.Accounts.ValueObjects.Address;

public record Address(string Street, string City, string State, string ZepCode, string Country, int? Number, string? Complement)
{
}
