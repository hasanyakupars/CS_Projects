using System.Collections;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<char> arr = new List<char>() { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'q', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };

        static void mode1(int seconds)
        {
            int charCount = 0;
            int wrongChar = 0;
            Console.Clear();
            var rand = new Random();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.Elapsed.TotalSeconds < seconds)
            {
                int index = rand.Next(arr.Count);
                Console.Write(arr[index] + " :  ");

                while (true)
                {
                    char input = char.ToLower(Console.ReadKey().KeyChar);
                    if (input.Equals(arr[index]))
                    {
                        charCount++;
                        break;
                    }
                    else
                    {
                        wrongChar++;
                        Console.Write("\b");
                    }    
                }
                Console.WriteLine("");
            }
            timer.Stop();
            Result(charCount, wrongChar, seconds);
        }

        static void mode2(int seconds)
        {
            int charCount = 0;
            int wrongChar = 0;
            Console.Clear();
            var rand = new Random();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (timer.Elapsed.TotalSeconds < seconds)
            {
                int index = rand.Next(arr.Count);
                Console.WriteLine("\n\n\t\t" + arr[index]);

                while (true)
                {
                    char input = char.ToLower(Console.ReadKey().KeyChar);
                    if (input.Equals(arr[index]))
                    {
                        charCount++;
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        wrongChar++;
                        Console.Write("\b");
                    }         
                }
            }
            timer.Stop();
            Result(charCount, wrongChar, seconds);
        }

        static void Result(int charCount, int wrongChar, int seconds)
        {
            Console.Clear();
            Console.WriteLine("\t\tSonuç Ekranı\n\t\t------------\n\n\t" + seconds + " saniyede " + charCount + " kere tuşladınız." + " / " + wrongChar + " kere YANLIŞ tuşladınız.\n\n");
            Console.WriteLine("\tDakika başına " + Math.Round((double)(charCount * 60) / seconds, 2) + " harfe bastınız.\n" + "\tDakika başına " + Math.Round((double)(charCount * 12) / seconds, 2) + " kelimeye denk geliyor.");
            Console.WriteLine("\n\n\tAna menüye dönmek için herhangi bir tuş giriniz.");
            Console.ReadLine();
            Main(null);
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.Write("Kaç saniye boyunca çalışmak istiyorsunuz?: ");
                int seconds = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n\t1- Sıralı Mod\n\t2- Tekli Mod\n\t0- Çıkış\n\t");
                Console.Write("\tMod seç: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        mode1(seconds);
                        break;
                    case 2:
                        mode2(seconds);
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        Main(null);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString);
            }
        }
    }
}