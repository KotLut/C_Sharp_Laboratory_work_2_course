using System;
using System.Collections.Generic;

namespace LABA_4
{
    internal static class CollectionTasks
    {
        private static string[] _words =
        {
            "Пельмени", "Береза", "Лосось", "Анигири", "Ботать", "Ёлка",
            "Палка", "Ясень", "Волга", "Человек", "Енисей", "Вокал"
        };

        private static string[] _songs =
        {
            "Группа крови", "Кукушка", "Перемен", "Невеста",
            "Mr. Blue", "Smells Like Teen Spirit", "Bohemian Rhapsody",
            "Billie Jean", "Catch You", "Tuesday", "Lose My Mind", "Numb"
        };

        private static string _vowels = "аеёиоуыэюя";

        private static char[] _separators =
        {
            ' ', ',', '.', '!', '?', ';', ':', '-', '—', '(', ')', '"', '\t', '\r', '\n'
        };

        private static string[] _textWords =
        {
            "ютуб", "века", "лось", "индекс", "ёршик", "ямка",
            "ялта", "очень", "наследование", "пара", "лаба", "мама"
        };

        private static int _winnerScore = 200;

        private static int _maxScore = 400;

        private static string[] _surnames =
        {
            "Лётчик", "Комиссаренко", "Невзначай", "Апчхи", "Винкай",
            "Дверидзе", "Сохранко", "Ясенченко", "Нулик", "Держим"
        };

        private static string[] _firstNames =
        {
            "Евпатий", "Алексий", "Афанасья", "Варфаломей", "Иннокентий", "Юлианна", "Игорь", "Антон"
        };

        public static bool HasDuplicates(List<string> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static List<string> ReadList(int count, InputValidator validator)
        {
            List<string> list = new List<string>();
            string word;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"\tЭлемент {i + 1} >> ");
                word = validator.GetString();
                list.Add(word);
            }

            return list;
        }

        public static List<string> CreateRandomList(Random random)
        {
            List<string> list = new List<string>();
            int count = random.Next(2, 9);
            int index;

            for (int i = 0; i < count; i++)
            {
                index = random.Next(_words.Length);
                list.Add(_words[index]);
            }

            return list;
        }

        public static void PrintList(List<string> list)
        {
            Console.Write("\t");

            foreach (string word in list)
            {
                Console.Write(word + "; ");
            }

            Console.WriteLine();
        }

        public static bool RemoveFirst(LinkedList<string> list, string value)
        {
            return list.Remove(value);
        }

