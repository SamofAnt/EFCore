namespace EFCore.Domain;

public class League : BaseDomainModel
{
    public string? Name { get; set; }
    public IList<Team>? Teams { get; set; } = new List<Team>();
}