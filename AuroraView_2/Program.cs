using System;
using System.Linq;

namespace AuroraView_Task_2
{
    internal class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.Write("     You have a list of N songs.\n     You need to play all the songs each day but in di#erent order.\n     Write a funcon that will order the list in random way each day.\n     (You can use rand funcon).\n");
            Console.Write("\n     For emulation of songs shifter we will shuffle sorted array of integers several times.\n     Please enter number of songs: ");
            if (!int.TryParse(Console.ReadLine(), out int numSongs) || numSongs < 1)
            {
                Console.Write("\n     Incorrect value !!!!");
            }
            else
            {
                Console.Write("\n     And number of Days: ");
                if (!int.TryParse(Console.ReadLine(), out int numDays) || numDays < 1)
                {
                    Console.Write("\n     Incorrect value !!!!");
                }
                else
                {
                    Console.Write("\n");

                    for (int i = 0; i < numDays; i++)
                    {
                        int[] songs = Enumerable.Range(1, numSongs).ToArray();
                        Shuffle(songs);

                        Console.WriteLine($"     Playlist for day {i + 1}: [{string.Join(", ", songs)}] \n");
                    }
                }
            }
            Console.Read();
        }

        private static void Shuffle(int[] arr)
        {
            int rndInd;
            int pocket;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                rndInd = rand.Next(i + 1, arr.Length);
                pocket = arr[i];
                arr[i] = arr[rndInd];
                arr[rndInd] = pocket;
            }
        }
    }
}
