#region Описание задачи
/*Прозрителев Александр 
 *3. 
 * *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Например:
badc являются перестановкой abcd.
 */
#endregion

using System;
using System.IO;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson5
    {

        partial class Program
        {        
            //написал свою сортировку массива, для тренировки (знаю, что есть штатная)
            static char[] ArrSort(char[] a)
            {
                char t;

                for (int i = 0; i < a.Length-1; i++)
                {
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[j] < a[i])
                        {
                            t = a[i];
                            a[i] = a[j];
                            a[j] = t;
                        }
                    }
                }

                return a;
            }

            static bool Anagram(string s1, string s2)
            {
                bool result = true;
                if (s1.Length == s2.Length)
                {
                    char[] a1 = s1.ToCharArray();
                    char[] a2 = s2.ToCharArray();
                    //Array.Sort(a1);
                    ArrSort(a1);
                    Array.Sort(a2);

                    for (int i = 0; i < a1.Length && result == true; i++)
                    {
                        if (a1[i] != a2[i]) result = false;
                    }

                }
                else result = false;

                return result;
            }

            static void Task3()
            {
                TaskTitle("Задание №3 - Перестановки");

                string s1 = Quest("Введите строку №1: ");
                string s2 = Quest("Введите строку №2: ");               

                Console.WriteLine($"Строка \'{s1}\' анаграмма \'{s2}\' ? = {Anagram(s1, s2)}");

                TaskTitle("Задание №3 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
