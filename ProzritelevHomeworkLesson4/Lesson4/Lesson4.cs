#region
/* Прозрителев Александр
 * 
 * Меню с выбором задач
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
            static void Menu()
            {

                int end = 0;
                while (end == 0)
                {
                    Print("");
                    Print("1 - Задание №1 - пары в массиве");
                    Print("2 - Задание №2 - пары в массиве (классом)");
                    Print("3 - Задание №3 - класс MyArray");
                    Print("4 - Задание №4 - Авторизация (структура и файл)");
                    Print("5 - Задание №5 - двухмерный массив");                    
                    Print("0,Esc - Exit");
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Task1();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Task2();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Task3();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Task4();
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Task5();
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

            static void Main()
            {
                NortonStyle("Урок №4. Автор: Прозрителев Александр");

                Print("Студент: Прозрителев Александр");
                Print("Домашнее задание к уроку №4");
                Menu();
            }

        }
    }
}
