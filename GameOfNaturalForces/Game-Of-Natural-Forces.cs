using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace receipt
{
    class Program
    {
        enum Choice //Representing the choices
        {
            Water = 1,
            Fire = 2,
            Air = 3,
        }
        static void Main(string[] args)
        {
            //Instructions
            Console.WriteLine("Welcome to my game of Natural Forces!");
            Console.WriteLine();
            Console.WriteLine("Your mission is to choose one natural force and try to beat the computer, good luck!");
            Console.WriteLine("You have [6] rounds");
            Console.WriteLine();
            Console.WriteLine("Choices: [1] for Water, [2] for Fire, [3] for Air:");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            //Starting score/rounds
            int rounds = 6;
            int yourScore = 0;
            int computerScore = 0;
            while (true)
            {
                try
                {
                //Player's Choice
                int choicePlayerInt = int.Parse(Console.ReadLine());
                Choice choicePlayer = (Choice)choicePlayerInt;
                //If number of choice is higher then the recommended
                if (choicePlayerInt > 3)
                {
                        Console.WriteLine($"You typed number [{choicePlayerInt}]");
                    Console.WriteLine("Your choice is invalid, type a number between 1 and 3\nTry again!");
                        Console.Write("Enter your chooice: ");
                        continue;
                }
                //Computer's Choice
                Random random = new Random();
                Choice choiceComputer = (Choice)random.Next(1, 4);
                //Collecting the points
                if ((choiceComputer == Choice.Air &&
                             choicePlayer == Choice.Fire) ||
                             (choiceComputer == Choice.Water &&
                             choicePlayer == Choice.Fire) ||
                             (choicePlayer == Choice.Water &&
                                 choiceComputer == Choice.Air))
                {
                    computerScore += 1;
                }
                if ((choicePlayer == Choice.Air &&
                    choiceComputer == Choice.Fire) ||
                    (choicePlayer == Choice.Water &&
                    choiceComputer == Choice.Fire) ||
                        (choicePlayer == Choice.Air &&
                        choiceComputer == Choice.Water))
                {
                    yourScore += 1;
                }
                rounds -= 1;
                //Displaying Choices
                Console.WriteLine($"Your Choice is: {choicePlayer}");
                Console.WriteLine($"Computer's Choice is: {choiceComputer} ");

                //Displaying the results
                string result = Winner(choicePlayer, choiceComputer);
                Console.WriteLine(result);
                Console.WriteLine();

                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input!\nTry again!");
                    Console.Write("Enter your choice:");
                    continue;
                }

                if (rounds >= 1)
                {
                    Console.WriteLine($"Rounds left: [{rounds}]");
                    Console.Write("Enter your next move:");
                }
                if (rounds == 0)
                {
                    Console.WriteLine("Game has finsihed!");
                    Console.WriteLine();
                    if (yourScore > computerScore)
                    {
                        Console.WriteLine($"You are the winner with {yourScore} points.");
                        Console.WriteLine();
                        if (computerScore ==1)
                        {
                        Console.WriteLine($"Computer lost, leaving it with {computerScore} point.");
                        }
                        else
                        {
                            Console.WriteLine($"Computer lost, leaving it with {computerScore} points.");
                        }
                    }
                    else if (yourScore < computerScore)
                    {
                        Console.WriteLine($"Computer is the winner with {computerScore} points.");
                        Console.WriteLine();
                        if (yourScore == 1)
                        {
                        Console.WriteLine($"You lost leaving you with {yourScore} point.");
                        }
                        else
                        {
                            Console.WriteLine($"You lost leaving you with {yourScore} points.");
                        }

                    }
                    else if (yourScore == computerScore)
                    {
                        Console.WriteLine("It's a Tie!");
                        Console.WriteLine($"Computer's score is: [{computerScore}]");
                        Console.WriteLine($"Your score is: [{yourScore}]");
                    }
                    Console.WriteLine("Do you want to play again?");
                    Console.WriteLine();
                    Console.Write("Choose: Yes or No:");
                    string answear = Console.ReadLine();
                    if (answear == "Yes")
                    {
                        rounds = 6;
                        yourScore = 0;
                        computerScore = 0;
                        Console.WriteLine("Enter your choice:");
                        continue;
                    }
                    else if (answear == "No")
                    {
                        Console.WriteLine("That was your final battle!\nThank you for playing!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Unknown answear!");
                        Environment.Exit(0);
                    }

                }
            }
        }
        //Method for choosing the winner
        static string Winner(Choice player, Choice computer)
        {
            if (player == Choice.Air && player == computer)
            {
                Console.WriteLine();
                return "You both unleashed a whirlwind, It's a Tie!";
            }
            else if (player == Choice.Fire && player == computer)
            {
                Console.WriteLine();
                return "You both went down in flames, It's a Tie!";
            }
            if (player == Choice.Water && player == computer)
            {
                Console.WriteLine();
                return "You both got swept under in the final wave, It's a Tie!";
            }
            if (player == Choice.Water && computer == Choice.Fire)
            {
                Console.WriteLine();
                return "The Computer is drowned, You Win!";
            }
            else if (player == Choice.Air && (computer == Choice.Fire || computer == Choice.Water))
            {
                Console.WriteLine();
                return "The Computer is blown, You Win!";
            }
            else
            {
                Console.WriteLine();
                return "You lose, Computer wins!";

            }

        }
    }
}


