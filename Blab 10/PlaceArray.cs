using System;
using System.Collections.Generic;
using System.Text;

namespace Blab_10
{
    class PlaceArray
    {
        public Place[] Arr;
        public int Count;

        // Конструктор класса без параметров
        public PlaceArray()
        {
            Arr = null;
            Count = 0;
        }

        // Конструктор класса с параметрами
        public PlaceArray(int size)
        {
            Arr = new Place[size];
            Count = size;
        }

        // Индексация к элементу массива
        public Place this[int index]
        {
            get => Arr[index];
            set => Arr[index] = value;
        }

        // Ввод размера массива
        public static int InputSize()
        {
            int number;
            Console.WriteLine("Введите рамер массива:");
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 100)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели размер массива. Повторите ввод.");
            }

            return number;
        }

        // Вывод всей инфорамции о персонах, информация о которых хранится в PersonArray
        public void Show()
        {
            Console.WriteLine("Места:\n");

            for (int i = 0; i < Count; i++)
            {
                this[i].Show();
                Console.WriteLine();
            }
        }

        // Рандомная генерация массива
        public void RandomGeneration(int size)
        {
            Random random = new Random();
            Place [] place = new Place[size];
            for (int i = 0; i < size; i++)
            {
               place[i] = random.Next(1, 3) switch
                {
                    1 => new Region(),
                    2 => new City(),
                    3 => new Megapolis(),
                    _ => place[i]
                };

                place[i].RandomCreate();
            }

            Arr = place;
            Count = size;
        }

        // Сортировка массива по площади
        public void Sort()
        {
            Array.Sort(Arr, new SortByName());
        }

        // Поиск элемента массива по заданной площади
        public int Search(double square)
        {
            try
            {
                return Array.BinarySearch(Arr, square, new SearchBySquare());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // Поиск элемента массива по заданному названию оюъекта
        public int Search(string name)
        {
            try
            {
                return Array.BinarySearch(Arr, name, new SearchByName());
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }   
}
