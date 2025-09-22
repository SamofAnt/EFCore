// See https://aka.ms/new-console-template for more information
using EFCore.Data;
using Microsoft.EntityFrameworkCore;



//First we need an instance of context
using var context = new FootballLeagueDbContext();

//Select all teams
//GetAllTeams();    

// Select a single record - First one in the list that meets a codition
var team =  await context.Teams.FirstAsync(t=> t.TeamId == 1);
// var team = await context.Teams.FirstOrDefaultAsync(t=> t.TeamId == 1);

//Selecting a single record - First one in the list
//var team = await context.Coaches.FirstAsync();
//var team = await context.Coaches.FirstOrDefaultAsync();

//Selecting a single record - Only one record should be returned
// var team = await context.Teams.SingleAsync(t=> t.TeamId == 1);
//var team = await context.Teams.SingleOrDefaultAsync(t=> t.TeamId == 1);
// var team = await context.Coaches.SingleAsync();

//Selecting based on id
var teamBasedOnId = await context.Teams.FindAsync(5);
if (teamBasedOnId != null)
{
    Console.WriteLine(teamBasedOnId.Name);
}

// Select all teams
// await GetAllTeams();

async Task GetAllTeamsQuerySyntax()
{
    Console.WriteLine("Enter Desired Team: ");
    var searchTerm = Console.ReadLine();
    var teams = await (from team in context.Teams
                       where EF.Functions.Like(team.Name, $"%{searchTerm}%")
                                select team).ToListAsync();
    foreach (var t in teams)
    {
        Console.WriteLine(t.Name);
    }
}

// Select one team
// await GetOneTeam();

// Select all record that meet a condition
// await GetFilteredTeams();

async Task AggregateMethods()
{
    var numberOfTeams = await context.Teams.CountAsync();
    Console.WriteLine($"Number of Teams: {numberOfTeams}");

    var numberOfTeamsCondition = await context.Teams.CountAsync(q => q.TeamId == 1);

    var maxTeams = await context.Teams.MaxAsync(q => q.TeamId);
    var minTeams = await context.Teams.MinAsync(q => q.TeamId);
    var averageTeamId = await context.Teams.AverageAsync(q => q.TeamId);
    var sumOfTeamIds = await context.Teams.SumAsync(q => q.TeamId);
}



async Task GetFilteredTeams()
{
    Console.WriteLine("Enter Desired Team: ");
    var searchTerm = Console.ReadLine(); 
    var teamsFiltered = await context.Teams.Where(q => q.Name == searchTerm)
        .ToListAsync();

    foreach (var item in teamsFiltered)
    {
        Console.WriteLine(item.Name);
    }

    //var partialMatches = await context.Teams.Where(q => q.Name.Contains(searchTerm)).ToListAsync();
    var partialMatches = await context.Teams.Where(q => EF.Functions.Like(q.Name, $"%{searchTerm}%")).ToListAsync();
}

async Task GetAllTeams (){

    var teams = await context.Teams.ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine($"TeamId: {team.TeamId}, Name: {team.Name}, CreatedDate: {team.CreatedDate}");
    }

}

async Task GetOneTeam()
{

    var teamFirst = await context.Coaches.FindAsync();
    if (teamFirst != null)
    {
        Console.WriteLine(teamFirst.Name);
    }

    var teamFirstOrDefault = await context.Coaches.FirstOrDefaultAsync();
    if (teamFirstOrDefault != null)
    {
        Console.WriteLine(teamFirstOrDefault);
    }

    var teamFirstWithCondition = await context.Teams.FirstAsync(team => team.TeamId == 1);
    if(teamFirstWithCondition != null)
    {
        Console.WriteLine(teamFirstWithCondition.Name);
    }

    var teamFirstOfDefaultWithCondition = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 1);
    if (teamFirstOfDefaultWithCondition != null)
    {
        Console.WriteLine(teamFirstOfDefaultWithCondition.Name);
    }

    var teamSingle = await context.Teams.SingleAsync();
    if (teamSingle != null)
    {
        Console.WriteLine(teamSingle.Name);
    }

    var teamSingleWithCondition = await context.Teams.SingleAsync(team => team.TeamId == 2);
    if (teamSingleWithCondition != null)
    {
        Console.WriteLine(teamSingleWithCondition.Name);
    }
    var SingleOfDefault = await context.Teams.SingleOrDefaultAsync(team => team.TeamId == 2);
    if (SingleOfDefault != null)
    {
        Console.WriteLine(SingleOfDefault.Name);
    }

    var teamBasedOnId = await context.Teams.FindAsync(3);
    if (teamBasedOnId != null)
    {
        Console.WriteLine(teamBasedOnId.Name);
    }

}