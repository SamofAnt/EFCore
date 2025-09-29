namespace EFCore.Domain;

public class Team: BaseDomainModel
{

    public string? Name { get; set; }

    public int LeagueId { get; set; }

    public int CoachId { get; set; }
}

public class Match : BaseDomainModel
{
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }

    public DateTime MatchDate { get; set; }
    public decimal TicketPrice { get; set; }
}