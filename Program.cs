using System;
using System.Net;

namespace mx
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();

            string url = "https://api.promotocrossapi.com/laptimes/18/WICK-338";
            var response = client.DownloadString(url);

            var mx = Welcome.FromJson(response);

            Console.WriteLine("There was " + mx.Data.Length + " Races in 2018 at the WICK-338 track");

            url = "https://api.promotocrossapi.com/laptimes/17/HANGTOWN";
            response = client.DownloadString(url);
            mx = Welcome.FromJson(response);

            Console.WriteLine("There was " + mx.Data.Length + " Races in 2017 at the HANGTOWN track");
        }
    }
}
