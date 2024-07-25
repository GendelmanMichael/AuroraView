using System;
using System.Linq;


namespace AuroraView_Test_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("     There is an Array with green yellow and red balls.\n     Please sort the array by the color. \n     You don’t have addional memory.\n     Please don’t use library funcons.\n");
            Console.Write("     Pleas enter task array, where:\n     \"r\" is a red ball,\n     \"y\" is yello ball.\n     \"g\" is green ball.\n     Not case sensetive, any other symbols will be ignored:\n\n     ");
            char[] chars = { 'r', 'y', 'g' };
            char[] task = Console.ReadLine().ToLower().Where(c => chars.Contains(c)).ToArray();
            Console.Write($"\n     Filtered input [{string.Join(", ", task)}]\n");
            SortBalls(task);
            Console.Write($"\n     Sorted array: [{string.Join(", ", task)}]\n");

            Console.Read();
        }

        private static void SortBalls(char[] balls)
        {
            int g = 0, y = 0, r = balls.Length - 1;

            while(y <= r)
            {
                switch (balls[y])
                {
                    case 'g':
                        Swap(y++, g++, balls);
                        break;
                    case 'y':
                        y++;
                        break;
                    default:
                        Swap(y, r--, balls);
                        break;
                }
            }
        }

        private static void Swap(int first, int second, char[] arr)
        {
            char pocket = arr[first];
            arr[first] = arr[second];
            arr[second] = pocket;
        }
    }
}
