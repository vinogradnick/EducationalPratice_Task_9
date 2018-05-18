using System;

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

        private static int Count { get; set; }//Количество элементов в списке
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
        /// <returns></returns>
        public static MyList RecurentRemove(MyList pred, MyList current, int head, int query)
        {
            if (current != null || current.Data != head)
            {
                if (current.Data == query)
                {
                    pred.Next = current.Next;
                    return pred;
                }
                else
                {
                    pred.Next = current;
                    current = RecurentRemove(pred, current.Next, head, query);
                }
            }
            return pred;
        }
        /// <summary>
        /// Рекурентное создание списка
        /// </summary>
        /// <param name="list">Список для заполнения</param>
        /// <param name="data">Информационное поле</param>
        /// <param name="size">Размер списка</param>
        /// <param name="counter">Счетчик списка</param>
        /// <returns></returns>
        public static MyList RecurrentCreate(MyList list, int data, int size, ref int counter)
        {
            if (size != counter)
            {
                counter++;//Увелечение счетчика
                Count = counter;//Добавление в счет элементов списка
                MyList point = MakePoint(data);
                list.Next = point;
                list = point;
                list.Next = RecurrentCreate(list, int.Parse(Console.ReadLine()), size, ref counter);//Переход к следующему элементу списка
                return list;
            }
            else
                return list;
        }

        public void Print(MyList list)
        {
            int counter = 0;
            if (list != null)
            {
                while (list != null && Count != counter)
                {
                    counter++;
                    Console.WriteLine(list.Data + " ");
                    list = list.Next;
                }
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
