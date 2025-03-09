using GameOfNaturalForces_Update.Players;

namespace GameOfNaturalForces_Update;

public class Computer : Player
{
    private static readonly Random random = new();
    private static readonly string[] choices = { "Air", "Water", "Fire" };

    public Computer() : base("Computer") { }

    public string RandomChoice() => choices[random.Next(choices.Length)];
    
}