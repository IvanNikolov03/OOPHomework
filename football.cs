using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }
}

class FootballPlayer : Person
{
    public int Number { get; set; }
}

class Goalkeeper : FootballPlayer { }
class Defender : FootballPlayer { }
class Midfielder : FootballPlayer { }
class Striker : FootballPlayer { }

class Coach : Person { }
class Referee : Person { }

class Team
{
    public Coach Coach { get; set; }
    public List<FootballPlayer> Players { get; set; }

    public double GetAverageAge()
    {
        int totalAge = 0;
        foreach (var player in Players)
        {
            totalAge += player.Age;
        }
        return (double)totalAge / Players.Count;
    }
}

class Game
{
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public Referee Referee { get; set; }
    public List<Tuple<int, FootballPlayer>> Goals { get; set; }

    public Game()
    {
        Goals = new List<Tuple<int, FootballPlayer>>();
    }

    public void AddGoal(int minute, FootballPlayer player)
    {
        Goals.Add(new Tuple<int, FootballPlayer>(minute, player));
    }

    public string GetResult()
    {
        int team1Goals = Goals.Count(goal => Team1.Players.Contains(goal.Item2));
        int team2Goals = Goals.Count(goal => Team2.Players.Contains(goal.Item2));

        if (team1Goals > team2Goals)
        {
            return $"{Team1.Coach.Name}'s team won";
        }
        else if (team2Goals > team1Goals)
        {
            return $"{Team2.Coach.Name}'s team won";
        }
        else
        {
            return "It's a draw";
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Goalkeeper player1 = new Goalkeeper { Name = "John", Number = 1, Age = 25, Height = 185 };
        Defender player2 = new Defender { Name = "Mike", Number = 5, Age = 28, Height = 180 };
        Midfielder player3 = new Midfielder { Name = "Tom", Number = 10, Age = 22, Height = 175 };
        Striker player4 = new Striker { Name = "Chris", Number = 9, Age = 30, Height = 190 };

        Coach coach = new Coach { Name = "Alex", Age = 40 };

        Team team1 = new Team { Coach = coach, Players = new List<FootballPlayer> { player1, player2, player3, player4 } };

        Goalkeeper player5 = new Goalkeeper { Name = "Sam", Number = 1, Age = 27, Height = 190 };
        Defender player6 = new Defender { Name = "Ben", Number = 4, Age = 26, Height = 175 };
        Midfielder player7 = new Midfielder { Name = "Jake", Number = 8, Age = 24, Height = 180 };
        Striker player8 = new Striker { Name = "Matt", Number = 7, Age = 29, Height = 185 };

        Team team2 = new Team { Coach = coach, Players = new List<FootballPlayer>
