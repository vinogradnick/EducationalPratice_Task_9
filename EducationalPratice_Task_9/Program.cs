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
                case "1":
                    Console.WriteLine("Введите размер списка");
                    int n = Input.Int32();
                    list = new MyList(n);
                    Console.WriteLine("Введите 1 элемент списка");
                    int data = Input.Int32();
                    try
                    {
                        MyPoint = list.RecurrentCreate(new Point(data, null));
                       
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                    }

                    Console.ReadLine();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Вы выбрали неверный элемент меню");
                    break;
            }
        }
        static void Main(string[] args) => Menu();
    }
}
