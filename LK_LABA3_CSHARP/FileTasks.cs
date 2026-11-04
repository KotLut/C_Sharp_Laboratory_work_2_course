using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using System.Xml.Serialization;


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

        public static void CreateToysFile(string path, int count, Random random)
        {
            string[] names = { "Мишка-Мишаня", "Кукла Маша", "Конструктор", "Машинка", "Пазл", "Пазл 3д", "Конструктор Олега", "Робот", "Мяч", "Конструктор Магнитный" };

            List<Toy> toys = new List<Toy>();
            for (int i = 0; i < count; i++)
            {
                string name = names[random.Next(0, names.Length)];
                int price = random.Next(100, 5001);
                int minAge = random.Next(0, 12);
                int maxAge = minAge + random.Next(1, 8);
                if (maxAge > 18)
                {
                    maxAge = 18;
                }
                Toy toy = new Toy(name, price, minAge, maxAge);
                toys.Add(toy);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, toys);
            }
            ScreenUtils.PaintLine($"\tФайл {path} создан через XML сериализацию. Записано {count} игрушек.", Color.Green);
        }

        public static void FindMostExpensiveConstructor(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            List<Toy> toys;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                toys = (List<Toy>)serializer.Deserialize(fs);
            }

            Toy mostExpensive = new Toy();
            bool found = false;
            int maxPrice = -1;

            for (int i = 0; i < toys.Count; i++)
            {
                if (toys[i].Name.IndexOf("Конструктор", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (toys[i].Price > maxPrice)
                    {
                        maxPrice = toys[i].Price;
                        mostExpensive = toys[i];
                        found = true;
                    }
                }
            }

            if (found)
            {
                ScreenUtils.PaintLine("\tСамый дорогой конструктор:", Color.Cyan);
                Console.WriteLine(mostExpensive);
                ScreenUtils.PaintLine($"\tСтоимость: {mostExpensive.Price} руб.", Color.Green);
            }
            else
            {
                ScreenUtils.PrintError("\tКонструкторы не найдены в файле :(");
            }
        }

        public static void PrintToysFile(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            List<Toy> toys;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                toys = (List<Toy>)serializer.Deserialize(fs);
            }

            int maxNameLen = "Название".Length;
            int maxPriceLen = "Цена".Length;
            int maxMinAgeLen = "От".Length;
            int maxMaxAgeLen = "До".Length;

            for (int i = 0; i < toys.Count; i++)
            {
                if (toys[i].Name.Length > maxNameLen)
                {
                    maxNameLen = toys[i].Name.Length;
                }
                int priceLen = toys[i].Price.ToString().Length;
                if (priceLen > maxPriceLen)
                {
                    maxPriceLen = priceLen;
                }
                int minAgeLen = toys[i].MinAge.ToString().Length;
                if (minAgeLen > maxMinAgeLen)
                {
                    maxMinAgeLen = minAgeLen;
                }
                int maxAgeLen = toys[i].MaxAge.ToString().Length;
                if (maxAgeLen > maxMaxAgeLen)
                {
                    maxMaxAgeLen = maxAgeLen;
                }
            }

            string border = "┌" + new string('─', maxNameLen + 2) +
                            "┬" + new string('─', maxPriceLen + 7) +
                            "┬" + new string('─', maxMinAgeLen + 2) +
                            "┬" + new string('─', maxMaxAgeLen + 2) + "┐";
            string separator = "├" + new string('─', maxNameLen + 2) +
                               "┼" + new string('─', maxPriceLen + 7) +
                               "┼" + new string('─', maxMinAgeLen + 2) +
                               "┼" + new string('─', maxMaxAgeLen + 2) + "┤";
            string bottom = "└" + new string('─', maxNameLen + 2) +
                            "┴" + new string('─', maxPriceLen + 7) +
                            "┴" + new string('─', maxMinAgeLen + 2) +
                            "┴" + new string('─', maxMaxAgeLen + 2) + "┘";

            Console.WriteLine($"\tСодержимое файла {path}:");
            Console.WriteLine("\t" + border);
            Console.WriteLine("\t│ " + "Название".PadRight(maxNameLen) +
                              " │ " + "Цена".PadLeft(maxPriceLen) + " руб. │ " +
                              "От".PadLeft(maxMinAgeLen) + " │ " +
                              "До".PadLeft(maxMaxAgeLen) + " │");
            Console.WriteLine("\t" + separator);

            for (int i = 0; i < toys.Count; i++)
            {
                Console.WriteLine("\t│ " + toys[i].Name.PadRight(maxNameLen) +
                                  " │ " + toys[i].Price.ToString().PadLeft(maxPriceLen) + " руб. │ " +
                                  toys[i].MinAge.ToString().PadLeft(maxMinAgeLen) + " │ " +
                                  toys[i].MaxAge.ToString().PadLeft(maxMaxAgeLen) + " │");
            }

            Console.WriteLine("\t" + bottom);
            ScreenUtils.PaintLine($"\tВсего игрушек в файле: {toys.Count}", Color.Cyan);
        }

        public static void CreateNumbersFile(string path, int count, int min, int max, Random random)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(min, max + 1);
                    writer.WriteLine(number);
                }
            }
            ScreenUtils.PaintLine($"\tФайл {path} создан. Записано {count} чисел в диапазоне [{min}, {max}].", Color.Green);
        }

        public static void PrintNumbersFile(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            Console.WriteLine($"\tСодержимое файла {path}:");
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                int index = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int number = Convert.ToInt32(line);
                    Console.WriteLine($"\t[{index}] = {number}");
                    index++;
                }
                ScreenUtils.PaintLine($"\tВсего чисел в файле: {index}", Color.Cyan);
            }
        }

        public static void FindSumEqualIndex(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            long sum = 0;
            int countMatches = 0;

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                int index = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int number = Convert.ToInt32(line);
                    if (number == index)
                    {
                        sum += number;
                        countMatches++;
                        ScreenUtils.PaintLine($"\tНайдено совпадение: [{index}] = {number}", Color.Green);
                    }
                    index++;
                }
            }

            if (countMatches > 0)
            {
                ScreenUtils.PaintLine($"\tНайдено {countMatches} элементов, равных своему индексу.", Color.Cyan);
                ScreenUtils.PaintLine($"\tИх сумма: {sum}", Color.Green);
            }
            else
            {
                ScreenUtils.PrintError("\tЭлементов, равных своему индексу, не найдено :(");
            }
        }

        public static void CreateMultiNumbersFile(string path, int linesCount, int min, int max, Random random)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < linesCount; i++)
                {
                    int numbersInLine = random.Next(2, 6);
                    StringBuilder line = new StringBuilder();
                    for (int j = 0; j < numbersInLine; j++)
                    {
                        int number = random.Next(min, max + 1);
                        if (j > 0)
                        {
                            line.Append(" ");
                        }
                        line.Append(number);
                    }
                    writer.WriteLine(line.ToString());
                }
            }
            ScreenUtils.PaintLine($"\tФайл {path} создан. Записано {linesCount} строк с числами в диапазоне [{min}, {max}].", Color.Green);
        }

        public static void PrintMultiNumbersFile(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            Console.WriteLine($"\tСодержимое файла {path}:");
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                int lineIndex = 1;
                int totalNumbers = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write($"\tСтрока {lineIndex}: ");
                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].Length > 0)
                        {
                            Console.Write(parts[i] + " ");
                            totalNumbers++;
                        }
                    }
                    Console.WriteLine();
                    lineIndex++;
                }
                ScreenUtils.PaintLine($"\tВсего строк в файле: {lineIndex - 1}, всего чисел: {totalNumbers}", Color.Cyan);
            }
        }

        public static void FindProductDivisibleByK(string path, int k)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            BigInteger product = 1;
            int countMatches = 0;

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i].Length > 0)
                        {
                            int number = Convert.ToInt32(parts[i]);
                            if (number % k == 0)
                            {
                                product *= number;
                                countMatches++;
                                ScreenUtils.PaintLine($"\tНайдено число, кратное {k}: {number}", Color.Green);
                            }
                        }
                    }
                }
            }

            if (countMatches > 0)
            {
                ScreenUtils.PaintLine($"\tНайдено {countMatches} элементов, кратных {k}.", Color.Cyan);
                ScreenUtils.PaintLine($"\tИх произведение: {product}", Color.Green);
            }
            else
            {
                ScreenUtils.PrintError($"\tЭлементов, кратных {k}, не найдено :(");
            }
        }

        public static void CreateTextFile(string path, int linesCount, Random random)
        {
            string[] russianLines = {
        "А река течёт",
        "Ты неси меня река",
        "Выйду ночью в поле с конём",
        "За тебя, Родина-мать",
        "Позови меня тихо по имени",
        "От Волги до Енисея",
        "Главное, что есть ты у меня",
        "А зори здесь тихие-тихие",
        "Улочки московские",
        "Ребята с нашего двора"
    };

            string[] englishLines = {
        "Around the World",
        "I Feel It Coming",
        "Harder, Better, Faster, Stronger",
        "End Of Line",
        "Veridis Quo",
        "Something About Us",
        "(Love Theme from Interstella 5555)",
        "One More Time",
        "Technologic Radio Edit",
        "Face to Face",
        "Digital Love",
        "Robot Rock"
    };

            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                for (int i = 0; i < linesCount; i++)
                {
                    string line;
                    if (random.Next(0, 2) == 0)
                    {
                        line = russianLines[random.Next(0, russianLines.Length)];
                    }
                    else
                    {
                        line = englishLines[random.Next(0, englishLines.Length)];
                    }
                    writer.WriteLine(line);
                }
            }
            ScreenUtils.PaintLine($"\tФайл {path} создан. Записано {linesCount} строк.", Color.Green);
        }

        public static void PrintTextFile(string path)
        {
            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            Console.WriteLine($"\tСодержимое файла {path}:");
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                int lineIndex = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"\t{lineIndex}. {line}");
                    lineIndex++;
                }
                ScreenUtils.PaintLine($"\tВсего строк в файле: {lineIndex - 1}", Color.Cyan);
            }
        }

        public static void FilterLinesWithoutRussian(string sourcePath, string destPath)
        {
            if (!File.Exists(sourcePath))
            {
                ScreenUtils.PrintError($"\tФайл {sourcePath} не найден :(");
                return;
            }

            int countFiltered = 0;
            using (StreamReader reader = new StreamReader(sourcePath, Encoding.UTF8))
            {
                using (StreamWriter writer = new StreamWriter(destPath, false, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!ContainsRussianLetters(line))
                        {
                            writer.WriteLine(line);
                            countFiltered++;
                        }
                    }
                }
            }
            ScreenUtils.PaintLine($"\tИз файла {sourcePath} в {destPath} переписано {countFiltered} строк без русских букв.", Color.Green);
        }

        private static bool ContainsRussianLetters(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё')
                {
                    return true;
                }
            }
            return false;
        }

    }

    public struct Toy
    {
        public string Name;
        public int Price;
        public int MinAge;
        public int MaxAge;

        public Toy(string name, int price, int minAge, int maxAge)
        {
            Name = name;
            Price = price;
            MinAge = minAge;
            MaxAge = maxAge;
        }

        public override string ToString()
        {
            return $"\t{Name} | Цена: {Price} руб. | Возраст: {MinAge}-{MaxAge} лет";
        }
    }
}
