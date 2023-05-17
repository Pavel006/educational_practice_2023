using System;
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
            Console.Write(@"Введите путь к архиву (Пример - C:\User\Рабочий Стол\archive.zip):" + " \n> ");
            string archivePath = Console.ReadLine();
            string archiveName = "";

            if (!archivePath.Split('\\').Last().Contains(".zip"))
            {
                Console.WriteLine("Программа не поддерживает данное расширение архива!!!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            archiveName = archivePath.Split('\\').Last().Replace(".zip", "");

            Console.Write("\nВведите номер файла: \n> ");
            string numberFile = Console.ReadLine();

            Console.Write("\nВведит путь к папку в котору хотите сохранить файл: \n> ");
            string savePath = Console.ReadLine();

            Unarchiver.Unarchiv(numberFile, archiveName, archivePath, savePath);
        }

        public class Unarchiver
        {
            public static void Unarchiv(string number, string archiveName, string archivePath, string savePath)
            {
                FileStream fileStream = File.Open(archivePath, FileMode.Open);

                ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Update);
                if (archive.Entries.Count() - 1 < Convert.ToInt32(number))
                {
                    using (FileStream fstream = File.Open($@"{savePath}\{number}_{archiveName}.txt", FileMode.Create))
                    {
                        using (StreamWriter output = new StreamWriter(fstream))
                        {
                            output.Write("");
                        }
                    }
                }
                else
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name.Replace(".txt", "") == number)
                        {
                            byte[] bytes;
                            var stream = entry.Open();
                            using (var ms = new MemoryStream())
                            {
                                stream.CopyTo(ms);
                                bytes = ms.ToArray();
                            }
                            using (FileStream fstream = new FileStream($@"{savePath}\{number}_{archiveName}.txt", FileMode.OpenOrCreate))
                            {
                                fstream.Write(bytes, 0, bytes.Length);
                                Console.WriteLine("\n" + $@"Файл {number}_{archiveName}.txt сохранен.");
                                Console.WriteLine($@"Путь до файла: {savePath}\{number}_{archiveName}.txt");
                            }
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
}

