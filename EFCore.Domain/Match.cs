namespace EFCore.Domain;

public class Match : BaseDomainModel
{
    public int HomeTeamId { get; set; }
    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; }
    public int AwayTeamId { get; set; }

    public DateTime MatchDate { get; set; }
    public decimal TicketPrice { get; set; }

    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
}