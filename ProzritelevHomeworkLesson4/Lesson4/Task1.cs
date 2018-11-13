#region Описание задачи
/*Прозрителев Александр 
 * 
 * 1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения 
 * от –10 000 до 10 000 включительно. Заполнить случайными числами. Написать программу, позволяющую 
 * найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
 * В данной задаче под парой подразумевается два подряд идущих элемента массива. 
 * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
 */
#endregion

using System;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson4
    {

        partial class Program
        {
            static string ArrPrint(int[] a)
            {
                string s = "";
                foreach (int v in a)
                    s = s + v + " ";
                return s;
            }
            
            //метод чисто под несколько задач этого урока, чтоб меньше писать
            static int[] MakeArr(int n, int min, int max)                
            {                
                int[] a = new int[n];
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                {
                    a[i] = rnd.Next(min, max);
                }
                return a;
            }

            static void Task1()
            {
                TaskTitle("Задание №1 - пары в массиве");
                int n = 20;
                int[] a = MakeArr(n, -10000, 10000);
                Console.WriteLine(ArrPrint(a));

                int count = 0;
                int pair = 0;

                for (int i = 0; i < n; i += 2)
                {
                    if (i + 1 <= n - 1) //еще можем создать пару
                    {
                        pair++;
                        Console.Write($"Пара №{pair} - {a[i]} {a[i + 1]}");
                        if (a[i] % 3 == 0 || a[i + 1] % 3 == 0)
                        {
                            count++;
                            Console.Write(" - годная");
                        }
                        Console.WriteLine();
                    }                    
                }

                Print($"Количество пар = {count}");


                TaskTitle("Задание №1 завершено. Нажмиме любую клавишу.");
            }


        }
    }
}
