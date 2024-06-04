using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNaturalForces
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
            Console.WriteLine("You have 6 rounds");
            Console.WriteLine();
            Console.WriteLine("Choices: 1 for Water, 2 for Fire, 3 for Air:");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            //Starting score/rounds
            int rounds = 6;
            int yourScore = 0;
            int computerScore = 0;

            //Player's Choice
            int choicePlayerInt = int.Parse(Console.ReadLine());
            Choice choicePlayer = (Choice)choicePlayerInt;

            // if number of choice is higher then the recommended
            if (choicePlayerInt > 3)
            {
                Console.WriteLine("Your choice is invalid, type a number between 1 and 3\nTry again!");
                Environment.Exit(0);
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
            Console.WriteLine($"Rounds left: {rounds}");

            //infinite loop if you want to play again
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to continue?");
                Console.WriteLine();
                Console.Write("Choose: Yes or No:");
                string answear = Console.ReadLine();
                if (answear == "Yes")
                {
                    Console.Write("Enter your choice: ");
                    choicePlayerInt = int.Parse(Console.ReadLine());
                    choicePlayer = (Choice)choicePlayerInt;
                    choiceComputer = (Choice)random.Next(1, 4);
                    if (choicePlayerInt > 3)
                    {
                        Console.WriteLine("Your choice is invalid, type a number between 1 and 3\nTry again!");
                        Environment.Exit(0);
                    }
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
                    Console.WriteLine();
                    Console.WriteLine($"Your Choice is: {choicePlayer}");
                    Console.WriteLine($"Computer's Choice is: {choiceComputer} ");
                    result = Winner(choicePlayer, choiceComputer);
                    Console.WriteLine(result);

                    //Displaying the winner
                    if (rounds == 0)
                    {
                        if (yourScore > computerScore)
                        {
                            Console.WriteLine($"You are the winner with {yourScore} points.");
                            Console.WriteLine();
                            Console.WriteLine($"Computer lost, leaving it with {computerScore} points.");
                            Environment.Exit(0);
                        }
                        else if (yourScore < computerScore)
                        {
                            Console.WriteLine($"Computer is the winner with {computerScore} points.");
                            Console.WriteLine();
                            Console.WriteLine($"You lost leaving you with {yourScore} points.");
                            Environment.Exit(0);
                        }
                        else if (yourScore == computerScore)
                        {
                            Console.WriteLine("It's a Tie!");
                            Console.WriteLine($"Computer's score is: {computerScore}");
                            Console.WriteLine($"Your score is: {yourScore}");
                            Environment.Exit(0);
                        }
                    }
                    Console.WriteLine($"Rounds left: {rounds}");

                }
                else if (answear == "No")
                {
                    Console.WriteLine("Computer Wins! You decided to leave!");
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
        //Method for choosing the winner
        static string Winner(Choice player, Choice computer)
        {
            if (player == Choice.Air && player == computer)
            {
                return "You both unleashed a whirlwind, It's a Tie!";
            }
            else if (player == Choice.Fire && player == computer)
            {
                return "You both went down in flames, It's a Tie!";
            }
            if (player == Choice.Water && player == computer)
            {
                return "You both got swept under in the final wave, It's a Tie!";
            }
            if (player == Choice.Water && computer == Choice.Fire)
            {
                return "The Computer is drowned, You Win!";
            }
            else if (player == Choice.Air && (computer == Choice.Fire || computer == Choice.Water))
            {
                return "The Computer is blown, You Win!";
            }
            else
            {
                return "You lose, Computer wins!";

            }
        }
    }
}
