using System;
using Validator;

namespace Task_9
{
    /*
     * 14.
     * Напишите рекурсивный метод создания циклического списка,
     * в информационные поля элементов которого последовательно заносятся номера с 1 до N (N водится с клавиатуры).
     * Первый включенный в список элемент, имеющий номер 1, оказывается в голове списка (первым).
     * Разработайте рекурсивные методы поиска и удаления элементов списка.
     */
    class MyList
    {
        public Point First;//первый элемент списка
        public Point Last;//последний элемент списка
        private int count=1;//Количество элементов в списке
        public int Size { get; set; }
        private int _size;
        public MyList(int size)
        {
            First = null;
            Last = null;
            _size = size;
        }

        public  Point RecurrentCreate( Point Element)
        {
            count++;

            if (_size != count)
            {
              
                if (First == null)
                {

                    First = Element;
                    Console.Write($"Введите {count}-е число :");
                    int data = Input.Int32();
                    First.Next = RecurrentCreate(new Point(data, null));
                }
                else
                {
                    Console.Write($"Введите {count}-е число :");
                    int data = Input.Int32();
                    Element.Next = RecurrentCreate(new Point(data, null));
                }
            }
            else
            {
                Console.Write($"Введите {count}-е число :");
                int data = Input.Int32();
                Last = new Point(data,First);
                Element.Next = Last;
                return Element;
            }
            return Element;

        }
        /// <summary>
        /// Найти элемент списка с заданым значением
        /// </summary>
        /// <param name="value">Заданое значение</param>
        public void FindElement(int value)
        {
            if (First.Data == value)
            {
               Console.WriteLine(First.Data);
            }
            else
            {
                Point element = RecurrentSearch(First,value);

            }
        }
        /// <summary>
        /// Рекурентный поиска элемента в списке
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Point RecurrentSearch(Point element, int value)
        {
            if (element.Next.Data == value)
            {
                Console.WriteLine("Элемент найден и принадлежит списку");
                return element;
            }
            if (element.Next.Data == Last.Data)
            {
                Console.WriteLine("Элемент списка не найден");
                return element;
            }
            else
                return RecurrentSearch(element.Next, value);
        }
        /// <summary>
        /// Удаление элемента в списке
        /// </summary>
        /// <param name="value">элемент для поиска</param>
        /// <returns></returns>
        public Point Remove(int value)
        {
            if (First.Data == value)
            {
                First = First.Next;
                Last.Next = First;
                return First;
            }
            else
            {
                Point element = RecurrentRemove(First, value);
                return element;
            }

        }
        /// <summary>
        /// Рекурсивное удаление элементов из списка
        /// </summary>
        /// <param name="element">Первый элемент списка</param>
        /// <param name="value">Значение элемента в списке</param>
        /// <returns></returns>
        public Point RecurrentRemove(Point element, int value)
        {
            if (element.Next.Data == value)
            {
                element.Next = element.Next.Next;
                return element;
            }

            if (element.Next.Data == Last.Data)
            {
                Console.WriteLine("Элемент списка не найден");
                return element;
            }
            else
                return RecurrentRemove(element.Next, value);
        }
        /// <summary>
        /// Печать элементов списка на экран
        /// </summary>
        public void Print()
        {
            Point current = First;
            Console.Write(current.Data+" ");
            current = First.Next;
            while (current != First)
            {
                Console.Write(current.Data+" ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    public class Point
    {
        public int Data;
        public Point Next;
        public Point(int data)
        {
            Data = data;
        }

        public Point(int data, Point next)
        {
            Data = data;
            Next = next;
        }
    }

    public static class Input
    {
        /// <summary>
        /// Ввод целого числа
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Int32()
        {
            int res;
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out res);
                ok = res > 0;
                if (!ok)
                    Console.WriteLine("Вы ввели неправильное число, повторите попытку \n Введите число: ");
            } while (!ok);
            return res;
        }
    }

}
