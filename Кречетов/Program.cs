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
            Console.Write("Введите номер файла и путь к архиву через пробел: \n> ");
            string InputString = Convert.ToString(Console.ReadLine());
            Unarchiver.Unarchiv(Convert.ToInt32(InputString.Split(' ')[0]), InputString.Split(' ')[1]);
            //string archivePath = @"C:\Users\pavel\source\repos\Кречетов\Кречетов\bin\Debug\repos.zip";
            //FileStream fileStream1 = File.Open(archivePath, FileMode.Open);
            //ZipArchive archive = new ZipArchive(fileStream1, ZipArchiveMode.Update);
            //foreach (ZipArchiveEntry entry in archive.Entries)
            //{
            //    if (entry.Name != "")
            //    {
            //        Console.WriteLine($"Имя файла: {entry.Name} " +
            //            $"Размер сжатого файла: {entry.CompressedLength}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Папка: {entry.FullName}");
            //    }
            //}
            //Console.Read();
        }

        public class Unarchiver
        {
            public static void Unarchiv(int number, string archivePath)
            {
                FileStream fileStream = File.Open(archivePath, FileMode.Open);
                ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Update);
                var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var programmPath = Path.GetDirectoryName(location);
                byte[] buffer = Encoding.Default.GetBytes("");
                if (archive.Entries.Count() < number)
                {
                    using (FileStream fstream = File.Open(programmPath + $"{number}_{fileStream.Name}", FileMode.Create))
                    {

                    }
                }
                foreach (ZipArchiveEntry entry in archive.Entries)
                {

                }
            }
        }
    }
}
