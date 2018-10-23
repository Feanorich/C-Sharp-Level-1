#region Описание задачи
/*Прозрителев Александр 
 * 3.
 * Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается 
массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит 
в этот текст. Здесь требуется использовать класс Dictionary.

РЕАЛИЗАЦИЯ
хотел решить разными способами (через regex и нет) но не успел. Решил так, как казалось проще.
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson5
    {
        public class Message
        {
            public enum Sort { ask, des }

            public static string[] SortStrings(string[] str, Sort sort)
            {
                string t;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if ((sort == Sort.ask && str[j].Length < str[i].Length)
                            || (sort == Sort.des && str[j].Length > str[i].Length))
                        {
                            t = str[i];
                            str[i] = str[j];
                            str[j] = t;
                        }

                    }

                }

                return str;
            }

            public static string[] SplitMessage(string msg)
            {
                StringBuilder a = new StringBuilder(msg);
                for (int i = 0; i < a.Length;)
                    if (char.IsPunctuation(a[i])) a.Remove(i, 1);
                    else if (char.IsControl(a[i])) a.Replace(a[i].ToString(), " ", i, 1);
                    else ++i;
                string str = a.ToString();
                str = str.Replace("  ", " ");
                str = str.Replace("  ", " ");
                string[] s = str.Split(' ');

                return s;
            }

            public static string ReadFile(string filename)
            {
                StreamReader fileIn = new StreamReader("Task2.txt");
                return fileIn.ReadToEnd();
            }

            //в) Найти самое длинное слово сообщения.
            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            public static string Longest(string msg)
            {
                string[] str = SortStrings(SplitMessage(msg), Sort.des);
                StringBuilder a = new StringBuilder();
                int l = str[0].Length;  //длинна самого длинного слова

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Length == l)
                    {
                        a.Append(str[i]);
                        a.Append(" ");
                    }
                }

                return a.ToString();
            }

            //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            public static string DelWord(string msg, char l)
            {
                string filter = @"\b\w{0,}" + l + @"{1}\b";
                Regex reg = new Regex(filter);
                
                msg = reg.Replace(msg, "<>");   //<> вместо "" для отладки, чтобы видеть откуда удалилось слово

                return msg;
            }

            //а) Вывести только те слова сообщения, которые содержат не более n букв
            public static void NoLonger(string msg, int n)
            {
                Console.WriteLine($"\nСлова длинной, не более n={n}");
                string[] str = SplitMessage(msg);

                foreach (string st in str)
                {
                    if (st.Length <= n)
                    {
                        Console.WriteLine(st);
                    }
                }
            }

            //Через регулярку а) Вывести только те слова сообщения, которые содержат не более n букв
            public static string NoLongerR(string msg, int n)
            {
                Console.WriteLine(@"\b\w{1," + n + @"}\b");
                Regex regEx = new Regex(@"\b\w{1," + n + @"}\b");

                MatchCollection matches = regEx.Matches(msg);
                foreach (Match m in matches)
                {
                    Console.WriteLine("Слово \"{0}\" позиция {1} длина {2}", m.Value, m.Index, m.Length);
                }
                Console.WriteLine(matches.Count);

                return msg;
            }

            /*
            д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается 
            массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит 
            в этот текст. Здесь требуется использовать класс Dictionary.
            */
            public static Dictionary<string, int> Frequency(string msg, string[] s)
            {
                Dictionary<string, int> num = new Dictionary<string, int>();

                string filter = string.Empty;

                for (int i = 0; i < s.Length; i++)
                {
                    filter = @"\b" + s[i] + @"\b";
                    Regex reg = new Regex(filter);
                    MatchCollection matches = reg.Matches(msg);
                    foreach (Match m in matches)
                    {
                        if (num.ContainsKey(m.Value) == true)
                        {
                            num[m.Value]++;
                        }
                        else
                        {
                            num.Add(m.Value, 1);
                        }
                    }

                }                

                return num;
            }
        }

        partial class Program
        {

            static void Task2()
            {
                TaskTitle("Задание №2 - класс message");

                //string s = "Задание №2 завершено. Нажмиме любую клавишу. Пиво";
                string s = Message.ReadFile(@"Task2.txt");
                Console.WriteLine("Исходная строка: " + s);
                Message.NoLonger(s, 4);

                char l = 'е';
                Console.WriteLine($"\nУдалим слова оканчивающиеся на \'{l}''");
                Console.WriteLine(Message.DelWord(s, l));

                Console.WriteLine($"\nСамые длинные слова:");
                Console.WriteLine(Message.Longest(s));

                string words = "слова слов";

                Console.WriteLine($"\nПосчитаем слова: {words}");

                string[] filter = words.Split(' ');

                Dictionary<string, int> num = Message.Frequency(s, filter);

                foreach (KeyValuePair<string, int> st in num)
                {
                    Console.WriteLine($"[{st.Value}] {st.Key}");
                }

                TaskTitle("Задание №2 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
