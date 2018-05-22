using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_RequestParser
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var methodAndPathsMap = new Dictionary<string, HashSet<string>>();
            FillMap(methodAndPathsMap);         

            var requestParams = Console.ReadLine().Split(" /", StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = requestParams[0].ToLower();

            var pathAndProtocolParams = requestParams[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var requestPath = pathAndProtocolParams[0];
            var requestProtocol = pathAndProtocolParams[1];

            //check if the requested method exists
            var searchedMethod = methodAndPathsMap.Keys.FirstOrDefault(k => k == requestMethod);
            string searchedPath = null;

            if (searchedMethod != null)
            {
                //check if the requested path exists
                searchedPath = methodAndPathsMap[searchedMethod].FirstOrDefault(p => p == requestPath);
            }

            string status = null;
            string statusMessage = null;
            var contentLenght = 0;        

            if (searchedMethod == null || searchedPath == null)
            {
                status = "404 Not Found";
                statusMessage = "Not Found";
                contentLenght = 9;
            }
            else
            {
                status = "200 OK";
                statusMessage = "OK";
                contentLenght = 2;
            }

            PrintRequestResult(requestProtocol, status, contentLenght, statusMessage);
        }

        private static void FillMap(Dictionary<string, HashSet<string>> map)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputParams = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var path = inputParams[0];
                var method = inputParams[1];

                if (!map.ContainsKey(method))
                {
                    map[method] = new HashSet<string>();
                }

                map[method].Add(path);
            }
        }

        private static void PrintRequestResult(string requestProtocol, string status, int contentLenght, string statusMessage)
        {
            Console.WriteLine($"{requestProtocol} {status}");
            Console.WriteLine($"Content - Length: {contentLenght}");
            Console.WriteLine($"Content - Type: text / plain");
            Console.WriteLine($"{Environment.NewLine}{statusMessage}");            
        }
    }
}
