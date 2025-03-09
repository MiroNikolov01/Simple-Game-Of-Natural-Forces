using GameOfNaturalForces_Update.Players;

namespace GameOfNaturalForces_Update;

public class Game
{
    private readonly User _user;
    private readonly Computer _computer;
    private int _rounds = 6;

    private static readonly Dictionary<string, List<string>> WinningMap = new()
    {
        { "Air", new List<string> { "Fire", "Water" } },
        { "Water", new List<string> { "Fire", "Air" } },
        { "Fire", new List<string> { "Air", "Water" } }
    };

    public Game(User user)
    {
        this._user = user;
        this._computer = new Computer();
    }

    public void Start()
    {
        Console.WriteLine($"\nWelcome {_user.Name} to the Game of Natural Forces!");
        Console.WriteLine("Your mission is to choose a natural force and try to beat the computer.");
        Console.WriteLine($"You have {_rounds} rounds.\n");

        while (_rounds > 0)
        {
            string playerChoice = _user.ChooseMove(Choice.Choices);
            string computerChoice = _computer.RandomChoice();

            Console.WriteLine($"\nYour choice: {playerChoice}");
            Console.WriteLine($"Computer's choice: {computerChoice}\n");

            string result = DetermineWinner(playerChoice, computerChoice);
            Console.WriteLine(result);

            Player.ShowCurrentScores(_user, _computer);
            _rounds--;

            if (_rounds > 0)
            {
                Console.WriteLine($"Rounds left: {_rounds}\n");
            }
        }

        EndGame();
    }

    private string DetermineWinner(string playerChoice, string computerChoice)
    {
        if (WinningMap[computerChoice].Contains(playerChoice))
        {
            _computer.IncreaseScore();
            return GetLossMessage(playerChoice, computerChoice);
        }

        if (WinningMap[playerChoice].Contains(computerChoice))
        {
            _user.IncreaseScore();
            return GetWinMessage(playerChoice, computerChoice);
        }

        return "It's a tie!";
    }

    private string GetWinMessage(string playerChoice, string computerChoice)
    {
        if (playerChoice == "Air" && computerChoice == "Fire")
        {
            return "Air blows out the flames! You win this round!";
        }

        if (playerChoice == "Fire" && computerChoice == "Water")
        {
            return "Fire evaporates the water! You win this round!";
        }

        if (playerChoice == "Water" && computerChoice == "Air")
        {
            return "Water douses the air's winds! You win this round!";
        }

        return $"You win this round! {playerChoice} beats {computerChoice}.";
    }

    private string GetLossMessage(string playerChoice, string computerChoice)
    {
        if (computerChoice == "Air" && playerChoice == "Fire")
        {
            return "Air blows out your flames! You lose this round!";
        }

        if (computerChoice == "Fire" && playerChoice == "Water")
        {
            return "Fire evaporates your water! You lose this round!";
        }

        if (computerChoice == "Water" && playerChoice == "Air")
        {
            return "Water douses the air's winds! You lose this round!";
        }

        return $"You lose this round! {computerChoice} beats {playerChoice}.";
    }

    private void EndGame()
    {
        Console.WriteLine("\nGame Over!");

        if (_user.Score > _computer.Score)
        {
            Console.WriteLine($"Congratulations {_user.Name}, you are the winner with {_user.Score} points!");
        }
        else if (_user.Score < _computer.Score)
        {
            Console.WriteLine($"Computer wins with {_computer.Score} points!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }

        Console.Write("\nDo you want to play again? (Yes/No): ");
        string? answer = Console.ReadLine()?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(answer)) Console.WriteLine("Invalid answer.");
        if (answer == "yes")
        {
            new Game(_user).Start();
        }
        else
        {
            Console.WriteLine($"Thanks for playing {this._user.Name}!");
            Environment.Exit(0);
        }
    }
}