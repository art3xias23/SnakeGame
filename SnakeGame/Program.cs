using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Vars
            int[] xPosition = new int[50];
            xPosition[0] = 35;
            int[] yPosition = new int[50];
            yPosition[0] = 20;
            int appleXDim = 10;
            int appleYDim = 10;
            int applesEaten = 0;

            string userAction = "";

            decimal gameSpeed = 150m;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;
            bool isStayInMenu = true;

            Random random = new Random();

            #endregion




            
            // Build Welcome screen
            showMenu(out userAction);

            switch (userAction)
            {
                // Give a player an option to read directions
                #region Change Directions
                case "1":
                case "d":
                case "directions":
                    Console.Clear();
                    buildwall();
                    Console.SetCursorPosition(5, 5);
                    Console.WriteLine("1) Resize the console window so you can see all");
                    Console.SetCursorPosition(5, 6);
                    Console.WriteLine("  4 sides of playing field boarded");
                    Console.SetCursorPosition(5, 7);
                    Console.WriteLine("1) Use the arrow keys to move the snake around the field");
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine("3) The snake will die if it runs into the wall");
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine("4) You gain points by eating the apple");
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine("   But your snake will also go faster and get longer");
                    Console.SetCursorPosition(5, 11);
                    Console.WriteLine("1) Press Enter to return to the main menu");
                    Console.ReadLine();
                    Console.Clear();
                    showMenu(out userAction);
                    break;

                # endregion

                #region Case Play
                case "2":
                case "p":
                case "play":

                    #region GameSetup

                    //Get the snake to appear on screen

                    paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

                    //Get the apple to appear on the screen
                    setApplePositionOnScreen(random, out appleXDim, out appleYDim);
                    paintApple(appleXDim, appleYDim);

                    //Build boundary

                    buildwall();

                    // Get the snake to move

                    ConsoleKey command = Console.ReadKey().Key;

                    #endregion


                    do
                    {
                        #region ChangeDirections
                        switch (command)
                        {

                            case ConsoleKey.LeftArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                xPosition[0]--;
                                break;
                            case ConsoleKey.UpArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.Write(" ");
                                yPosition[0]--; ;
                                break;
                            case ConsoleKey.RightArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.WriteLine(" ");
                                xPosition[0]++;
                                break;
                            case ConsoleKey.DownArrow:
                                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                                Console.WriteLine(" ");
                                yPosition[0]++;
                                break;


                        }
                        #endregion

                        #region Game

                        //Paint the snake, Make snake longer
                        paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);


                        isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);


                        //Detect when snake hits boundary
                        if (isWallHit)
                        {
                            isGameOn = false;
                            Console.SetCursorPosition(28, 20);
                            Console.WriteLine("The snake hit a wall and it died");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(15, 21);
                            Console.Write("Your Score is " + applesEaten * 100 + "!");
                            Console.SetCursorPosition(15, 22);
                            Console.WriteLine("Press Enter To Continue.");
                            applesEaten = 0;
                            Console.ReadLine();
                            Console.Clear();
                        }

                        //Detect when apple was eaten
                        isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);


                        // Place apple on the board (random)
                        if (isAppleEaten)
                        {
                            setApplePositionOnScreen(random, out appleXDim, out appleYDim);
                            paintApple(appleXDim, appleYDim);

                            // Keep track of how many apples were eaten
                            applesEaten++;

                            //Make snake faster
                            gameSpeed *= .925m;
                        }




                        if (Console.KeyAvailable) command = Console.ReadKey().Key;
                        //Slow game down
                        System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

                        #endregion

                    } while (isGameOn);

                    break;

                #endregion
                case "3":
                case "e":
                case "exit":

                    isStayInMenu = false;
                    Console.Clear();

                    break;




                default:
                    Console.WriteLine("Your input was not understood, please press enter and try again");
                    Console.ReadLine();
                    Console.Clear();
                    showMenu(out userAction);
                    break;
            }


           

           



            

            //Show score

            //Give option to replay the game



        }
        #region Menu
        private static void showMenu(out string userAction)
        {
            string menu1 = "1) Directions\n  2) Play\n  3) Exit \n\n\n" + @"
            ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '
";
            string menu2 = "1) Directions\n  2) Play\n  3) Exit \n\n\n" + @"   
            ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '
    ";
            string menu3 = "1) Directions\n  2) Play\n  3) Exit \n\n\n" + @"
            ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '
        ";
            string menu4 = "1) Directions\n  2) Play\n  3) Exit \n\n\n" + @"
            ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '
            ";
            string menu5 = "1) Directions\n  2) Play\n  3) Exit \n\n\n" + @"
            ____
      _,.-'`_ o `;__,                
       _.-'` '---'  '
                ";

            Console.WriteLine(menu1);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(menu2);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(menu3);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(menu4);
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(menu5);
            System.Threading.Thread.Sleep(100);

            SpeechSynthesizer toSpeak = new SpeechSynthesizer();
            toSpeak.SetOutputToDefaultAudioDevice();
            toSpeak.Speak("The snake game!");

            userAction = Console.ReadLine().ToLower();


        }
        #endregion

        #region Methods
        private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            //Paint the head
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((char)214);

            //Paint the body
            for (int i=1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            //Erase last part of snake
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            //Record location of each body part
            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }

            //Return the new array
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        } //end paint snake

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
        } //end building the wall

        private static void setApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
        {
            appleXDim = random.Next(0 + 2, 70 - 2);
            appleYDim = random.Next(0 + 2, 40 - 2);
        }

        private static void paintApple(int appleXDim, int appleYDim)
        {
            Console.SetCursorPosition(appleXDim, appleYDim);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write((char)64);
        }

        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
        {
            if (xPosition == appleXDim && yPosition == appleYDim) return true; return false;
        }
        #endregion
    }
}
