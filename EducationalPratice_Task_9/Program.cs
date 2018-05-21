using System;
using Validator;

namespace Task_9
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.Write("Введите размер коллекции ");
            int size = Input.Int32();
            MyList list = new MyList(size);
            int data = Input.Int32();
            Point point = list.RecurrentCreate(new Point(data, null));
            list.Print();
            list.Remove(10);
            list.Print();
            Console.ReadLine();
        }
    }
}
