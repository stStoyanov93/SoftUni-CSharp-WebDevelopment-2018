using System;
using System.IO;
using System.Threading.Tasks;

namespace P02_SliceFile
{
    class StartUp
    {        
        static void Main(string[] args)
        {
            SliceAsync();

            Console.WriteLine("Anything else?");
        }

        private static void SliceAsync()
        {
            var sourceFileName = Console.ReadLine();
            var destinationPath = Console.ReadLine();
            int parts = int.Parse(Console.ReadLine());

            Task.Run(() => Slice(sourceFileName, destinationPath, parts));

            Console.WriteLine("Slice complete");
        }

        private static void Slice(string sourceFileName, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var stream = new FileStream(sourceFileName, FileMode.Open))
            {
                var bufferSize = 1024;
                var fileInfo = new FileInfo(sourceFileName);
                var partLenght = (stream.Length / parts) + 1;
                var currentByte = 0L;

                for (var currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (var destiantion = new FileStream(filePath, FileMode.Create))
                    {
                        var buffer = new byte[bufferSize];

                        while (currentByte <= partLenght * currentPart)
                        {
                            var readBytesCount = stream.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destiantion.Write(buffer, 0, buffer.Length);

                            currentByte += readBytesCount;
                        }
                    }
                }
            }
        }
    }
}
