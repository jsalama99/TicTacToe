using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    public class GameBoard
    {
        // Constructor
        public GameBoard()
        {
        }

        public void Play()
        {
            for (int i = 0; i < maxPrompRetries; i++)
            {
                Console.Write("Enter who (X or Y) will go first: ");
                var turnEntry = getSquareValue(Console.ReadLine());
                if (turnEntry == Square.SquareValue.X || turnEntry == Square.SquareValue.O)
                {
                    turn = turnEntry;
                    break;
                }
                else if (i == maxPrompRetries - 1)
                {
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                }
            }

            while (!gameOver)
            {
                for (int i = 0; i < maxPrompRetries; i++)
                {
                    drawGameBoard();

                    Console.WriteLine("It's {0} turn", turn);
                    Console.Write("Enter numeric index value (0-8) for your turn: ");
                    var pointEntry = Console.ReadLine();

                    if (pointEntry != null)
                    {
                        if (pointEntry.Length == 1)
                        {
                            Regex rx = new Regex("\\d");
                            if (rx.IsMatch(pointEntry))
                            {
                                if (grid[Int32.Parse(pointEntry)] == " ")
                                {
                                    grid[Int32.Parse(pointEntry)] = getSquareStringValue(turn);

                                    // Check to see if game is over
                                    if ((
                                        
                                        (grid[0] == "X" && grid[1] == "X" && grid[2] == "X") ||
                                        (grid[3] == "X" && grid[4] == "X" && grid[5] == "X") ||
                                        (grid[6] == "X" && grid[7] == "X" && grid[8] == "X") ||
                                        (grid[0] == "X" && grid[4] == "X" && grid[8] == "X") ||
                                        (grid[2] == "X" && grid[4] == "X" && grid[6] == "X") ||
                                        (grid[0] == "X" && grid[3] == "X" && grid[6] == "X") ||
                                        (grid[1] == "X" && grid[4] == "X" && grid[7] == "X") ||
                                        (grid[2] == "X" && grid[5] == "X" && grid[8] == "X")

                                        ) ||
                                        (grid[0] == "O" && grid[1] == "O" && grid[2] == "O") ||
                                        (grid[3] == "O" && grid[4] == "O" && grid[5] == "O") ||
                                        (grid[6] == "O" && grid[7] == "O" && grid[8] == "O") ||
                                        (grid[0] == "O" && grid[4] == "O" && grid[8] == "O") ||
                                        (grid[2] == "O" && grid[4] == "O" && grid[6] == "O") ||
                                        (grid[0] == "O" && grid[3] == "O" && grid[6] == "O") ||
                                        (grid[1] == "O" && grid[4] == "O" && grid[7] == "O") ||
                                        (grid[2] == "O" && grid[5] == "O" && grid[8] == "O")
                                        )
                                    {

                                        drawGameBoard();
                                        Console.WriteLine("GAME OVER!!!!");
                                        Console.WriteLine("{0} WON!!!!!!", turn);
                                        gameOver = true;
                                        break;
                                    }

                                    if (turn == Square.SquareValue.X)
                                    {
                                        turn = Square.SquareValue.O;
                                    }
                                    else
                                    {
                                        turn = Square.SquareValue.X;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please tr4y again");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void drawGameBoard()
        {
            Console.WriteLine("Reference");
            Console.WriteLine(" 0 | 1 | 2", grid[0], grid[1], grid[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" 3 | 4 | 5", grid[3], grid[4], grid[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" 6 | 7 | 8", grid[6], grid[7], grid[8]);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(" {0} | {1} | {2}", grid[0], grid[1], grid[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2}", grid[3], grid[4], grid[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2}", grid[6], grid[7], grid[8]);
        }

        private Square.SquareValue getSquareValue(string ?value)
        {
            switch (value)
            {
                case "X":
                    return Square.SquareValue.X;
                case "O":
                    return Square.SquareValue.O;
                case " ":
                    return Square.SquareValue.Blank;
                default:
                    return Square.SquareValue.Blank;
            }
        }

        private string getSquareStringValue(Square.SquareValue value)
        {
            switch (value)
            {
                case Square.SquareValue.X:
                    return "X";
                case Square.SquareValue.O:
                    return "O";
                case Square.SquareValue.Blank:
                    return " ";
                default:
                    return " ";
            }
        }

        private bool gameOver = false;
        private Square.SquareValue turn = Square.SquareValue.Blank;
        private int maxPrompRetries = 3;

        private string[] grid = new string[] {" ", " ", " ", " ", " ", " ", " ", " ", " "};
    }
}
