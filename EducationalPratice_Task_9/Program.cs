using System;

namespace Task_9
{
    class Program
    {
      
        static void Main(string[] args)
        {
            int data = 0;
            int counter = 0;
            MyList list = new MyList(data);
            list = MyList.RecurrentCreate(list,data,10,ref counter);//Рекурсивное создание списка
            list.Print(list);
            list = MyList.RecurentRemove(list, list.Next, list.Data, 10);
            list.Print(list);
            Console.ReadKey();
        }
    }
}
