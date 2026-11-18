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

    }
}