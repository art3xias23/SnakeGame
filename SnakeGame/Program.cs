using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int xPosition = 35;
            int yPosition = 20;
            int gameSpeed = 100;

            bool isGameOn = true;
            bool isWallHit = false;

            //Get the snake to appear on screen

            Console.SetCursorPosition(xPosition, yPosition);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)2);

            //Build boundary

            buildwall();


            // Get the snake to move

            ConsoleKey command = Console.ReadKey().Key;

            do
            {

                switch (command)
                {
                   
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        xPosition--;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.Write(" ");
                        yPosition--; ;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        xPosition++;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition, yPosition);
                        Console.WriteLine(" ");
                        yPosition++;
                        break;


                }

                Console.SetCursorPosition(xPosition, yPosition);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((char)2);

                isWallHit = DidSnakeHitWall(xPosition, yPosition);

                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The snake hit a wall and it died");
                }

                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(gameSpeed);

            } while (isGameOn);

            //Detect when snake hits boundary
                //Slow game down

            



            //Make snake faster


            // Make snake longer


            // Keep track of how many apples were eaten

            //End vid 2

            // Build Welcome screen

            // Give a player an option to read directions

            //Show score

            //Give option to replay the game



        }

        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
           
            
        }

        private static void buildwall()
        {
            for(int i =0; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.Write('#');
                Console.SetCursorPosition(70, i);
                Console.Write('#');
            }

            for(int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.Write('#');
                Console.SetCursorPosition(i, 40);
                Console.Write('#');
            }
        }
    }
}
