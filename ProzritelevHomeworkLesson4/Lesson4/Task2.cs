#region Описание задачи
/*Прозрителев Александр 
 * 
 * 2. Реализуйте задачу 1 в виде статического класса StaticClass; 
 * а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1; 
 * б) Добавьте статический метод для считывания массива из текстового файла. 
 * Метод должен возвращать массив целых чисел; 
 * в)*Добавьте обработку ситуации отсутствия файла на диске.
 */
#endregion

using System;
using System.IO;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson4
    {
        static class ArrTools   
        {
            public static void FindPair(int[] a, int d)
            {
                int n = a.Length;
                int count = 0;
                int pair = 0;

                for (int i = 0; i < n; i += 2)
                {
                    if (i + 1 <= n - 1) //еще можем создать пару
                    {
                        pair++;
                        Console.Write($"пара №{pair} - {a[i]} {a[i + 1]}");
                        if (a[i] % 3 == 0 || a[i + 1] % 3 == 0)
                        {
                            count++;
                            Console.Write(" - годная");
                        }
                        Console.WriteLine();
                    }
                }

                Print($"количество пар = {count}");

            }

            public static int[] FromFile(string fileName)
            {
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(fileName);
                    // Считываем количество элементов массива
                    int n = int.Parse(sr.ReadLine());
                    int[] a = new int[n];
                    // Считываем массив
                    for (int i = 0; i < n; i++)
                    {
                        a[i] = int.Parse(sr.ReadLine());
                    }
                    sr.Close();
                    return a;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    if (sr != null) sr.Close();
                    return new int[0];
                }                
            }
        }

        partial class Program
        {   
            static void Task2()
            {
                TaskTitle("Задание №2 - пары в массиве (классом)");
                int n = 20;
                int[] a = null;

                Print("");
                Print($"1 - Использовать случайный массив размером[{n}]");
                Print($"2 - Загрузить массив из файла {glFileName}");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        a = MakeArr(n, -10, 10); //метод из первого задания
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        a = ArrTools.FromFile(glFileName); //glFileName задается в MyClass.cs
                        break;            
                    default:
                        Print("Wrong select!");
                        break;
                }
                Print("");
                Console.WriteLine(ArrPrint(a));

                ArrTools.FindPair(a, 3);

                TaskTitle("Задание №2 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
