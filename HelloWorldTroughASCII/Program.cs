using System;
using System.Text;
using System.Threading;

namespace HelloWorldTroughASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed;

            Console.Write("Enter message to print: ");
            string msg = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(msg))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Message cannot be empty.");
                Console.ResetColor();
                return;
            }
            foreach (var c in msg)
            {
                if ((int)c < 0 || (int)c > 127)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not supported character table.\nUse ASCII table only.");
                    Console.ResetColor();
                    return;
                }
            }

            Console.Write("Enter speed in milliseconds: ");
            while (!Int32.TryParse((Console.ReadLine()), out speed) || speed < 0)
            {
                Console.WriteLine("Incorrect input!");
                Console.Write("Enter speed in ms: ");
            }

            Console.Write("Do you want animations [yes/no]: ");
            string answer = Console.ReadLine().ToLower();
            bool animations = true;

            if (answer == "no")
                animations = false;

            Console.CursorVisible = false;
            int index = 0;

            StringBuilder sb = new StringBuilder();
            char ch = '\0';
            while (true)
            {
                for (int j = 32; j <= 126; j++)
                {
                    ch = (char)j;
                    if (msg[index] == ch)
                    {
                        if (animations)
                        {
                            Console.Write(sb.ToString());
                            Console.SetCursorPosition(index, Console.CursorTop);
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(ch);
                            Console.ResetColor();
                            sb.Append(ch);

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" - Correct :)");
                            Console.ResetColor();
                            Console.Beep();
                            Thread.Sleep(1500);
                            for (int i = 0; i <= 12; i++)
                            {
                                Console.Write("\b \b");
                                Thread.Sleep(10);
                            }

                            Thread.Sleep(500);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(sb.ToString() + ch);
                            sb.Append(ch);
                            Console.WriteLine();
                        }
                        break;
                    }

                    Console.WriteLine(sb.ToString() + ch);
                    Thread.Sleep(speed);
                }

                index++;

                if (index == msg.Length)
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Thread.Sleep(1000);
            Console.ResetColor();
        }
    }
}