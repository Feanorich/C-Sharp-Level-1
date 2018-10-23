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

    namespace Lesson5
    {

        partial class Program
        {
            static void Menu()
            {

                int end = 0;
                while (end == 0)
                {
                    Print("");
                    Print("1 - Задание №1 - Проверка логина");
                    Print("2 - Задание №2 - класс message");
                    Print("3 - Задание №3 - Перестановки");
                    Print("4 - Задание №4 - ЕГЭ");                    
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
                NortonStyle("Урок №5. Автор: Прозрителев Александр");

                Print("Студент: Прозрителев Александр");
                Print("Домашнее задание к уроку №5");               

                Menu();

                Pause();
            }

        }
    }
}
