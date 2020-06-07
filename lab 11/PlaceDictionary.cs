using Blab_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_11
{
    public class PlaceDictionary
    {
        private protected Random random = new Random();
        private protected Dictionary<string, Place> map = new Dictionary<string, Place>();
        private protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Place this[string index]
        {
            get
            {             
                return map[index];
            }
            set
            {

                map[index] = value;
            }
        }

        public PlaceDictionary()
        {
            map = new Dictionary<string, Place>();
            count = 0;
        }

        public PlaceDictionary(int capacity)
        {
            map = new Dictionary<string, Place>(capacity);
            count = capacity;
        }

        public PlaceDictionary(Dictionary<string, Place> place)
        {
            map = place;
            count = place.Count;
        }

        public void Add(string key, Place value)
        {
            count++;
            map.Add(key, value);
        }

        public bool Remove(string key)
        {
            if (map.ContainsKey(key))
            {
                count--;
                map.Remove(key);
                return true;
            }

            return false;
        }

        public void KeyboardGeneretion(int size)
        {
            count = size;
            map = new Dictionary<string, Place>();
            for (int i = 0; i < size; i++)
            {
                int placeType = InputClass();
                switch (placeType)
                {
                    case 1:
                        {
                            Region region = new Region();
                            region.InputCreate();
                            map.Add(region.PlaceName, region);
                        }
                        break;
                    case 2:
                        {
                            City city = new City();
                            city.InputCreate();
                            map.Add(city.PlaceName, city);
                        }
                        break;

                    case 3:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.InputCreate();
                            map.Add(megapolis.PlaceName, megapolis);
                        }
                        break;

                }
            }
        }

        public void RandomGeneration(int size)
        {
            count = size;
            map = new Dictionary<string, Place>();

            for (int i = 0; i < size; i++)
            {
                int placeType = random.Next(1, 3);
                switch (placeType)
                {
                    case 1:
                        {
                            Region region = new Region();
                            region.InputCreate();
                            map.Add(region.PlaceName, region);
                        }
                        break;
                    case 2:
                        {
                            City city = new City();
                            city.InputCreate();
                            map.Add(city.PlaceName, city);
                        }
                        break;

                    case 3:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.InputCreate();
                            map.Add(megapolis.PlaceName, megapolis);
                        }
                        break;
                }
            }
        }

        public void Sort()
        {
            var list = map.Keys.ToList();
            list.Sort();
            Dictionary<string, Place> tmp = new Dictionary<string, Place>();

            foreach (var key in list)
            {
                tmp.Add(key, map[key]);
            }

            map = tmp;
            Console.WriteLine("Коллекция отсортирована по названию места в алфовитном порядке");
        }

        public void Search()
        {
            Console.WriteLine("Введите названия места, чтобы найти элемент с соответствующим названием");
            string search = Console.ReadLine();
            var list = map.Keys.ToList();
            list.Sort();
            if (list.IndexOf(search) != 0)
            {
                Console.WriteLine("Объект найден");
                map[search].Show();
            }
            else
            {
                Console.WriteLine("Объект не найден");
            }
        }

        public void CopyTo(PlaceDictionary place)
        {
            place.map = new Dictionary<string, Place>(map);
        }

        public string ToString()
        {
           
            foreach (string key in map.Keys)
            {
                map[key].Show();
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
