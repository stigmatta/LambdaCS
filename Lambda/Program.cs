
using BackpackClass;
using System;

namespace Lambda
{
    public delegate void ConsoleRGB(string str);
    public delegate bool ArrayLambda(int i);
    public delegate bool WordFinder(string str,string text);

    public class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            ConsoleRGB consoleRGB = delegate (string str)
            {
                if (Enum.TryParse<ConsoleColor>(str, true, out ConsoleColor color))
                {
                    Console.BackgroundColor = color;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"'{str}' is not a valid console color.");
                }
            };

            consoleRGB("Cyan");
            #endregion

            #region Task2
            BackpackObj obj = new BackpackObj("Pen", 1);
            Backpack backpack = new Backpack("Cyan", "Adidas", "Cotton", 50, 100);

            backpack.AddObject(obj);

            #endregion

            #region Task3
            int[] arr = {-3,-3,-5,-7, 7, 14, 3, 5, 6, 7 };
            ArrayLambda isDivisibleBySeven = (num) => num % 7 == 0;
            int sevenCounter = 0;
            foreach (int i in arr)
            {
                if (isDivisibleBySeven(i))
                    sevenCounter++;
            }
            Console.WriteLine(sevenCounter);
            #endregion

            #region Task4
            ArrayLambda IsPositive = (num) => num > 0;
            int posCounter = 0;

            foreach(int i in arr)
            {
                if(IsPositive(i)) posCounter++;
            }
            Console.WriteLine(posCounter);
            #endregion

            #region Task5
            ArrayLambda NegativeDistinct = (num) => num < 0;
            int negCounter = 0;

            foreach (int i in arr)
            {
                if (IsPositive(i)) negCounter++;
            }
            Console.WriteLine(negCounter);

            #endregion

            #region Task6
            string text = "Hello world apple orange";
            string str1 = "orange";
            string str2 = "porridge";
            WordFinder wordFinder = (strstr, str) => str.Contains(strstr);
            Console.WriteLine(wordFinder(str1,text));
            Console.WriteLine(wordFinder(str2, text));


            #endregion
        }
    }
}
