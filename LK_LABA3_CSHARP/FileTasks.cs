using System;
using System.Collections.Generic;
using System.Text;

namespace LK_LABA3_CSHARP
{
    public static class FileTasks
    {
        public static void CreateBinaryFile(string path, int count, int min, int max, Random random)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(min, max + 1);
                    writer.Write(number);
                }
            }
            ScreenUtils.PaintLine($"\tФайл {path} создан. Записано {count} чисел в диапазоне [{min}, {max}].", Color.Green);
        }

        public static void FilterBinaryFile(string sourcePath, string destPath, int k)
        {
            if (!File.Exists(sourcePath))
            {
                ScreenUtils.PrintError($"\tФайл {sourcePath} не найден :(");
                return;
            }

            int countFiltered = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(sourcePath, FileMode.Open)))
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(destPath, FileMode.Create)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                    {
                        int number = reader.ReadInt32();
                        if (number % k == 0)
                        {
                            writer.Write(number);
                            countFiltered++;
                        }
                    }
                }
            }
            ScreenUtils.PaintLine($"\tИз файла {sourcePath} в {destPath} переписано {countFiltered} чисел, кратных {k}.", Color.Green);
        }

        public static void PrintBinaryFile(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            Console.WriteLine($"\tСодержимое файла {path}:");
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int count = 0;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.Write($"\t{number}");
                    count++;
                    if (count % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                ScreenUtils.PaintLine($"\tВсего чисел в файле: {count}", Color.Cyan);
            }
        }
    }
}
