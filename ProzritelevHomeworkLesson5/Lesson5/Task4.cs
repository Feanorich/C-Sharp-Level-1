//шаблон
#region Описание задачи
/*Прозрителев Александр 
 * 
 * *Задача ЕГЭ. На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов 
 * некоторой средней школы. В первой строке сообщается количество учеников N, которое не меньше 10, 
 * но не превосходит 100, каждая из следующих N строк имеет следующий формат: <Фамилия> <Имя> <оценки>,
 * где <Фамилия> — строка, состоящая не более чем из 20 символов, 
 * <Имя> — строка, состоящая не более чем из 15 символов, 
 * <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. 
 * <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. 
 * Пример входной строки: Иванов Петр 4 5 3 Требуется написать как можно более эффективную программу, 
 * которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
 * Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, 
 * следует вывести и их фамилии и имена. 
 */
#endregion

using System;
using System.IO;
using System.Text;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson5
    {
        struct Student
        {
            string name;
            double middle;

            public Student(string s)
            {
                string[] str = s.Split(' ');    //разобьем на массив
                name = $"{str[0]} {str[1]}";    // первые два элемента - фамилия и имя

                middle = 0;
                for (int i = 2; i < str.Length; i++)    //остальные это оценки
                {
                    middle += double.Parse(str[i]);
                }
                middle /= (str.Length - 2);
            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public double Middle
            {
                get
                {
                    return middle;
                }
                set
                {
                    middle = value;
                }
            }

            public static void SortMiddle(ref Student[] a)  //сортировка массива по среднему балу
            {
                Student t;

                for (int i = 0; i < a.Length - 1; i++)
                {
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        if (a[j].Middle < a[i].Middle)
                        {
                            t = a[i];
                            a[i] = a[j];
                            a[j] = t;
                        }
                    }
                }

            }


            public static Student[] ReadFile(string filename)
            {
                StreamReader sr = null;

                Student[] a;

                try
                {                    
                    sr = new StreamReader(filename, Encoding.GetEncoding(1251));
                    int size = int.Parse(sr.ReadLine());
                    a = new Student[size];
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        a[i] = new Student(sr.ReadLine());
                        i++;
                    }

                }               
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    a = new Student[0];
                }
                finally
                {
                    if (sr != null) sr.Close();
                }

                return a;
            }

            public override string ToString()
            {
                return $"{name} {middle}";
            }
            
            //num - количество худших учеников для вывода на экран
            public static void PrintAverage(Student[] a, int num)
            {
                if (a.Length > 0)
                {
                    if (a.Length < num) num = a.Length;

                    Console.WriteLine($"\nХудшие ученики ({num})");

                    Student.SortMiddle(ref a);

                    double best = a[num - 1].Middle;    // средний балл лучшего из худших  
                                        
                    for (int i = 0; i < a.Length && a[i].Middle <= best; i++)
                    {
                        Console.WriteLine(a[i].ToString());
                    }
                    
                }
            }

            public static void Print(Student[] a)
            {
                foreach (Student st in a)
                {
                    Console.WriteLine(st.ToString());
                }
            }
            
        }

        partial class Program
        {

            static void Task4()
            {
                TaskTitle("Задание №4 - ЕГЭ");
                
                //Student st = new Student("Иванов Петр 4 5 3");
                //Console.WriteLine(st.ToString());

                Student[] students = Student.ReadFile(@"students.txt");               

                Student.Print(students);

                Student.PrintAverage(students, 3);

                TaskTitle("Задание №4 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
