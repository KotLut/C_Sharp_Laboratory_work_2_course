using System;
using System.Text;

namespace LK_LABA3_CSHARP
{
    public static class Color
    {
        public const string Reset = "\u001b[0m";
        public const string Red = "\u001b[31m";
        public const string Green = "\u001b[32m";
        public const string Yellow = "\u001b[33m";
        public const string Blue = "\u001b[34m";
        public const string Purple = "\u001b[35m";
        public const string Cyan = "\u001b[36m";
        public const string White = "\u001b[37m";
        public const string Brown = "\u001b[38;5;94m";
        public const string Gray = "\u001b[90m";
        public const string Pink = "\u001b[38;5;162m";

        public const string TotalRed = "\u001b[0;30;41m";
        public const string TotalGreen = "\u001b[0;30;42m";
        public const string TotalYellow = "\u001b[0;30;43m";
        public const string TotalBlue = "\u001b[0;30;44m";
        public const string TotalPurple = "\u001b[0;30;45m";
        public const string TotalCyan = "\u001b[0;30;46m";
        public const string TotalWhite = "\u001b[0;30;47m";
    }

    public static class ScreenUtils
    {
        public static void Initialize()
        {
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void Paint(string text, string color)
        {
            Console.Write(color + text + Color.Reset);
        }

        public static void PaintLine(string text, string color)
        {
            Console.WriteLine(color + text + Color.Reset);
        }

        public static void PaintHeader(string text)
        {
            PaintLine(text, Color.Cyan);
        }

        public static void PrintError(string message)
        {
            PaintLine(message, Color.Red);
        }

        public static void DrawPicture(string name)
        {
            string color;
            string picture;

            switch (name)
            {
                case "laba":
                    color = Color.TotalYellow;
                    picture = """

                            ····································
                            :                                  :
                            :    _      _   ___   _     ____   :
                            :   | |    /_\ | _ ) /_\   |__ /   :
                            :   | |__ / _ \| _ \/ _ \   |_ \   :
                            :   |____/_/ \_\___/_/ \_\ |___/   :
                            :                                  :
                            ····································

                    """;

                    break;

                case "goodbye":
                    color = Color.Green;
                    picture = """

                        ***************************************************************************************************
                        *                                                                                                 *
                        *         ::::::::   ::::::::   ::::::::  :::::::::         :::::::::  :::    ::: :::   ::: :::   *
                        *       :+:    :+: :+:    :+: :+:    :+: :+:    :+:        :+:    :+: :+:    :+: :+:   :+: :+:    *
                        *      +:+        +:+    +:+ +:+    +:+ +:+    +:+        +:+    +:+ +:+    +:+  +:+ +:+  +:+     *
                        *     :#:        +#+    +:+ +#+    +:+ +#+    +:+        +#++:++#+  +#+    +:+   +#++:   +#+      *
                        *    +#+   +#+# +#+    +#+ +#+    +#+ +#+    +#+        +#+    +#+ +#+    +#+    +#+    +#+       *
                        *   #+#    #+# #+#    #+# #+#    #+# #+#    #+#        #+#    #+# #+#    #+#    #+#               *
                        *   ########   ########   ########  #########         #########   ########     ###    ###         *
                        *                                                                                                 *
                        ***************************************************************************************************

                    """;

                    break;

                default:
                    PrintError("\tКартинки нет :(");
                    return;
            }

            PaintLine(picture, color);
        }
    }

    public class Utils
    {
        public void WaitForContinue()
        {
            ScreenUtils.Paint("\n\tВведите что-нибудь для продолжения >> ", Color.Gray);
            Console.ReadLine();
        }
    }

    public class InputValidator
    {
        public int GetInt()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    return Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    ScreenUtils.PrintError("\tНекорректный ввод :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
                catch (OverflowException)
                {
                    ScreenUtils.PrintError("\tСлишком большое число :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
            }
        }

        public int GetInt(int min, int max)
        {
            int result = GetInt();

            while (result < min || result > max)
            {
                ScreenUtils.PrintError($"\tЧисло должно быть от {min} до {max} :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);

                result = GetInt();
            }

            return result;
        }

        public long GetLong()
        {
            while (true)
            {
                string input = Console.ReadLine();

                try
                {
                    return Convert.ToInt64(input);
                }
                catch (FormatException)
                {
                    ScreenUtils.PrintError("\tНекорректный ввод :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
                catch (OverflowException)
                {
                    ScreenUtils.PrintError("\tСлишком большое число :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
            }
        }

        public float GetFloat()
        {
            while (true)
            {
                string input = Console.ReadLine();
                input = input.Replace('.', ',');

                try
                {
                    return Convert.ToSingle(input);
                }
                catch (FormatException)
                {
                    ScreenUtils.PrintError("\tНекорректный ввод :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
                catch (OverflowException)
                {
                    ScreenUtils.PrintError("\tСлишком большое число :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
            }
        }

        public double GetDouble()
        {
            while (true)
            {
                string input = Console.ReadLine();
                input = input.Replace('.', ',');

                try
                {
                    return Convert.ToDouble(input);
                }
                catch (FormatException)
                {
                    ScreenUtils.PrintError("\tНекорректный ввод :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
                catch (OverflowException)
                {
                    ScreenUtils.PrintError("\tСлишком большое число :(");
                    ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
                }
            }
        }
        public char GetChar()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    return Convert.ToChar(input);
                }

                ScreenUtils.PrintError("\tНужно ввести один символ :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);
            }
        }

        public string GetString()
        {
            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                ScreenUtils.PrintError("\tСтрока не может быть пустой :(");
                ScreenUtils.Paint("\tПовторите ввод >> ", Color.Yellow);

                input = Console.ReadLine();
            }

            return input.Trim();
        }
    }
}