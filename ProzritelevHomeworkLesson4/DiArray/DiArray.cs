#region Описание задачи
/*Прозрителев Александр 
 * 
 * 5. библиотека для задания №5
 * 
* а) Реализовать библиотеку с классом для работы с двумерным массивом. 
* + Реализовать конструктор, заполняющий массив случайными числами. 
* + Создать методы, которые возвращают сумму всех элементов массива, 
* + сумму всех элементов массива больше заданного, 
* + свойство, возвращающее минимальный элемент массива, 
* + свойство, возвращающее максимальный элемент массива, 
* + метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*б) - Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) - Обработать возможные исключительные ситуации при работе с файлами.

Допилы по заданию выделены в одноименный регион
*/
#endregion
using System;
using System.Collections.Generic;
using System.IO;

namespace Prozritelev
{
    public class DiArray
    {
        private int[,] a;

        public bool Error = false;

        public DiArray(int i, int j) //базовый конструктор
        {
            a = new int[i, j];
        }

        public DiArray(int r, int c, int min, int max) : this(r, c)
        {
            Random rnd = new Random();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    a[i, j] = rnd.Next(min, max + 1);
                }
            }
        }

        public DiArray(string filename)
        {
            ReadFile(filename);
        }

        public int Min
        {
            get
            {
                int min = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {                        
                        if ((i == 0 && j == 0) || (a[i, j] < min)) min = a[i, j];
                    }
                }
                return min;
            }
        }

        public int Max
        {
            get
            {
                int max = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)                    {
                        
                        if ((i == 0 && j == 0) || (a[i, j] > max)) max = a[i, j];
                    }
                }
                return max;
            }
        }

        public int MaxRC(out int r, out int c)
        {
            int max = 0;
            r = -1; c = -1; 
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if ((i == 0 && j == 0) || (a[i, j] > max))
                    {
                        max = a[i, j];
                        r = i;
                        c = j;
                    }                                              
                }
            }
            return max;

        }

        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    sum += a[i, j];
                }
            }
            return sum;
        }

        public int Sum(int f)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > f)
                    {
                        sum += a[i, j];
                    }
                }
            }
            return sum;
        }

        public void ReadFile(string filename)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(filename);                
                string line = sr.ReadLine();
                string[] arr = line.Split('|');

                int mI = int.Parse(arr[0]);
                int mJ = int.Parse(arr[1]);

                a = new int[mI, mJ];
                int i = 0;                
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    arr = line.Split('|');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        a[i, j] = int.Parse(arr[j]);
                    }                    
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

        public void WriteToFile(string filename)
        {
            StreamWriter sw = null;
            sw = new StreamWriter(filename);
            
            string s = "";
            int mI = a.GetLength(0);
            int mJ = a.GetLength(1);
            sw.WriteLine($"{mI}|{mJ}");

            for (int i = 0; i < mI; i++)
            {                   
                for (int j = 0; j < mJ; j++)
                {
                    //s = s + a[i, j];
                    //if (j != mJ - 1) s = s + "|";
                    s = string.Join("|", a);
                }
                sw.WriteLine(s);
                s = "";
            }
            
            sw.Close();
        }

        public override string ToString()
        {
            //Чтобы вывод на экран массива был нагляднее - пронумеруем строки и колонки
            string s = "";
            s = s + String.Format("{0,5}", @"R\C");
            for (int j = 0; j < a.GetLength(1); j++)
            {
                s = s + String.Format("{0,5}", $"[{j}]");
            }
            s = s + "\n";

            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = s + String.Format("{0,5}", $"[{i}]"); 
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s = s + String.Format("{0,5}", a[i, j]);
                }
                s = s + "\n";
            }

            return s;
        }

    }
}
