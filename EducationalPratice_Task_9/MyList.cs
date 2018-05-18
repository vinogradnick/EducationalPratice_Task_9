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
        /// <summary>
        /// Информационное поле
        /// </summary>
        public int Data;
        /// <summary>
        /// Адрес на следующий элемент списка
        /// </summary>
        public MyList Next;

        private static int _counter;
        private static int _capacity;
        public int Capacity
        {
            get => _capacity;
            set {if(value > 0) _capacity = value;}
        }

        public static int Count => _counter;//Количество элементов в списке
        public MyList(int _data)
        {
            Data = _data;
            Next = null;
        }
        public MyList()
        {
            Data = 0;
            Next = null;
        }
        
       
        /// <summary>
        /// Создание списка 
        /// </summary>
        /// <param name="array">числа для ввода</param>
        /// <returns>Однонаправленный список</returns>
        static MyList MakeList(int[] array)
        {
            int data = array[0];//1 Головной элемент списка
            MyList start = MakePoint(data);//Задание начала списка

            for (int i = 1; i < array.Length; i++)
            {
                data = array[i];
                MyList point = MakePoint(data);//Создание элемента списка
                start.Next = point;//Задание ссылки на следующий элемент списка
                start = point;
            }
            return start;
        }

        /// <summary>
        /// Рекурсивное удаление элементов
        /// </summary>
        /// <param name="list"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static void  RecurentRemove(int element,ref MyList removeList)
        {
            MyList tempList = removeList;
            if (tempList != null)
            {
                if (tempList.Next.Data == element)
                {
                    tempList = tempList.Next.Next;
                    return tempList;
                }
                else
                {
                    RecurentRemove(element, ref tempList.Next);
                }
            }
            else
                return;
        }
        /// <summary>
        /// Рекурентное создание списка
        /// </summary>
        /// <param name="list">Список для заполнения</param>
        /// <param name="data">Информационное поле</param>
        /// <param name="size">Размер списка</param>
        /// <param name="counter">Счетчик списка</param>
        /// <returns></returns>
        public static void RecurrentCreate(int size,ref MyList list)
        {
            
            if (size != _counter)
            {
                _counter++; //Увелечение счетчика
                Console.Write("Введите значение для элемнента списка " + _counter + " |:=");
                MyList point = MakePoint(InputValidator.InputPositive());
                list = point;
                RecurrentCreate(size,ref list.Next);
            }
            else
                return;
        }

       
        public static void Print(MyList list)
        {
            while (list !=null)
            {
                Console.Write(list.Data+" ");
                list = list.Next;
            }
        }

        /// <summary>
        /// Создание элемента списка
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MyList MakePoint(int data)
        {
            MyList list = new MyList(data);
            return list;
        }

    }
}
