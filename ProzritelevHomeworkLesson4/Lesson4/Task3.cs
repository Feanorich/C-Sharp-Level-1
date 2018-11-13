#region Описание задачи
/*Прозрителев Александр 
 * 
 * 3. а) Дописать класс для работы с одномерным массивом. 
 * Реализовать конструктор, создающий массив определенного размера и заполняющий массив
 * числами от начального значения с заданным шагом. 
 * Создать свойство Sum, которое возвращает сумму элементов массива, 
 * метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива 
 * (старый массив, остается без изменений) 
 * метод Multi, умножающий каждый элемент массива на определённое число
 * свойство MaxCount, возвращающее количество максимальных элементов. 
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

 Класс MyArray уже вынесен в одноименную библиотеку
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson4
    {
        partial class Program
        {

            static void Task3()
            {
                TaskTitle("Задание №3 - класс MyArray");

                //MyArray my1 = new MyArray(10, 1, 100, MyArray.Type.Random);
                //Console.WriteLine(my1.ToString());
                Console.WriteLine("\n массив с шагом");
                MyArray my = new MyArray(5, 5, -2, MyArray.Type.Step);
                MyArray myI = my.Inverse();

                Console.WriteLine(my.ToString());
                Console.WriteLine($"\n сумма элементов = {my.Sum}");
                Console.WriteLine("\n инверсия");                
                Console.WriteLine(myI);

                Console.WriteLine("\n умножение (например, на 2)");
                my.Multi(2);
                Console.WriteLine(my.ToString());                

                Console.WriteLine("\n чуть изменим массив,для демонстрации подсчета максимальных");
                my[2] = my.Max(); //назначим второй элемент тоже максимальным
                Console.WriteLine(my.ToString());
                Console.WriteLine($"\n количество максимальных элементов = {my.CountMax()}");

                Console.WriteLine("\n подсчет входжений");
                Dictionary<int, int> num = my.NumVal();
                foreach (KeyValuePair<int, int> el in num)
                {
                    Console.WriteLine($"{el.Key} = {el.Value}");
                }                

                TaskTitle("Задание №3 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
