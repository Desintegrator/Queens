using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Queen
{
    class NotHittingQueens : ISolvable
    {
        private int[,] chessBoard;
        private int height;
        private int width;
        private int queens;

        private string[] Solution;
        private List<string[]> Solutions;

        private bool allSolutions = false;

        public NotHittingQueens(bool allSolutions, string[] inputArgs)
        {
            Solutions = new List<string[]>();
            queens = int.Parse(inputArgs[0]);
            width = int.Parse(inputArgs[1]);
            height = int.Parse(inputArgs[2]);
            chessBoard = new int[width, height];
            this.allSolutions = allSolutions;
        }

        public List<string[]> Solve()
        {
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    chessBoard[i, j] = 0;
            if (!FindPlace(0))
                return Solutions;
            return Solutions;
        }

        bool FindPlace(int i)
        {
            if (i >= width)
                return false;

            bool result = false;
            for (int j = 0; j < height; ++j)
            {
                if (chessBoard[i, j] == 0)
                {
                    setQueen(i, j);

                    if (i == queens - 1)
                    {
                        CollectSolution();
                        if (allSolutions)
                        {
                            unsetQueen(i, j);
                            return false;
                        }
                        result = true;
                    }
                    else
                    {
                        FindPlace(i + 1);
                        unsetQueen(i, j);
                    }
                }
                if (result)
                    break;
            }
            return result;
        }

        void CollectSolution()
        {
            Solution = new string[width];
            for (int i = 0; i < width; ++i)
            {
                string line = "";
                for (int j = 0; j < height; ++j)
                {
                    if (chessBoard[i, j] == -1)
                    {
                        line += "Ф";
                    }
                    else
                    {
                        if (i%2 == 0 && j%2 == 0)
                        {
                            line += " ";
                        }
                        else
                        {
                            if (i%2 != 0 && j%2 != 0)
                            {
                                line += " ";
                            }
                            else
                            {
                                line += "█";
                            }
                        }
                    }
                }
                Solution[i] = line;
            }
            Solutions.Add(Solution);
        }

        void setQueen(int i, int j)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (x == i || y == j)
                    {
                        chessBoard[x, y] += 1;
                    }
                    if ((x - i == y - j) || ((x - i)*-1 == y - j) || (x - i == (y - j)*-1))
                    {
                        chessBoard[x, y] += 1;
                    }
                }
            chessBoard[i, j] = -1;
        }

        void unsetQueen(int i, int j)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    if (x == i || y == j)
                    {
                        chessBoard[x, y] -= 1;
                    }
                    if ((x - i == y - j) || ((x - i)*-1 == y - j) || (x - i == (y - j)*-1))
                    {
                        chessBoard[x, y] -= 1;
                    }
                }
            chessBoard[i, j] = 0;
        }
    }
}