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

            Console.WriteLine(response);
        }
    }
}
