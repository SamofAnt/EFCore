// See https://aka.ms/new-console-template for more information
using EFCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

//Select all teams
//GetAllTeams();    

// Select a single record - First one in the list 
var team =  await context.Teams.FirstAsync(t=> t.TeamId == 1);



void GetAllTeams (){

    var teams = context.Teams.ToList();

    foreach (var team in teams)
    {
        Console.WriteLine($"TeamId: {team.TeamId}, Name: {team.Name}, CreatedDate: {team.CreatedDate}");
    }

}