#region Описание
/*Прозрителев Александр  
 *
 *класс с нужными процедурками
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prozritelev
{
    public class MyClass
    {
        public static string glFileName = @"D:\temp\data.txt";

        //ввод числа с защитой от дурака
        public static int InputInt(String quest = "Введите число: ", string pref = "(введено неверное значение) ")
        {
            bool f = false;
            string p = "";
            int x = 0; ;
            while (f == false)
            {
                f = int.TryParse(Quest(p + quest), out x);
                p = pref;
            }
            return x;
        }

        public static string Quest(String quest = "Введите строку: ")
        {
            Console.Write(quest);
            return (Console.ReadLine());
        }

        //наименьший общий делитель (притырено из методички, но развернул по блокам, чтобы понять принцип)
        public static int NOD(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }

            }

            return a;
        }

        public static void Pause()
        {
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static void Pause(string message = "Press any key")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static void Pause(int x = 0, int y = 0, string message = "Press any key")
        {
            if (x > 0 && y > 0)
            {
                Console.SetCursorPosition(x, y);
            }
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static void Print(string ms, int x = 0, int y = 0)
        {
            if (x > 0 && y > 0)
            {
                Console.SetCursorPosition(x, y);
            }
            Console.WriteLine(ms);
        }

        public static void TaskTitle(String title = "")
        {
            Print("\n" + title);
        }

        public static void NortonStyle(String title = "")
        {
            if (title != "")
            {
                Console.Title = title;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
        }

    }

}
