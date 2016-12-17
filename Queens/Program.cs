using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Mime;
using System.Web;

namespace _8Queen
{
    public class Program
    {
        private static string[] inputArgs;
        private static int queens;
        private static int width;
        private static int height;
        private static string task2solve;

        private static string outPath;
        private static string inputPath;

        private static FileStream fs;
        private static StreamWriter sw;
        private static StreamReader sr;
        private static List<string[]> Solutions;
        private static Solver solver;

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Ошибка!\nОтсутствуют входные параметры!");
                Console.WriteLine("Нажмите Enter для выхода");
                Console.ReadLine();
                return;
            }

            inputPath = args[0] + ".txt";
            outPath = args[1] + ".txt";

            fs = new FileStream(inputPath, FileMode.Open);
            sr = new StreamReader(fs);
            inputArgs = sr.ReadToEnd().Split(new char[] {' '});
            sr.Close();
            fs.Close();

            if (inputArgs.Length == 0)
            {
                Console.WriteLine("Ошибка!\nОтсутствует условие задачи!");
                Console.WriteLine("Нажмите Enter для выхода");
                Console.ReadLine();
                return;
            }

            queens = int.Parse(inputArgs[0]);
            width = int.Parse(inputArgs[1]);
            height = int.Parse(inputArgs[2]);
            task2solve = inputArgs[3];

            Solutions = new List<string[]>();

            switch (task2solve)
            {
                case "BeatAllCells":
                    solver = new Solver(new BeatAllCells(false, inputArgs));
                    break;
                case "BeatAllCellsAll":
                    solver = new Solver(new BeatAllCells(true, inputArgs));
                    break;
                case "NotHittingQueens":
                    solver = new Solver(new NotHittingQueens(false, inputArgs));
                    break;
                case "NotHittingQueensAll":
                    solver = new Solver(new NotHittingQueens(true, inputArgs));
                    break;
            }

            Solutions = solver.Solve();

            fs = new FileStream(outPath, FileMode.Create);
            sw = new StreamWriter(fs);
            sw.WriteLine("--output result start--");
            sw.WriteLine("Решение задачи '" + task2solve + "', c условиями:");
            sw.WriteLine("Количество ферзей: " + queens);
            sw.WriteLine("Ширина доски: " + width);
            sw.WriteLine("Длина доски: " + height);
            if (Solutions.Count == 0)
            {
                sw.WriteLine("Не удалось найти решение!");
            }
            else
            {
                for (int i = 0; i < Solutions.Count; i++)
                {
                    sw.WriteLine((i + 1) + ")");
                    foreach (string line in Solutions[i])
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            sw.WriteLine("--output result end--");
            sw.Close();
            fs.Close();

            Console.WriteLine("Готово!");
            Console.WriteLine("Решение задачи записано в файле '" + outPath + "' в папке с программой");
            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}