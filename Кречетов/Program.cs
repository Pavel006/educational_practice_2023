﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Кречетов
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivePath = @"C:\Users\pavel\source\repos\Кречетов\Кречетов\bin\Debug\repos.zip";
            FileStream fileStream1 = File.Open(archivePath, FileMode.Open);
            ZipArchive archive = new ZipArchive(fileStream1, ZipArchiveMode.Update);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.Name != "")
                {
                    Console.WriteLine($"Имя файла: {entry.Name} " +
                        $"Размер сжатого файла: {entry.CompressedLength}");
                }
                else
                {
                    Console.WriteLine($"Папка: {entry.FullName}");
                }
            }
            Console.Read();
        }
    }
}
