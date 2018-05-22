using System;

namespace P02_ValidateURL
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputURL = Console.ReadLine();

            try
            {
                var uri = new Uri(inputURL);

                var protocol = uri.Scheme.ToString();
                var port = uri.Port.ToString();
                var host = uri.Host.ToString();
                var path = uri.AbsolutePath.ToString();
                var query = uri.Query.ToString();
                var fragment = uri.Fragment.ToString();

                var httpCheck = protocol == "http" && port == "80";
                var httpsCheck = protocol == "https" && port == "443";

                if (httpCheck || httpsCheck)
                {
                    Console.WriteLine($"Protocol: {protocol}");
                    Console.WriteLine($"Host: {host}");
                    Console.WriteLine($"Port: {port}");
                    Console.WriteLine($"Path: {path}");

                    //if query exists, skip '?'
                    if (query.Length > 1)
                    {
                        Console.WriteLine($"Query: {query.Substring(1)}");
                    }

                    //if fragment exists, skip '#'
                    if (fragment.Length > 1)
                    {
                        Console.WriteLine($"Fragment: {fragment.Substring(1)}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid URL");
                }
            }
            catch (UriFormatException)
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
