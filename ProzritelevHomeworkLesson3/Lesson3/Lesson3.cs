#region 
/* Прозрителев Александр
 * 
 * 3.Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 * Написать программу, демонстрирующую все разработанные элементы класса.
* Добавить свойства типа int для доступа к числителю и знаменателю;
* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
* Добавить проверку, чтобы знаменатель не равнялся 0. 
* Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
*** Добавить упрощение дробей.
* 
* РЕАЛИЗОВАНО:
* 1) все, что в тексте задания
* 2) ввод числа с защитой от дурака (верхний метод в тексте вспомогательного класса MyClass.cs)
* 3) намеренно не сокращаю дроби сразу после ввода, чтобы видеть, что с чем взаимождействует,
* но сокращение результата арифметический действий работает нормально. 
 */
#endregion

using System;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson3
    {
        class Fraction
        {
            private int num, den;

            #region чтение/редактирование значения параметров
            public int Num
            {
                get
                {
                    return num;
                }
                set
                {
                    num = value;
                }
            }

            public int Den
            {
                get
                {
                    return den;
                }
                set
                {
                    if (value == 0)
                        throw new ArgumentOutOfRangeException("Знаменатель не должен быть равен 0");
                    else den = value;
                }
            }

            public double Dec   //десятичная дробь
            {
                get
                {
                    return (double) num / den;
                }
            }

            public void Set(int num, int den)
            {
                this.num = num;
                if (den == 0)
                    throw new ArgumentOutOfRangeException("Знаменатель не должен быть равен 0");
                else this.den = den;
            }
            #endregion

            #region варианты конструктора 
            public Fraction()   //создаем пустую дробь 
            {
                num = 0;
                den = 1;
            }

            public Fraction(int num, int den)   //создаем дробь с параметрами
            {
                this.num = num;
                if (den == 0)
                    throw new ArgumentOutOfRangeException("Знаменатель не должен быть равен 0");
                else this.den = den;
            }

            public Fraction(string name = "")   //введем дробь с клавы
            {
                num = InputInt($"{name} - введите числитель:");
                do
                {
                    den = InputInt($"{name} - введите знаменатель:");

                    if (den == 0)
                    {
                        Print("Знаменатель не может быть равен 0!");
                    }
                } while (den == 0);
                Print($"{name} {this.ToStr()}");
            }
            #endregion

            #region Арифметические действия с дробями
            //алгоритм действия в зависимости от символа 
            private static void Sym(ref Fraction R, Fraction A, Fraction B, string sym)
            {
                if (sym == "+")
                {
                    R.Set((A.num * B.den + B.num * A.den), (A.den * B.den));
                }
                else if (sym == "-")
                {
                    R.Set((A.num * B.den - B.num * A.den), (A.den * B.den));
                }
                else if (sym == "*")
                {
                    R.Set((A.num * B.num), (A.den * B.den));
                }
                else if (sym == "/")
                {
                    R.Set((A.num * B.den), (A.den * B.num));
                }
            }
            //статическим методом 
            public static Fraction Arithmetic(Fraction A, Fraction B, string sym)
            {
                Fraction R = new Fraction();
                Sym(ref R, A, B, sym);
                R.Simple();
                return R;
            }

            //не статическим методом (чтобы было веселее)
            public Fraction Math(Fraction B, string sym)
            {
                Fraction R = new Fraction();
                Sym(ref R, this, B, sym);
                R.Simple();
                return R;
            }
            #endregion            

            #region Сокращение дроби
            private static int NOD(int a, int b)    //наименьший общий делитель 
            {
                if (a < 0) a *= -1;
                if (b < 0) b *= -1;
                while (a != b)
                    if (a > b) a = a - b; else b = b - a;
                return a;
            }

            public void Simple()    //сокращение дроби
            {
                int a = NOD(this.num, this.den);
                if (a != 1)
                {
                    this.num /= a;
                    this.den /= a;
                }
            }
            #endregion

            //создадим строковое представление нашей дроби
            public string ToStr()
            {
                if (num % den == 0) 
                {
                    return $"[{num / den}]";    //схлопнем дробь в число
                }
                else
                {
                    #region можно выделять целую часть - забавно, но не наглядно.
                    //if (num > den)
                    //{
                    //    return $"[{num/den} + {num % den}/{den}]";
                    //} else
                    //{
                    //    return $"[{num}/{den}]";
                    //}
                    #endregion

                    return $"[{num}/{den}]";
                }
            }

        }

        partial class Program
        {

            static void Main()
            {
                NortonStyle("Урок №3. Автор: Прозрителев Александр");

                Print("Студент: Прозрителев Александр");
                Print("Домашнее задание к уроку №3");

                //тестовая дродь, для демонстрации, что все (что не задействовано далее) работает
                Fraction T = new Fraction();
                //зададим значения
                T.Num = 5;
                T.Den = 7;
                //запросим значения
                Print($"тестовая дробь: [{T.Num}/{T.Den}] ({T.Dec})");

                Fraction A = new Fraction("Дробь А");
                Fraction B = new Fraction("Дробь B");                

                int end = 0;
                while (end == 0)
                {
                    Print("");
                    Print("Какое действие произвести?");
                    Print("1 - Сложить");
                    Print("2 - Вычесть");
                    Print("3 - Умножить");
                    Print("4 - Разделить");
                    Print("0,Esc - Exit");
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Print("");
                            Console.WriteLine($"{A.ToStr()} + {B.ToStr()} = {A.Math(B, "+").ToStr()} ({A.Math(B, "+").Dec})");
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Print("");
                            Console.WriteLine($"{A.ToStr()} - {B.ToStr()} = {A.Math(B, "-").ToStr()} ({A.Math(B, "-").Dec})");
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Print("");
                            Console.WriteLine($"{A.ToStr()} * {B.ToStr()} = {A.Math(B, "*").ToStr()} ({A.Math(B, "*").Dec})");
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Print("");
                            Console.WriteLine($"{A.ToStr()} / {B.ToStr()} = {A.Math(B, "/").ToStr()} ({A.Math(B, "/").Dec})");
                            break;

                        case ConsoleKey.D0:
                        case ConsoleKey.Escape:
                            Print("Bye-bye");
                            end = 1;
                            return;
                        default:
                            Print("Wrong select!");
                            break;
                    }

                }

            }
        }
    }
}
