using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lab008
{
    class Program
    {
        static void Main(string[] args)
        {
            //поиск файла
            string catalog = @"C:\Users\anyap\source\repos\";
            string fileName = "TEXT.txt";
            string path = "";
            foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
                SearchOption.AllDirectories))
            {
                FileInfo FI;
                try
                {
                    FI = new FileInfo(findedFile);
                    Console.WriteLine(FI.Name + " " + FI.FullName);
                    path = FI.FullName;
                }
                catch
                {
                    continue;
                }

            }
            // чтение из файла и вывод на консоль
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла: \n{textFromFile}");
            }
            // сжатие файла
            string sourceFile = path;
            string compressedFile = "TEXT.gz";
            using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
            using FileStream targetStream = File.Create(compressedFile);
            using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
            sourceStream.CopyTo(compressionStream);
            Console.WriteLine($"Сжатие файла {sourceFile} завершено.");
            Console.WriteLine($"Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}");
        }

    }
}
