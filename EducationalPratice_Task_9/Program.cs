using System;
using Validator;

namespace Task_9
{
    class Program
    {
        private static MyList list;
        private static Point MyPoint;
        static void Menu()
        {
            Console.WriteLine("Учебная практика/ Задание 9 ");
            MenuChoise();
        }

        static void ListMenu()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("[1]-Создание списка");
            Console.WriteLine("[2]-Печать списка");
            Console.WriteLine("[3]-Поиск элемента в списке");
            Console.WriteLine("[4]-Удаление элемента из списка");
            Console.WriteLine("[5]-Выход из программы");
            Console.Write("Выбирете элемент меню ");
        }
        static void MenuChoise()
        {
            ListMenu();
            switch (Console.ReadLine())
            {
                case "1"://Создание списка
                    Console.Write("Введите размер списка :");
                    int n = Input.Int32();
                    list = new MyList(n);
                    Console.Write("Введите 1 элемент списка :");
                    int data = Input.Int32();
                    try
                    {
                        MyPoint = list.RecurrentCreate(new Point(data, null));
                       list.Print();
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    MenuChoise();
                    break;
                case "2"://Печать списка
                    try
                    {
                        list.Print();
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    MenuChoise();
                    break;
                case "3"://Поиск элемента в списке
                    Console.Write("Введите элемент для поиска");
                    int number = Input.Int32();
                    try
                    {
                        list.FindElement(number);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    MenuChoise();
                    break;
                case "4"://Удаление элемента в списке
                    Console.Write("Введите элемент для удаления");
                    number = Input.Int32();
                    try
                    {
                        list.Remove(number);
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    MenuChoise();
                    break;
                case "5":
                    Environment.Exit(Environment.ExitCode);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы выбрали неверный элемент меню");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    MenuChoise();
                    break;
            }
        }
        static void Main(string[] args) => Menu();
    }
}
