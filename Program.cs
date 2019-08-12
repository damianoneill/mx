using System;

namespace mx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string input = Console.ReadLine();
            string message = "Hello " + input + "!";
            Console.WriteLine(message);
        }
    }
}
