using GameOfNaturalForces;

namespace GameOfNaturalForces_Update.Players;

public abstract class Player : IPlayer
{
    public int Score { get; protected set; }
    public string Name { get; protected set; }

    protected Player(string name)
    {
        Name = name;
        Score = 0;
    }

    public void IncreaseScore() => Score++;

    public static void ShowCurrentScores(User user, Computer computer)
    {
        Console.WriteLine($"\nCurrent Scores:");
        Console.WriteLine($"User ({user.Name}): {user.Score}");
        Console.WriteLine($"Computer: {computer.Score}\n");
    }
}