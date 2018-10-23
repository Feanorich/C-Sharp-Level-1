#region Описание задачи
/*Прозрителев Александр  
 *1. 
 * Создать программу, которая будет проверять корректность ввода логина. 
 * Корректным логином будет строка от 2 до 10 символов, содержащая только буквы 
 * латинского алфавита или цифры, при этом цифра не может быть первой: 
 * а) без использования регулярных выражений; 
 * б) **с использованием регулярных выражений. * 
 */
#endregion

using System;
using System.IO;
using System.Text.RegularExpressions;
using static Prozritelev.MyClass;

namespace Prozritelev
{

    namespace Lesson5
    {

        partial class Program
        {
            static bool CheckLogin(string s)
            {
                bool result = true;
                if (s.Length >= 2 && s.Length <= 10)
                {             

                    for (int i = 0; i < s.Length && result == true; i++)
                    {
                        if (!(s[i] >= 'a' && s[i] <= 'z') && !(s[i] >= 'A' && s[i] <= 'Z')
                            && !((s[i] >= '0' && s[i] <= '9') && i > 0))
                        {
                            result = false;
                        }

                    }
                }
                else result = false;
                return result;

            }

            static void Task1()
            {
                TaskTitle("Задание №1 - Проверка логина");
                bool result = true;
                do
                {
                    string s = Quest("Введите логин: ");
                    //Проверка через символы
                    result = CheckLogin(s);

                    //сделал в начале с массивом символов, а потом понял, что он лишний, 
                    //и можно прямо к строке обращаться

                    //result = true;
                    //if (s.Length >= 2 && s.Length <= 10)
                    //{
                    //    char[] b = s.ToCharArray();

                    //    for (int i = 0; i < b.Length; i++)
                    //    {
                    //        if (!(b[i] >= 'a' && b[i] <= 'z') && !(b[i] >= 'A' && b[i] <= 'Z')
                    //            && !((b[i] >= '0' && b[i] <= '9') && i > 0))
                    //        {
                    //            result = false;
                    //        }

                    //    }
                    //}
                    //else result = false;

                    Console.WriteLine($"а) Проверка по символам: {result}");

                    //Проверка через Regex
                    Regex myReg = new Regex(@"\b[A-Za-z]{1}[A-Za-z0-9]{1,9}\b");
                    Console.WriteLine($"б) Regex говорит: {myReg.IsMatch(s)}");

                } while (!result);


                TaskTitle("Задание №1 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
