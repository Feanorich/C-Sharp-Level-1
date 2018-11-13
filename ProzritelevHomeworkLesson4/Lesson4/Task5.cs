
#region Описание задачи
/*Прозрителев Александр 
 * 
* а) Реализовать библиотеку с классом для работы с двумерным массивом. 
* Реализовать конструктор, заполняющий массив случайными числами. 
* Создать методы, которые возвращают сумму всех элементов массива, 
* сумму всех элементов массива больше заданного, 
* свойство, возвращающее минимальный элемент массива, 
* свойство, возвращающее максимальный элемент массива, 
* метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.
 */
#endregion

using System;
using System.IO;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson4
    {

        partial class Program
        {

            static void Task5()
            {
                TaskTitle("Задание №5 - двухмерный массив");
                int r = 5, c = 10;
                Console.WriteLine($"\n Создадим массив [{r},{c}]");
                DiArray di = new DiArray(r, c, -10, 10);
                Console.WriteLine(di.ToString());

                Console.WriteLine("\n Просуммируем элементы:");
                Console.WriteLine($" - сумма элементов = {di.Sum()}");
                int f = 0;
                Console.WriteLine($" - сумма элементов (>{f}) = {di.Sum(f)}");
                Console.WriteLine($"\n Минимальное число = {di.Min}");
                Console.WriteLine($" Максимальное число = {di.Max}");
                int i, j;
                int max = di.MaxRC(out i, out j);
                Console.WriteLine($"\n Максимальный элемент [{i},{j}] = {max}");

                string fileName = @"D:\temp\dataDi.txt";
                Console.WriteLine($"\n Сохраним в файл {fileName}");
                di.WriteToFile(fileName);

                Console.WriteLine($"\n Конструктор из файла {fileName}");
                DiArray di1 = new DiArray(fileName);
                if (di1.Error == false)
                {
                    Console.WriteLine(di1.ToString());
                }


                TaskTitle("Задание №5 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
