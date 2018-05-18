using System;
using Validator;

namespace Task_9
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер коллекции");

            MyList list = new MyList(){Capacity=InputValidator.InputPositive()};
            
            MyList.RecurrentCreate(list.Capacity, ref list);
            MyList.Print(list);
            Console.WriteLine("Введите элемент для удаления");
            MyList.RecurentRemove(InputValidator.InputPositive(),ref list);
            MyList.Print(list);
            Console.ReadKey();
        }
    }
}
