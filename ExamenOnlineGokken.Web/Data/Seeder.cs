using ExamenOnlineGokken.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOnlineGokken.Data
{
    public class Seeder
    {
        public static void Seed (ModelBuilder modelBuilder)
        {
            //add Leagues HERE
            //
            // \M/
            //
            var games = new Game[]
            {
                //Serie A
                new Game {Id=1,Hometeam="Juventus",AwayTeam="Cagliari",DateOfGame=new DateTime(2020,01,20,15,30,00)/*Link to leagueId here*/ },
                new Game {Id=2,Hometeam="Inter",AwayTeam="Pescara",DateOfGame=new DateTime(2020,01,21,18,30,00)/*Link to leagueId here*/ },
                new Game {Id=3,Hometeam="Napoli",AwayTeam="Cagliari",DateOfGame=new DateTime(2020,01,20,15,30,00)/*Link to leagueId here*/ },
                new Game {Id=4,Hometeam="Milan",AwayTeam="Bologna",DateOfGame=new DateTime(2020,01,20,20,30,00)/*Link to leagueId here*/ },
                //Jupiler League
                new Game {Id=5,Hometeam="Club Brugge",AwayTeam="Cercle Brugge",DateOfGame=new DateTime(2020,01,23,13,30,00)/*Link to leagueId here*/ },
                new Game {Id=6,Hometeam="KRC Genk",AwayTeam="AA Gent",DateOfGame=new DateTime(2020,01,23,18,30,00)/*Link to leagueId here*/ },
                new Game {Id=7,Hometeam="Standard",AwayTeam="FC Antwerp",DateOfGame=new DateTime(2020,01,23,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=8,Hometeam="Club Brugge",AwayTeam="Cercle Brugge",DateOfGame=new DateTime(2020,01,23,13,30,00)/*Link to leagueId here*/ },
                //UEFA Champions League
                new Game {Id=9,Hometeam="Atletico Madrid",AwayTeam="Liverpool",DateOfGame=new DateTime(2020,02,18,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=10,Hometeam="Atalanta",AwayTeam="Valencia",DateOfGame=new DateTime(2020,02,19,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=11,Hometeam="Chelsea",AwayTeam="Bayern",DateOfGame=new DateTime(2020,02,19,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=12,Hometeam="Napoli",AwayTeam="Barcelona",DateOfGame=new DateTime(2020,02,25,21,00,00)/*Link to leagueId here*/ },
                //UEFA Europa League
                new Game {Id=13,Hometeam="Ludogorets",AwayTeam="Inter Milan",DateOfGame=new DateTime(2020,02,20,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=14,Hometeam="Club Brugge",AwayTeam="Man United",DateOfGame=new DateTime(2020,02,20,21,30,00)/*Link to leagueId here*/ },
                new Game {Id=15,Hometeam="AA Gent",AwayTeam="AS Roma",DateOfGame=new DateTime(2020,02,27,20,30,00)/*Link to leagueId here*/ },
                new Game {Id=16,Hometeam="Olympiacos",AwayTeam="Arsenal",DateOfGame=new DateTime(2020,02,21,20,30,00)/*Link to leagueId here*/ },

            };

            var users = new User[]
            {
                new User{Id=1,UserName="Mileto",Password="qsdflkjqmlj43ézearf"},
                new User{Id=2,UserName="Bart",Password="qsdflkjqmlj43ézearf"},
                new User{Id=3,UserName="William",Password="qsdflkjqmlj43ézearf"},
                new User{Id=4,UserName="Siegfried",Password="qsdflkjqmlj43ézearf"},
                new User{Id=5,UserName="Joachim",Password="qsdflkjqmlj43ézearf"},
            };
            var bets = new Bet[]
            {
                new Bet{UserId=users[0].Id,GameId = games[0].Id },
                new Bet{UserId=users[0].Id,GameId = games[5].Id },
                new Bet{UserId=users[0].Id,GameId = games[9].Id },
                new Bet{UserId=users[1].Id,GameId = games[8].Id },
                new Bet{UserId=users[1].Id,GameId = games[10].Id },
                new Bet{UserId=users[1].Id,GameId = games[11].Id },
                new Bet{UserId=users[2].Id,GameId = games[15].Id },
                new Bet{UserId=users[2].Id,GameId = games[7].Id },
                new Bet{UserId=users[2].Id,GameId = games[12].Id },
                new Bet{UserId=users[2].Id,GameId = games[13].Id },
                new Bet{UserId=users[3].Id,GameId = games[2].Id },
            };

            modelBuilder.Entity<Game>().HasData(games);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Bet>().HasData(bets);
        }
    }
}
