using System;
using Validator;

namespace Task_9
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.Write("Введите размер коллекции ");

            MyList list = new MyList(){Capacity=InputValidator.InputPositive()};
            
            MyList.RecurrentCreate(list.Capacity, ref list);
            MyList.Print(list);
            
            Console.Write("\nВведите элемент для удаления := ");
            list =MyList.RecurentRemove(list,InputValidator.InputPositive());
            MyList.Print(list);
            Console.ReadKey();
        }
    }
}
