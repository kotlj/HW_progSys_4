using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStack
{

    class Task1
    {
        static void moveHorse(ref string horse)
        {
            Random random = new Random();
            int r = random.Next();
            if (r % 3 == 0)
            {
                horse += "||";
            }
            else if (r % 5 == 0)
            {
                horse += "|||";
            }
            else if (r % 5 == 0)
            {
                //nothing
            }
            else
            {
                horse += "|";
            }
        }
        public static void task1()
        {
            string horse1 = "";
            string horse2 = "";
            string horse3 = "";

            Thread thread1 = new Thread(delegate ()
            {
                while (true)
                {
                    moveHorse(ref horse1);
                    Thread.Sleep(801);
                }
            });
            Thread thread2 = new Thread(delegate ()
            {
                while (true)
                {
                    moveHorse(ref horse2);
                    Thread.Sleep(800);
                }
            });
            Thread thread3 = new Thread(delegate ()
            {
                while (true)
                {
                    moveHorse(ref horse3);
                    Thread.Sleep(799);
                }
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();

            while (horse1.Length <= 55 && horse2.Length <= 55 && horse3.Length <= 55)
            {
                Console.Clear();

                Console.WriteLine($"Horse 1: {horse1}\nHorse 2: {horse2}\nHorse 3: {horse3}");
                Thread.Sleep(799);
            }
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
            if (horse1.Length >= 55)
            {
                Console.WriteLine("Horse #1 Win!!!");
            }
            else if (horse2.Length >= 55)
            {
                Console.WriteLine("Horse #2 Win!!!");
            }
            else
            {
                Console.WriteLine("Horse #3 Win!!!");
            }
            Console.WriteLine($"Horse 1: {horse1.Length} tiles\nHorse 2: {horse2.Length} tiles\nHorse 3: {horse3.Length} tiles");
        }
    }

    class Task2
    {
        public static void task2()
        {
            int lim = 0;
            Console.WriteLine("Enter upper limit:\n");
            string check = Console.ReadLine();
            if (int.TryParse(check, out lim))
            {
                long N_zero = 0;
                long N_one = 1;
                while (N_one < lim)
                {
                    Console.WriteLine($"fib: {N_zero},\nfib: {N_one}");
                    N_zero = N_zero + N_one;
                    N_one = N_one + N_zero;
                    Thread.Sleep(400);
                }
            }
        }
    }

    class Task3
    {
        private async static Task countWord(string text, string word)
        {
            if (text.Contains(word))
            {
                string[] splited = text.Split(' ', ',', '.', '!', '?');
                int counter = 0;
                foreach (var words in splited)
                {
                    if (words.Equals(word))
                    {
                        counter++;
                    }
                }
                Console.WriteLine($"Word in text: {counter}");
            }
            else
            {
                Console.WriteLine("No such word in text");
            }
            Thread.Sleep(2);
        }
        public async static Task task3()
        {
            string path = "";
            string buff = "";
            Console.WriteLine("Enter path to file:\n");
            path = Console.ReadLine();
            if (File.Exists(path))
            {
                Console.WriteLine("Enter word:\n");
                string word = Console.ReadLine();
                buff = File.ReadAllText(path);
                await countWord(buff, word);
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Invalid path");
            }
        }
    }
}

namespace HW_ProgSys_4
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            while(true)
            {
                char choise = '0';
                Console.WriteLine("Choose:\n1 - task1\n2 - task2\n3 - task3\n0 - exit;");
                choise = (Console.ReadLine())[0];
                if (choise == '1')
                {
                    TaskStack.Task1.task1();
                }
                else if (choise == '2')
                {
                    TaskStack.Task2.task2();
                }
                else if (choise == '3')
                {
                    await TaskStack.Task3.task3();
                }    
                else if (choise == '0')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown option");
                }
            }
        }
    }
}
