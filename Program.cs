using System;

namespace mx
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.Write("What is your name? ");
                input = Console.ReadLine();
                string message = "Hello " + input + "!";
                Console.WriteLine(message);
            } while (input != "");
        }
    }
}
