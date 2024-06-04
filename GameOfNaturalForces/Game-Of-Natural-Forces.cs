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
            Console.WriteLine();
            Console.WriteLine("Choices: 1 for Water, 2 for Fire, 3 for Air:");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

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

            //Displaying Choices
            Console.WriteLine($"Your Choice is: {choicePlayer}");
            Console.WriteLine($"Computer's Choice is: {choiceComputer} ");

            //Displaying the results
            string result = Winner(choicePlayer, choiceComputer);
            Console.WriteLine(result);

            //infinite loop if you want to play again
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to play again?");
                Console.WriteLine();
                Console.Write("Choose: Yes or No:");
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    Console.Write("Enter your choice: ");
                    choicePlayerInt = int.Parse(Console.ReadLine());
                    choicePlayer = (Choice)choicePlayerInt;
                    choiceComputer = (Choice)random.Next(1, 4);
                    Console.WriteLine();
                    Console.WriteLine($"Your Choice is: {choicePlayer}");
                    Console.WriteLine($"Computer's Choice is: {choiceComputer} ");
                    result = Winner(choicePlayer, choiceComputer);
                    Console.WriteLine(result);
                }
                else if (answer == "No")
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
            else if (player == Choice.Air && computer == Choice.Fire)
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

