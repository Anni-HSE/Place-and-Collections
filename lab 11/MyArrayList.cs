using Blab_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_11
{
    public class PlaceArrayList
    {
        private protected Random random = new Random();
        private protected ArrayList list = new ArrayList();
        private protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Place this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    Place place = list[index] as Place;
                    return place;
                }

                throw new Exception("Идекс за пределом коллекции");
            }
            set
            {

                if (index >= 0 && index < Count)
                {
                    list[index] = value;
                }

                throw new Exception("Идекс за пределом коллекции");
            }
        }

        public PlaceArrayList()
        {
            list = new ArrayList();
            count = 0;
        }

        public PlaceArrayList(int capacity)
        {
            list = new ArrayList(capacity);
            count = capacity;
        }

        public PlaceArrayList(ArrayList place)
        {
            list = place;
            count = place.Count;
        }

        public int Add(Place place)
        {
            count++;
            return list.Add(place);
        }

        public bool Remove(Place place)
        {
            if (list.IndexOf(place) != -1)
            {
                count--;
                list.Remove(place);
                return true;
            }

            return false;
        }

        public void KeyboardGeneretion(int size)
        {
            count = size;
            list = new ArrayList(size);
            for(int i = 0; i < size; i++)
            {
                int placeType = InputClass();
                switch (placeType)
                {
                    case 1:
                        {
                            Region region = new Region();
                            region.InputCreate();
                            list[i] = region;
                        }
                        break;
                    case 2:
                        {
                            City city = new City();
                            city.InputCreate();
                            list[i] = city;
                        }
                        break;
                        
                    case 3:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.InputCreate();
                            list[i] = megapolis;
                        }
                        break;
                        
                }
            }
        }

        public void RandomGeneration(int size)
        {
            count = size;
            list = new ArrayList(size);

            for(int i = 0; i < size; i++)
            {
                int placeType = random.Next(1, 3);
                switch (placeType)
                {
                    case 1:
                        {
                            Region region = new Region();
                            region.RandomCreate();
                            list[i] = region;
                        }
                        break;
                    case 2:
                        {
                            City city = new City();
                            city.RandomCreate();
                            list[i] = city;
                        }
                        break;
                    case 3:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.RandomCreate();
                            list[i] = megapolis;
                        }
                        break;
                }
            }
        }

        public void Sort()
        {
            list.Sort(new SortByName());
        }

        public void Search()
        {
            Console.WriteLine("Введите названия места, чтобы найти элемент с соответствующим названием");
            string search = Console.ReadLine();
            int pos = list.BinarySearch(search, new SearchByName());
            if (pos != -1)
            {
                Console.WriteLine($"Объекст найден. Его позиция в коллекции: {pos + 1}");
            }
            else
            {
                Console.WriteLine($"Объекст не найден.");
            }
        }

        public void CopyTo(ArrayList newList)
        {
           newList = (ArrayList)list.Clone();
        }

        public string ToString()
        {
            Place[] placies = new Place[list.Count];
            list.CopyTo(placies);
            foreach (Place place in placies)
            {
                place.Show();
            }

            return "\n";
        }

        // Функция ввода номера типа Place
        private static int InputClass()
        {
            int number;
            Console.WriteLine("Выберите тип места, который хотите добавить:");
            Console.WriteLine("1) Регион\n2) Город\n3) Мегаполис");
            while (!(int.TryParse(Console.ReadLine(), out number)) || number < 1 || number > 3)
            {
                Console.WriteLine("Ошибка. Вы неверно выбрали тип места. Повторите ввод");
            }

            return number;
        }
    }
}