        public static LinkedList<string> ReadLinkedList(int count, InputValidator validator)
        {
            LinkedList<string> list = new LinkedList<string>();
            string word;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"\tЭлемент {i + 1} >> ");
                word = validator.GetString();
                list.AddLast(word);
            }

            return list;
        }

        public static LinkedList<string> CreateRandomLinkedList(Random random)
        {
            LinkedList<string> list = new LinkedList<string>();
            int count = random.Next(2, 9);
            int index;

            for (int i = 0; i < count; i++)
            {
                index = random.Next(_words.Length);
                list.AddLast(_words[index]);
            }

            return list;
        }

        public static void PrintLinkedList(LinkedList<string> list)
        {
            Console.Write("\t");

            if (list.Count == 0)
            {
                Console.WriteLine("список пуст");
                return;
            }

            foreach (string word in list)
            {
                Console.Write(word + "; ");
            }

            Console.WriteLine();
        }

        public static HashSet<string> GetLikedByAll(List<HashSet<string>> listeners)
        {
            HashSet<string> result = new HashSet<string>(listeners[0]);

            for (int i = 1; i < listeners.Count; i++)
            {
                result.IntersectWith(listeners[i]);
            }

            return result;
        }

        private static HashSet<string> GetLikedByAnyone(List<HashSet<string>> listeners)
        {
            HashSet<string> result = new HashSet<string>();

            for (int i = 0; i < listeners.Count; i++)
            {
                result.UnionWith(listeners[i]);
            }

            return result;
        }

        public static HashSet<string> GetLikedBySome(List<HashSet<string>> listeners)
        {
            HashSet<string> result = GetLikedByAnyone(listeners);
            HashSet<string> likedByAll = GetLikedByAll(listeners);

            result.ExceptWith(likedByAll);

            return result;
        }

        public static HashSet<string> GetLikedByNobody(
            HashSet<string> catalog, List<HashSet<string>> listeners)
        {
            HashSet<string> result = new HashSet<string>(catalog);
            HashSet<string> likedByAnyone = GetLikedByAnyone(listeners);

            result.ExceptWith(likedByAnyone);

            return result;
        }
        

        public static HashSet<string> ReadCatalog(int count, InputValidator validator)
        {
            HashSet<string> catalog = new HashSet<string>();
            string song;
            bool isAdded;

            while (catalog.Count < count)
            {
                Console.Write($"\tПроизведение {catalog.Count + 1} >> ");
                song = validator.GetString();
                isAdded = catalog.Add(song);

                if (!isAdded)
                {
                    ScreenUtils.PrintError("\tТакое произведение уже есть :(");
                }
            }

            return catalog;
        }

        public static HashSet<string> CreateRandomCatalog(Random random)
        {
            HashSet<string> catalog = new HashSet<string>();
            int count = random.Next(3, 9);
            int index;

            while (catalog.Count < count)
            {
                index = random.Next(_songs.Length);
                catalog.Add(_songs[index]);
            }

            return catalog;
        }

        public static List<HashSet<string>> ReadListeners(
            HashSet<string> catalog, int listenersCount, InputValidator validator)
        {
            List<HashSet<string>> listeners = new List<HashSet<string>>();
            HashSet<string> liked;
            int answer;

            for (int i = 0; i < listenersCount; i++)
            {
                liked = new HashSet<string>();
                Console.WriteLine($"\n\tМеломан {i + 1}:");

                foreach (string song in catalog)
                {
                    Console.Write($"\tНравится \"{song}\"? (1 - да, 0 - нет) >> ");
                    answer = validator.GetInt(0, 1);

                    if (answer == 1)
                    {
                        liked.Add(song);
                    }
                }

                listeners.Add(liked);
            }

            return listeners;
        }

        public static List<HashSet<string>> CreateRandomListeners(
            HashSet<string> catalog, int listenersCount, Random random)
        {
            List<HashSet<string>> listeners = new List<HashSet<string>>();
            HashSet<string> liked;

            for (int i = 0; i < listenersCount; i++)
            {
                liked = new HashSet<string>();

                foreach (string song in catalog)
                {
                    if (random.Next(2) == 1)
                    {
                        liked.Add(song);
                    }
                }

                listeners.Add(liked);
            }

            return listeners;
        }

        public static void PrintSet(string title, HashSet<string> set)
        {
            Console.Write("\t" + title);

            if (set.Count == 0)
            {
                Console.WriteLine("пусто");
                return;
            }

            foreach (string song in set)
            {
                Console.Write(song + "; ");
            }

            Console.WriteLine();
        }

        public static void PrintListeners(List<HashSet<string>> listeners)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                PrintSet($"Меломан {i + 1}: ", listeners[i]);
            }
        }

        public static HashSet<char> FindVowelsInOneWord(string path)
        {
            HashSet<char> vowels = new HashSet<char>(_vowels);
            HashSet<char> met = new HashSet<char>();
            HashSet<char> repeated = new HashSet<char>();
            HashSet<char> wordVowels;
            HashSet<char> wordRepeated;
            string text;
            string[] words;

            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return met;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }

            words = text.ToLower().Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                wordVowels = new HashSet<char>(word);
                wordVowels.IntersectWith(vowels);

                wordRepeated = new HashSet<char>(wordVowels);
                wordRepeated.IntersectWith(met);

                repeated.UnionWith(wordRepeated);
                met.UnionWith(wordVowels);
            }

            met.ExceptWith(repeated);

            return met;
        }

        public static void CreateRandomTextFile(string path, Random random)
        {
            int linesCount = random.Next(2, 5);
            int wordsCount;
            int index;

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < linesCount; i++)
                {
                    wordsCount = random.Next(3, 6);

                    for (int j = 0; j < wordsCount; j++)
                    {
                        index = random.Next(_textWords.Length);
                        writer.Write(_textWords[index] + " ");
                    }

                    writer.WriteLine();
                }
            }

            ScreenUtils.PaintLine($"\tФайл {path} создан автозаполнением.", Color.Green);
        }

        public static void CreateTextFileFromKeyboard(
            string path, int linesCount, InputValidator validator)
        {
            string line;

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < linesCount; i++)
                {
                    Console.Write($"\tСтрока {i + 1} >> ");
                    line = validator.GetString();
                    writer.WriteLine(line);
                }
            }

            ScreenUtils.PaintLine($"\tФайл {path} создан.", Color.Green);
        }

        public static void PrintTextFile(string path)
        {
            string text;

            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }

            Console.WriteLine($"Содержимое файла {path}:");
            Console.WriteLine(text);
        }

        public static void PrintVowels(HashSet<char> vowels)
        {
            Console.Write("\tГласные, которые есть ровно в одном слове: ");

            if (vowels.Count == 0)
            {
                Console.WriteLine("таких нет");
                return;
            }

            foreach (char letter in _vowels)
            {
                if (vowels.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
            }

            Console.WriteLine();
        }

        public static string FindBestNonWinner(string path)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            Dictionary<int, string> names = new Dictionary<int, string>();
            string[] parts;
            int participantsCount;
            int score;
            int bestScore = -1;
            int secondScore = -1;
            int targetScore;

            if (!File.Exists(path))
            {
                ScreenUtils.PrintError($"\tФайл {path} не найден :(");
                return "";
            }

            using (StreamReader reader = new StreamReader(path))
            {
                participantsCount = Convert.ToInt32(reader.ReadLine());

                for (int i = 0; i < participantsCount; i++)
                {
                    parts = reader.ReadLine().Split(' ');
                    score = Convert.ToInt32(parts[3]);

                    if (counts.ContainsKey(score))
                    {
                        counts[score]++;
                    }
                    else
                    {
                        counts.Add(score, 1);
                    }

                    names[score] = parts[0] + " " + parts[1];
                }
            }

            foreach (int key in counts.Keys)
            {
                if (key > bestScore)
                {
                    secondScore = bestScore;
                    bestScore = key;
                }
                else if (key > secondScore)
                {
                    secondScore = key;
                }
            }

            if (bestScore > _winnerScore && counts[bestScore] * 5 <= participantsCount)
            {
                targetScore = secondScore;
            }
            else
            {
                targetScore = bestScore;
            }

            if (counts[targetScore] == 1)
            {
                return "Лучший из не ставших победителями: " + names[targetScore];
            }

            return "Число искомых (лучших из не ставших победителями): " + counts[targetScore].ToString();
        }

        public static void CreateRandomOlympiadFile(string path, Random random)
        {
            int count = random.Next(5, 16);
            int surnameIndex;
            int nameIndex;
            int schoolClass;
            int score;

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    surnameIndex = random.Next(_surnames.Length);
                    nameIndex = random.Next(_firstNames.Length);
                    schoolClass = random.Next(7, 12);
                    score = random.Next(9) * 50;

                    writer.WriteLine($"{_surnames[surnameIndex]} {_firstNames[nameIndex]} {schoolClass} {score}");
                }
            }

            ScreenUtils.PaintLine($"\tФайл {path} создан автозаполнением.", Color.Green);
        }

        public static void CreateOlympiadFileFromKeyboard(
            string path, int count, InputValidator validator)
        {
            string surname;
            string firstName;
            int schoolClass;
            int score;

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(count);

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\n\tУчастник {i + 1}:");
                    surname = ReadWord("\tФамилия (до 20 символов) >> ", 20, validator);
                    firstName = ReadWord("\tИмя (до 15 символов) >> ", 15, validator);

                    Console.Write("\tКласс (7-11) >> ");
                    schoolClass = validator.GetInt(7, 11);

                    Console.Write($"\tБаллы (0-{_maxScore}) >> ");
                    score = validator.GetInt(0, _maxScore);

                    writer.WriteLine($"{surname} {firstName} {schoolClass} {score}");
                }
            }

            ScreenUtils.PaintLine($"\n\tФайл {path} создан.", Color.Green);
        }

        private static string ReadWord(string message, int maxLength, InputValidator validator)
        {
            string word;

            Console.Write(message);
            word = validator.GetString();

            while (word.Contains(' ') || word.Length > maxLength)
            {
                ScreenUtils.PrintError($"\tОдно слово без пробелов, не длиннее {maxLength} символов :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                word = validator.GetString();
            }

            return word;
        }

    }
}