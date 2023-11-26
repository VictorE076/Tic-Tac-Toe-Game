using System;
using System.Threading;
using System.Diagnostics;
namespace Tic_tac_toe_project
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;//indicates what space the player chose on their turn;
        static int flag;//if the player has one the game is tied or if it can still be played;
        /// <summary>
        /// The function draws the game board;
        /// </summary>
        static void drawboard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[0],spaces[1],spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[3],spaces[4],spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", spaces[6],spaces[7],spaces[8]);
            Console.WriteLine("     |     |     ");
            
        }
        /// <summary>
        /// Check if the game was won, tied or should continue;
        /// </summary>
        /// <returns></returns>
        static int checkwin()
        {
            if(spaces[0] == spaces[1] && spaces[1] == spaces[2] ||//row 1;
               spaces[3] == spaces[4] && spaces[4] == spaces[5] ||//row 2;
               spaces[6] == spaces[7] && spaces[7] == spaces[8] ||//row 3;
               spaces[0] == spaces[3] && spaces[3] == spaces[6] ||//column 1;
               spaces[1] == spaces[4] && spaces[4] == spaces[7] ||//column 2;
               spaces[2] == spaces[5] && spaces[5] == spaces[8] ||//column 3;
               spaces[0] == spaces[4] && spaces[4] == spaces[8] ||//diagonal 1;
               spaces[2] == spaces[4] && spaces[4] == spaces[6])  //diagonal 2;
            {
                return 1;//one player has won the game;
            }
            else if (spaces[0] != '1' &&
                    spaces[1] != '2' &&
                    spaces[2] != '3' &&
                    spaces[3] != '4' &&
                    spaces[4] != '5' &&
                    spaces[5] != '6' &&
                    spaces[6] != '7' &&
                    spaces[7] != '8' &&
                    spaces[8] != '9')
                 {
                    return -1;//tied;
                 }
                 else
                    return 0;//signifying no one won or there wasn't a tie and the game can continue;

                                          
        }
        /// <summary>
        /// This function draws an X on the game board;
        /// </summary>
        /// <param name="position"></param>
        static void drawX(int position)
        {
            spaces[position] = 'X';

        }
        /// <summary>
        /// This f draws an O on the game board;
        /// </summary>
        /// <param name="position"></param>
        static void drawO(int position)
        {
            spaces[position] = 'O';
        }
        /// <summary>
        /// The main game loop;
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //string b = Console.ReadLine();
            //char c = Convert.ToChar(b);
            //System.Diagnostics.Debug.WriteLine(c);
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : X and Player 2 : O" + "\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn ");

                }
                else
                {
                    Console.WriteLine("Player 1's turn ");
                }

                Console.WriteLine("\n");
                drawboard();
                choice = int.Parse(Console.ReadLine());//int.Parse(...)is used to readline an int variable;
                
                choice--;
                if (spaces[choice] != 'X' && spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        drawO(choice);
                    }
                    else
                    {
                        drawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("sorry the row {0} is already marked with {1} \n", choice + 1, spaces[choice]);
                    Console.WriteLine("please wait 2 seconds board is loading again...");
                    Thread.Sleep(2000);

                }
                flag = checkwin();

            } while (flag != 1 && flag != -1);

            Console.Clear();
            drawboard();

            if(flag == 1)
            {
                Console.WriteLine("PLayer {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Tie game!");
            }
            
            Console.ReadLine();
            
        }
    }
}
