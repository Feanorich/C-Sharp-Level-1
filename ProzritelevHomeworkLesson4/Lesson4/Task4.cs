#region Описание задачи
/*Прозрителев Александр 
 * 
 *4.Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. 
 * Создайте структуру Account, содержащую Login и Password.
 * 
 РЕАЛИЗАЦИЯ: ИМХО рациональней было бы использовать не массив а Dictionary (как в предыдущем задании)
 но массив так массив - справился и с ним.

 файл первой строчкой содержит количество аккаунтов, а потом логины и пароли разделенные |
 например:

2
sasha|1234
vasia|4321


 */
#endregion

using System;
using System.IO;
using static Prozritelev.MyClass;

namespace Prozritelev
{
    namespace Lesson4
    {
        struct Account
        {
            string login;
            string password;
            
            public string Login
            {
                get
                {
                    return login;
                }
                set
                {
                    login = value;
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                }
            }

            //сравнение логина и пароля с аккаунтом
            public bool Auth(string login, string password)
            {
                if (this.login == login && this.password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //сравнение логина и пароля с массивом аккаунтов
            public static bool Authorization(Account[] a, string login, string password)
            {
                foreach (Account ak in a)
                {
                    if (ak.Auth(login, password) == true)
                    {
                        return true;                        
                    }                    
                }

                return false;
            }
            
            //получаем массив аккаунтов из файла
            public static Account[] ReadFromFile(string filename)
            {                
                StreamReader sr = null;
                Account[] a = null;
                try
                {
                    sr = new StreamReader(filename);
                    int n = int.Parse(sr.ReadLine());
                    a = new Account[n];                    
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();                        
                        string[] acc = line.Split('|');

                        a[i].Login = acc[0];
                        a[i].Password = acc[1];
                        i++;
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);                    
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
                return a;
            }

            public override string ToString()
            {
                return $"Login: {login}\nPassword:{password}";
            }
        }

        partial class Program
        {

            static void Task4()
            {
                TaskTitle("Задание №4 - Авторизация (структура и файл)");

                string fileName = @"D:\temp\dataAcc.txt";
                Account[] acc = Account.ReadFromFile(fileName);

                bool success = false;

                if (acc != null)
                {
                    Print($"\n Загружено учетных записей: {acc.Length} ({fileName})\n");
                    if (acc.Length > 0)
                    {
                        int count = 0;
                        int all = 3;                        

                        do
                        {
                            count++;
                            string log = Quest("Введите логин: ");
                            string pass = Quest("Введите пароль: ");
                            success = Account.Authorization(acc, log, pass);
                            if (success == false)
                            {
                                if (all - count > 0)
                                {
                                    Print($"Неверный логин или пароль. Осталось попыток: {all - count}");
                                }
                            }

                        } while (count < 3 && success == false);
                    }
                } else
                {
                    Print("\n Не удалось загрузить список аккаунтов");
                }
                Print("");
                if (success == false)
                {
                    Print("\n Авторизация не удалась!");
                }
                else
                {
                    Print("\n Авторизация успешна!");
                }

                TaskTitle("Задание №4 завершено. Нажмиме любую клавишу.");
            }

        }
    }
}
