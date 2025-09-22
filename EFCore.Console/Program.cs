// See https://aka.ms/new-console-template for more information
using EFCore.Data;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;



//First we need an instance of context
using var context = new FootballLeagueDbContext();

//Select all teams
//GetAllTeams();    

// Select a single record - First one in the list that meets a codition
//var team =  await context.Teams.FirstAsync(t=> t.TeamId == 1);
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


// await AggregateMethods();

// Grouping and Aggregating
// GroupByMethod();

Console.WriteLine("Enter '1' for Team with Id 1 or '2' for teams that contain 'F.C");
var option = Convert.ToInt32(Console.ReadLine());
List<Team> teamAsList = new List<Team>();

teamAsList = await context.Teams.ToListAsync();
if (option == 1)
{
    teamAsList = teamAsList.Where(q => q.TeamId == 1).ToList();
}
else if (option == 2)
{
    teamAsList = teamAsList.Where(q => q.Name.Contains("F.C.")).ToList();
}

foreach (var team in teamAsList)
{
    Console.WriteLine(team.Name);
}

var teamAsQueryable = context.Teams.AsQueryable();
if (option == 1)
{
    teamAsQueryable = teamAsQueryable.Where(q => q.TeamId == 1);
}
else if (option == 2)
{
    teamAsQueryable = teamAsQueryable.Where(q => q.Name.Contains("F.C."));
}
var finalTeamList = await teamAsQueryable.ToListAsync();
foreach (var team in finalTeamList)
{
    Console.WriteLine(team.Name);
}

//Select and Projecting

async Task SelectAndProjection()
    {


        var teams = await context.Teams
            .Select(q => new { q.Name, q.CreatedDate })
            .ToListAsync();

        foreach (var team in teams)
        {
            Console.WriteLine($"{team.Name} - {team.CreatedDate}");
        }
        //Skip and Take
    }

async Task SkipAndTake()
{
    var recordCount = 3;
    var page = 0;
    var next = true;

    while (next)
    {
        var teams = await context.Teams.Skip(page * recordCount).Take(recordCount).ToListAsync();

        foreach (var team in teams)
        {
            Console.WriteLine(team.Name);
        }

        Console.WriteLine("Enter 'true' for the next set of records, 'false' for exit");
        next = Convert.ToBoolean(Console.ReadLine());

        if(!next ) break;
        page++;
    }
}

// Order By
async Task OrderByMethods()
{
    var orderedTeams = await context.Teams
        .OrderBy(q => q.Name)
        .ToListAsync();


    var descPrderedTeams = await context.Teams
        .OrderByDescending(q => q.Name)
        .ToListAsync();
}



void GroupByMethod()
{
    // Grouping teams by CreatedDate
    var groupedTeams = context.Teams
        .GroupBy(q => q.CreatedDate.Date);
    foreach (var group in groupedTeams)
    {
        Console.WriteLine(group.Key);
        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }
}


// Aggregate functions
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