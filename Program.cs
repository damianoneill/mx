using System;
using System.Net;

namespace mx
{
    class Program
    {
        static public int DisplayMenu()
        {
            Console.WriteLine("Motocross Querier");
            Console.WriteLine();
            Console.WriteLine("1. Show data from WICK-338");
            Console.WriteLine("2. Show data from HANGTOWN");
            Console.WriteLine("0. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        static void Main(string[] args)
        {
            var client = new WebClient();
            int userInput = 0;
            string url = "", track = "", response;
            Welcome mx;
            do
            {
                userInput = DisplayMenu();
                if (userInput == 1)
                {
                    url = "https://api.promotocrossapi.com/laptimes/18/WICK-338";
                    track = "WICK-338";
                }
                if (userInput == 2)
                {
                    url = "https://api.promotocrossapi.com/laptimes/18/HANGTOWN";
                    track = "HANGTOWN";
                }
                if (userInput != 0)
                {
                    response = client.DownloadString(url);
                    mx = Welcome.FromJson(response);
                    Console.WriteLine("There was " + mx.Data.Length + " Races in 2018 at the " + track + " track");
                    for (int i = 0; i < mx.Data.Length; i++)
                    {
                        Console.WriteLine("Round " + mx.Data[i].Round + " Race " + i + ": " + mx.Data[i].Class + " Moto " + mx.Data[i].Moto);
                    }
                }
            } while (userInput != 0);
        }
    }
}
