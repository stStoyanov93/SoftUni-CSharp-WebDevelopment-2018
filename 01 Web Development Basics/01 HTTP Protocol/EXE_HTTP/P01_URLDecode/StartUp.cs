using System;
using System.Net;

namespace P01_URLDecode
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputURL = Console.ReadLine();
            var decodedURL = WebUtility.UrlDecode(inputURL);
            Console.WriteLine(decodedURL);
        }
    }
}
