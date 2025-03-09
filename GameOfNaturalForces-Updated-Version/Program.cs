using GameOfNaturalForces_Update.Players;

namespace GameOfNaturalForces_Update;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter your username: ");
            string? username = Console.ReadLine();
            User user = new User(username!);
            Game game = new Game(user);
            game.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}