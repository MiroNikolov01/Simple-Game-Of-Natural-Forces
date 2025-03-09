namespace GameOfNaturalForces_Update.Players;

public class User : Player
{
    public User(string username) : base(username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be empty.");
        }
    }

    public string ChooseMove(Dictionary<int, string> choices)
    {
        while (true)
        {
            Console.Write("Enter your choice: ([1] - Air, [2] - Water, [3] - Fire): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || !choices.ContainsKey(choice))
            {
                Console.WriteLine("Invalid choice! Type a number between 1 and 3.");
                continue;
            }

            return choices[choice];
        }
    }
   
}