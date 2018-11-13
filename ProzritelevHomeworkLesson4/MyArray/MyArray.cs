#region Описание задачи
/*Прозрителев Александр 
 * 
 * 3. библиотека для задания №3
 * 
 * а) Дописать класс для работы с одномерным массивом. 
 * + Реализовать конструктор, создающий массив определенного размера и заполняющий массив
 * числами от начального значения с заданным шагом. 
 * + Создать свойство Sum, которое возвращает сумму элементов массива, 
 * + метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива 
 * (старый массив, остается без изменений) 
 * + метод Multi, умножающий каждый элемент массива на определённое число
 * + свойство MaxCount, возвращающее количество максимальных элементов. 
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

Допилы по заданию выделены в одноименный регион
*/
#endregion
using System;
using System.Collections.Generic;
using System.IO;

namespace Prozritelev
{
    public class MyArray
    {
        private int[] a;

        public bool Error = false;        

        public MyArray(int size)
        {
            a = new int[size];
        }

        #region Допилы по заданию
        //конструктор для массива с шагом. Пришлось допиливать массив со случайными числами
        //ибо одинаковое количество параметров

        public enum Type { Random, Step };

        public MyArray(int size, int min, int max, Type type) : this(size)
        {
            if (type == Type.Random)
            {
                Random rnd = new Random();
                for (int i = 0; i < a.Length; i++)
                    a[i] = rnd.Next(min, max + 1);
            } else if (type == Type.Step)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = min;
                    min += max;
                }
            }

        }
        // сумма элементов массива
        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int el in a)
                {
                    sum += el;
                }
                return sum;
            }
        }
        //инверсия
        public MyArray Inverse()
        {
            int n = a.Length;
            MyArray b = new MyArray(n);
            for (int i = 0; i < n; i ++)
            {
                b[i] = -this[i];
            }
            return b;
        }
        //умножение
        public void Multi(int m)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
               a[i] *= m;
            }
        }
        //количество максимальных элементов
        public int CountMax()
        {
            int m = Max();            
            int count = 0;
            foreach (int element in a)
            {
                if (element == m) count++;
            }
            return count;
        }
        public Dictionary<int, int> NumVal()
        {
            //int n = a.Length;
            Dictionary<int, int> num = new Dictionary<int, int>();
            foreach (int el in a)
            {
                //num[el]++;
                if (num.ContainsKey(el) == true)
                {
                    num[el]++;
                }
                else
                {
                    num.Add(el, 1);
                }
            }

            return num;
        }
        //Dictionary<int, string> countries = new Dictionary<int, string>(5);


        #endregion //Допилы по заданию (конец)

        public MyArray(string filename)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(filename);
                int size = int.Parse(sr.ReadLine());
                a = new int[size];
                int i = 0;
                while (!sr.EndOfStream)
                {
                    a[i] = int.Parse(sr.ReadLine());
                    i++;
                }

            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
                Error = true;
            }
            catch (DirectoryNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
                Error = true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Error = true;
            }
            finally
            {
                if (sr != null) sr.Close();
            }

        }

        public int this[int index]
        {
            get { return a[index]; }
            set { a[index] = value; }
        }


        public void WriteToFile(string filename)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(filename);

            sw.WriteLine(a.Length);
            foreach (int el in a)
                sw.WriteLine(el);
            sw.Close();
        }

        public int Max()
        {
            int m = a[0];
            foreach (int element in a)
            {
                if (element > m) m = element;
            }
            return m;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
                s = s + String.Format("{0,5}", a[i]);
            return s;
        }
    }
}
