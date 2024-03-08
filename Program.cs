using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controls();
            void Controls()
            {

                Console.WriteLine("Here are the controls for Tic Tac Toe:");
                Console.WriteLine("\nTop line is 7 - 9 on keyboard.");
                Console.WriteLine("\nMiddle line is 4 - 6 on keyboard.");
                Console.WriteLine("\nBottom line is 1 - 3 on keyboard.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }

            TicTacToe game = new TicTacToe();
        }
         public class TicTacToe
        {
            string[] Board = new string[9];
            int moveCount = 0;

            public TicTacToe()
            {

                RunGame();
            }
            void UpdateBoard()
            {

                Console.WriteLine($"\n {Board[6]} | {Board[7]} | {Board[8]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {Board[3]} | {Board[4]} | {Board[5]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {Board[0]} | {Board[1]} | {Board[2]} ");

            }
            void XTurn()
            {
                while (true)
                {
                    Console.WriteLine("\nIt's X's turn.");
                    UpdateBoard();
                    string input = Console.ReadLine();
                    try
                    {
                        int xInput = int.Parse(input) - 1;
                        if (xInput < 0 || xInput >= 9)
                        {
                            Console.WriteLine("Please enter a number from 1 - 9.");
                            continue; // Continue to check for prompt again
                        }
                        if (Board[xInput] != "O" && Board[xInput] != "X")
                        {
                            Board[xInput] = "X";
                            moveCount += 1;
                            break; // If valid input, break out of loop for O's turn.
                        }
                        else
                        {
                            // Note to self: No need for continue, since there is no more code to execute within the loop.
                            Console.Beep();
                            Console.WriteLine("Please select another square!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Beep();
                        Console.WriteLine("That is not a number. Please enter a number from 1 - 9.");
                    }
                }


            }
            void OTurn()
            {
                // Same as XTurn logic, but with a different variable name.
                while (true)
                {
                    Console.WriteLine("\nIt's O's turn.");
                    UpdateBoard();
                    string input = Console.ReadLine();
                    try
                    {
                        int oInput = int.Parse(input) - 1;
                        if (oInput < 0 || oInput >= 9)
                        {
                            Console.WriteLine("Please enter a number from 1 - 9");
                            continue;
                        }
                        if (Board[oInput] != "X" && Board[oInput] != "O")
                        {
                            Board[oInput] = "O";
                            moveCount += 1;
                            break;
                        }

                        else
                        {
                            Console.Beep();
                            Console.WriteLine("Please select another square!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Beep();
                        Console.WriteLine("That is not a number. Please enter a number from 1 - 9.");
                    }
                }
            }
            void RunGame()
            {
                // Main loop for the game, initialize the board with empty spaces
                for (int i = 0; i < 9; i++)
                {
                    Board[i] = " ";
                }
                while (true)
                {
                    // Once player X or O has had a turn, check for victory using a bool, if there is a winner,
                    // display that and break out of the main game loop.

                    XTurn();

                    if (CheckWin("X"))
                    {
                        UpdateBoard();
                        Console.WriteLine("X is the winner!");
                        Thread.Sleep(1000);
                        break;
                    }
                    if (CheckTie())
                    {
                        UpdateBoard();
                        Console.WriteLine("It's a tie!");
                        Thread.Sleep(1000);
                        break;
                    }
                    OTurn();

                    if (CheckWin("O"))
                    {
                        UpdateBoard();
                        Console.WriteLine("O is the winner!");
                        Thread.Sleep(1000);
                        break;
                    }
                    if (CheckTie())
                    {
                        UpdateBoard();
                        Console.WriteLine("It's a tie!");
                        Thread.Sleep(1000);
                        break;
                    }
                }

            }


            bool CheckTie()
            {
                if (moveCount == 9 && !CheckWin("X") && !CheckWin("O"))
                {
                    return true;
                }

                return false;
            }
            bool CheckWin(string player)
            {
                // Check for vertical victories
                for (int i = 0; i < 3; i++)
                {
                    if (Board[i] == player && Board[i + 3] == player && Board[i + 6] == player)
                    {
                        return true;
                    }
                }

                // Check for horizontal victories
                for (int i = 0; i < 7; i += 3)
                {
                    if (Board[i] == player && Board[i + 1] == player && Board[i + 2] == player)
                    {
                        return true;
                    }
                }



                // Check for diagonal victories
                if ((Board[0] == player && Board[4] == player && Board[8] == player) ||
                    (Board[2] == player && Board[4] == player && Board[6] == player))
                {
                    return true;
                }



                // If there is no winner, return false to continue the game.
                return false;

            }

        }

    }
}

