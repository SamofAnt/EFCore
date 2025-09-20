// See https://aka.ms/new-console-template for more information
using EFCore.Data;

var context = new FootballLeagueDbContext();

//Select all teams

var teams = context.Teams.ToList();

foreach (var team in teams)
{
    Console.WriteLine($"TeamId: {team.TeamId}, Name: {team.Name}, CreatedDate: {team.CreatedDate}");
}