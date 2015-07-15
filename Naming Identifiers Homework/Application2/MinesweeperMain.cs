namespace mini4ki
{
    using System;
    using System.Collections.Generic;

    using Application2;
    /// <summary>
    /// Not fully finished
    /// </summary>
    public class Minesweeper
    {
        private const int MaxFields = 35;

        private static void Main()
        {
            string command = string.Empty;
            char[,] field = CreateGamingField();
            char[,] bombs = PutTheBombs();
            int counter = 0;
            bool explode = false;
            List<LeaderBoard> players = new List<LeaderBoard>(6);
            int row = 0;
            int col = 0;
            bool flag = true;
            bool isFinish = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoard(field);
                    flag = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRating(players);
                        break;
                    case "restart":
                        field = CreateGamingField();
                        bombs = PutTheBombs();
                        PrintBoard(field);
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                SetPlayerPosition(field, bombs, row, col);
                                counter++;
                            }

                            if (MaxFields == counter)
                            {
                                isFinish = true;
                            }
                            else
                            {
                                PrintBoard(field);
                            }
                        }
                        else
                        {
                            explode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (explode)
                {
                    PrintBoard(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", counter);
                    string niknejm = Console.ReadLine();
                    LeaderBoard t = new LeaderBoard(niknejm, counter);
                    if (players.Count < 5)
                    {
                        players.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < t.Points)
                            {
                                players.Insert(i, t);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((LeaderBoard r1, LeaderBoard r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((LeaderBoard r1, LeaderBoard r2) => r2.Points.CompareTo(r1.Points));
                    PrintRating(players);

                    field = CreateGamingField();
                    bombs = PutTheBombs();
                    counter = 0;
                    explode = false;
                    flag = true;
                }

                if (isFinish)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoard(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    LeaderBoard to4kii = new LeaderBoard(imeee, counter);
                    players.Add(to4kii);
                    PrintRating(players);
                    field = CreateGamingField();
                    bombs = PutTheBombs();
                    counter = 0;
                    isFinish = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintRating(List<LeaderBoard> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, to4kii[i].Name, to4kii[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void SetPlayerPosition(char[,] field, char[,] bombs, int row, int col)
        {
            char numberOfBombs = NumberOfBombsAround(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            field[row, col] = numberOfBombs;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGamingField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutTheBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] gamingField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gamingField[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int kol = i2 / cols;
                int red = i2 % cols;
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = cols;
                }
                else
                {
                    red++;
                }

                gamingField[kol, red - 1] = '*';
            }

            return gamingField;
        }

        private static char NumberOfBombsAround(char[,] board, int row, int col)
        {
            int bombsCount = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                bombsCount += 3 * CheckForBomb(board, row, col);
            }
            else
            {
                if (row - 1 >= 0)
                {
                    bombsCount += CheckForBomb(board, row, col);
                }

                if (col - 1 >= 0)
                {
                    bombsCount += CheckForBomb(board, row, col);
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                bombsCount += CheckForBomb(board, row, col);
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                bombsCount += CheckForBomb(board, row, col);
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                bombsCount += 3 * CheckForBomb(board, row, col);
            }
            else
            {
                if (row + 1 < rows)
                {
                    bombsCount += CheckForBomb(board, row, col);
                }

                if (col + 1 < cols)
                {
                    bombsCount += CheckForBomb(board, row, col);
                }
            }

            return char.Parse(bombsCount.ToString());
        }

        private static int CheckForBomb(char[,] board, int row, int col)
        {
            if (board[row + 1, col] == '*')
            {
                return 1;
            }

            return 0;
        }
    }
}