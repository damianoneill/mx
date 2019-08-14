using System;
using System.IO;
using System.Net;

namespace mx
{
    class Program
    {
        static public bool ValidateOption(int option)
        {
            if (option >= 0 && option <= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public int DisplayMenu()
        {
            Console.WriteLine();
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
                if (!ValidateOption(userInput))
                {
                    Console.WriteLine("Please input a value between 0 and 2");
                    continue;
                }
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
                        Console.WriteLine("");
                        Console.WriteLine("Round " + mx.Data[i].Round + " Race " + i + ": " + mx.Data[i].Class + " Moto " + mx.Data[i].Moto);
                        for (int j = 0; j < mx.Data[i].RiderData.Length; j++)
                        {
                            Console.WriteLine(mx.Data[i].RiderData[j].Name + " rode a " + mx.Data[i].RiderData[j].Bike);
                        }
                    }

                    String path = @"datafile.txt";
                    if (!File.Exists(path)) // Presence Check
                    {
                        Console.WriteLine("No such file existed; one was created.");
                    }
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(mx.Data[0].Track + " selected at " + DateTime.Now);
                    }

                }
            } while (userInput != 0);
        }
    }
}
