using Blab_10;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab_11
{
    class Program
    {
        // Функция печати основного меню
        static string MainMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1) Работа с коллекцией ArrayList");
            Console.WriteLine("2) Работа с обощенной коллеккцией Dictionary");
            Console.WriteLine("3) Работа с обощенной разработайнной коллеккцией MyList");

            return "";
        }

        // Функция печати меню 1 и 2 частей лабы
        static string Chapter12Menu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1) Добавить в колекцию объект");
            Console.WriteLine("2) Удалить из коллекции объект");
            Console.WriteLine("3) Работа с запросами");
            Console.WriteLine("4) Печать элементов коллекции");
            Console.WriteLine("5) Клонирование коллекции");
            Console.WriteLine("6) Сортировка коллекции");
            Console.WriteLine("7) поиск объекта коллекции");

            return "";
        }

        // Функция печати меню 3 частей лабы
        static string Chapter3Menu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1) Добавить в колекцию объект");
            Console.WriteLine("2) Удалить из коллекции объект");
            Console.WriteLine("3) Поиск");
            Console.WriteLine("4) Печать коллекции");

            return "";
        }

        // Функция печати меню запросов
        static string InquiryMenu()
        {
            Console.WriteLine("Запросы:");
            Console.WriteLine("1) Кол-во объектов типа Region");
            Console.WriteLine("2) Печать элементов типа City");
            Console.WriteLine("3) Кол-во объектов типа Megapolis");

            return "";
        }

        // Функция печати меню запросов
        static string CreateMenu()
        {
            Console.WriteLine("1) Ручной ввод ");
            Console.WriteLine("2) Случайная генерация");

            return "";
        }

        // Функция ввода номера задания
        static int InputMode(string text, string textFunction, int countMode)
        {
            string menu = textFunction;
            Console.WriteLine("Введите " + text + ". 0 - выход из режима/программы");
            int number;
            while (!(int.TryParse(Console.ReadLine(), out number) || number < 0 || number > countMode))
            {
                Console.WriteLine("Ошибка! Вы не верно ввели " + text);
            }
            return number;
        }

        // Функция ввода номера типа Place
        static int InputClass()
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

        static void SearchTestCollections(TestCollections test)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan time = new TimeSpan();
            bool check = true;

            // Поиск первого элемента
            stopwatch.Start();
            check = test.RegionString.ContainsValue(test.Regions[0]);
            stopwatch.Stop();
            time = stopwatch.Elapsed;

            if (check)
            {
                Console.WriteLine("Элемент коллекции найден. Его позиция в коллекции: 1. Время запроса: " + time + " тиков");
            }
            else
            {
                Console.WriteLine("Элемент коллекции не найден. Время запроса: " + time + " тиков");
            }

            test.Regions[0].Show();

            // Поиск центрального элемента
            stopwatch.Start();
            check = test.RegionString.ContainsValue(test.Regions[test.Size / 2]);
            stopwatch.Stop();
            time = stopwatch.Elapsed;

            if (check)
            {
                Console.WriteLine($"Элемент коллекции найден. Его позиция в коллекции: {test.Size / 2 + 1}. Время запроса: " + time + " тиков");
            }
            else
            {
                Console.WriteLine("Элемент коллекции не найден. Время запроса: " + time + " тиков");
            }

            test.Regions[test.Size / 2].Show();

            // Поиск последнего элемента
            stopwatch.Start();
            check = test.RegionString.ContainsValue(test.Regions[test.Size - 1]);
            stopwatch.Stop();
            time = stopwatch.Elapsed;

            if (check)
            {
                Console.WriteLine($"Элемент коллекции найден. Его позиция в коллекции: {test.Size}. Время запроса: " + time + " тиков");
            }
            else
            {
                Console.WriteLine("Элемент коллекции не найден. Время запроса: " + time + " тиков");
            }

            test.Regions[test.Size - 1].Show();

            // Поиск несуществующего элемента
            stopwatch.Start();
            Region region = new Region("Евразия", "Россия", "АОЫВАОЫ", 2323, 234234);
            check = test.RegionString.ContainsValue(region);
            stopwatch.Stop();
            time = stopwatch.Elapsed;

            Console.WriteLine("Элемент коллекции не найден. Время запроса: " + time + " тиков");
            region.Show();
        }

        static void Main(string[] args)
        {
            ArrayList placeList = new ArrayList();
            Dictionary<string, Place> placeDictionary = new Dictionary<string, Place>();
            TestCollections test = new TestCollections();
            Random random = new Random();

            int mode = InputMode("часть лабраторной работы", MainMenu(), 3);

            while(mode != 0)
            {
                int type;
                switch (mode)
                {
                    case 1:
                        {
                            type = InputMode("номер задания", Chapter12Menu(), 7);
                            while (type != 0)
                            {
                                switch (type)
                                {
                                    case 1:
                                        {
                                            int createType = InputMode("тип ввода", CreateMenu(), 2);

                                            switch (createType)
                                            {
                                                case 1:
                                                    {
                                                        int placeType = InputClass();
                                                        switch (placeType)
                                                        {
                                                            case 1:
                                                                {
                                                                    Region region = new Region();
                                                                    region.InputCreate();
                                                                    placeList.Add(region);
                                                                }
                                                                break;
                                                            case 2:
                                                                {
                                                                    City city = new City();
                                                                    city.InputCreate();
                                                                    placeList.Add(city);
                                                                }
                                                                break;
                                                            case 3:
                                                                {
                                                                    Megapolis megapolis = new Megapolis();
                                                                    megapolis.InputCreate();
                                                                    placeList.Add(megapolis);
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        int placeType = random.Next(1, 3);
                                                        switch (placeType)
                                                        {
                                                            case 1:
                                                                {
                                                                    Region region = new Region();
                                                                    region.RandomCreate();
                                                                    placeList.Add(region);
                                                                }
                                                                break;
                                                            case 2:
                                                                {
                                                                    City city = new City();
                                                                    city.RandomCreate();
                                                                    placeList.Add(city);
                                                                }
                                                                break;
                                                            case 3:
                                                                {
                                                                    Megapolis megapolis = new Megapolis();
                                                                    megapolis.RandomCreate();
                                                                    placeList.Add(megapolis);
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }                                            
                                        }
                                        break;
                                    case 2:
                                        {
                                            Console.WriteLine("Введите имя объекта, которого хотите удалить");
                                            string placeName = Console.ReadLine();
                                            bool end = false;
                                            for(int i=0; i < placeList.Count && !end; i++)
                                            {
                                                Place place = placeList[i] as Place;
                                                if (place.PlaceName == placeName)
                                                {
                                                    end = true;
                                                    placeList.Remove(place);
                                                    Console.WriteLine("Объект по вашему запросу был удален");
                                                }
                                            }
                                            if (!end)
                                            {
                                                Console.WriteLine("Удаление не возможно. В коллекции нет объекта, удовлетворяющему вашему запросу");
                                            }
                                        } 
                                        break;
                                    case 3:
                                        {
                                            int inquiry = InputMode("номер запроса", InquiryMenu(), 3);
                                            switch (inquiry)
                                            {
                                                case 1:
                                                    {
                                                        int quantity = 0;
                                                        for (int i = 0; i < placeList.Count; i++)
                                                        {
                                                            if (placeList[i] is Region)
                                                            {
                                                                quantity++;
                                                            }
                                                        }
                                                        Console.WriteLine("Кол-во объектов типа REgion: " + quantity);
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        List<City> cities = new List<City>();
                                                        for (int i = 0; i < placeList.Count; i++)
                                                        {
                                                            if (placeList[i] is City)
                                                            {
                                                                cities.Add(placeList[i] as City);
                                                            }
                                                        }
                                                        if (cities.Count != 0)
                                                        {
                                                            foreach (City city in cities)
                                                            {
                                                                city.Show();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("В коллекции нет объектов типа City");
                                                        }
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        int quantity = 0;
                                                        for (int i = 0; i < placeList.Count; i++)
                                                        {
                                                            if (placeList[i] is Megapolis)
                                                            {
                                                                quantity++;
                                                            }
                                                        }
                                                        Console.WriteLine("Кол-во объектов типа Megapolis: " + quantity);
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        {
                                            Console.WriteLine("Элементы коллекции");
                                            Place[] placies = new Place[placeList.Count];
                                            placeList.CopyTo(placies);
                                            foreach (Place place in placies)
                                            {
                                                place.Show();
                                            }
                                        }
                                        break;
                                    case 5:
                                        {
                                            ArrayList placeCloneList = (ArrayList) placeList.Clone();
                                            Console.WriteLine("Сколинируемая коллекция");
                                            Place[] placies = null;
                                            placeCloneList.CopyTo(placies);
                                            foreach (Place place in placies)
                                            {
                                                place.Show();
                                            }
                                        }
                                        break;
                                    case 6:
                                        {
                                            placeList.Sort(new SortByName());
                                            Console.WriteLine("Коллекция отсортирована по названию места в алфовитном порядке");
                                        }
                                        break;
                                    case 7:
                                        {
                                            Console.WriteLine("Введите названия места, чтобы найти элемент с соответствующим названием");
                                            string search = Console.ReadLine();
                                            int pos = placeList.BinarySearch(search, new SearchByName());
                                            if (pos != -1)
                                            {                                               
                                                Console.WriteLine($"Объекст найден. Его позиция в коллекции: {pos + 1}");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Объекст не найден.");
                                            }
                                        }
                                        break;
                                }
                                type = InputMode("номер задания", Chapter12Menu(), 7);
                            }
                        }
                        break;
                    case 2:
                        {
                            type = InputMode("номер задания", Chapter12Menu(), 7);
                            while (type != 0)
                            {
                                switch (type)
                                {
                                    case 1:
                                        {
                                            int createType = InputMode("тип ввода", CreateMenu(), 2);

                                            switch (createType)
                                            {
                                                case 1:
                                                    {
                                                        int placeType = InputClass();
                                                        switch (placeType)
                                                        {
                                                            case 1:
                                                                {
                                                                    Region region = new Region();
                                                                    region.InputCreate();
                                                                    placeDictionary.Add(region.PlaceName, region);
                                                                }
                                                                break;
                                                            case 2:
                                                                {
                                                                    City city = new City();
                                                                    city.InputCreate();
                                                                    placeDictionary.Add(city.PlaceName, city);
                                                                }
                                                                break;
                                                            case 3:
                                                                {
                                                                    Megapolis megapolis = new Megapolis();
                                                                    megapolis.InputCreate();
                                                                    placeDictionary.Add(megapolis.PlaceName, megapolis);
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        int placeType = random.Next(1, 3);
                                                        switch (placeType)
                                                        {
                                                            case 1:
                                                                {
                                                                    Region region = new Region();
                                                                    region.RandomCreate();
                                                                    placeDictionary.Add(region.PlaceName, region);
                                                                }
                                                                break;
                                                            case 2:
                                                                {
                                                                    City city = new City();
                                                                    city.RandomCreate();
                                                                    placeDictionary.Add(city.PlaceName, city);
                                                                }
                                                                break;
                                                            case 3:
                                                                {
                                                                    Megapolis megapolis = new Megapolis();
                                                                    megapolis.RandomCreate();
                                                                    placeDictionary.Add(megapolis.PlaceName, megapolis);
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    break;
                                            }

                                            Console.WriteLine("Объект добавлен");
                                        }
                                        break;
                                    case 2:
                                        {
                                            Console.WriteLine("Введите имя объекта, которого хотите удалить");
                                            string placeName = Console.ReadLine();
                                            bool end = false;
                                            if (placeDictionary.ContainsKey(placeName))
                                            {
                                                placeDictionary.Remove(placeName);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Удаление не возможно. В коллекции нет объекта, удовлетворяющему вашему запросу");
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            int inquiry = InputMode("номер запроса", InquiryMenu(), 3);
                                            switch (inquiry)
                                            {
                                                case 1:
                                                    {
                                                        int quantity = 0;
                                                        foreach (string key in placeDictionary.Keys)
                                                        {
                                                            if (placeDictionary[key] is Region)
                                                            {
                                                                quantity++;
                                                            }
                                                        }
                                                        Console.WriteLine("Кол-во объектов типа Region: " + quantity);
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        List<City> cities = new List<City>();
                                                        foreach (string key in placeDictionary.Keys)
                                                        {
                                                            if (placeDictionary[key] is City)
                                                            {
                                                                City city = placeDictionary[key] as City;
                                                                cities.Add(city);
                                                            }
                                                        }
                                                        
                                                        if (cities.Count != 0)
                                                        {
                                                            foreach (City city in cities)
                                                            {
                                                                city.Show();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("В коллекции нет объектов типа City");
                                                        }
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        int quantity = 0;
                                                        foreach (string key in placeDictionary.Keys)
                                                        {
                                                            if (placeDictionary[key] is Megapolis)
                                                            {
                                                                quantity++;
                                                            }
                                                        }
                                                        Console.WriteLine("Кол-во объектов типа Megapolis: " + quantity);
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 4:
                                        {
                                            Console.WriteLine("Элементы коллекции");
                                            foreach (string key in placeDictionary.Keys)
                                            {
                                                placeDictionary[key].Show();
                                            }
                                        }
                                        break;
                                    case 5:
                                        {
                                            Dictionary<string, Place> copy = new Dictionary<string, Place>(placeDictionary);
                                            Console.WriteLine("Сколинируемая коллекция");
                                            foreach (string key in copy.Keys)
                                            {
                                                copy[key].Show();
                                            }
                                        }
                                        break;
                                    case 6:
                                        {
                                            var list = placeDictionary.Keys.ToList();
                                            list.Sort();
                                            Dictionary<string, Place> tmp = new Dictionary<string, Place>();

                                            foreach (var key in list)
                                            {
                                                tmp.Add(key, placeDictionary[key]);
                                            }

                                            placeDictionary = tmp;
                                            Console.WriteLine("Коллекция отсортирована по названию места в алфовитном порядке");
                                            
                                        }
                                        break;
                                    case 7:
                                        {
                                            Console.WriteLine("Введите названия места, чтобы найти элемент с соответствующим названием");
                                            string search = Console.ReadLine();
                                            var list = placeDictionary.Keys.ToList();
                                            list.Sort();
                                            if (list.IndexOf(search) != 0)
                                            {
                                                Console.WriteLine("Объект найден");
                                                placeDictionary[search].Show();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Объект не найден");
                                            }
                                        }
                                        break;
                                }
                                type = InputMode("номер задания", Chapter12Menu(), 7);
                            }
                        }
                        break;
                    case 3:
                        {
                            type = InputMode("номер задания", Chapter3Menu(), 4);
                            while (type != 0)
                            {
                                switch (type)
                                {
                                    case 1:
                                        {
                                            int createType = InputMode("тип ввода", CreateMenu(), 2);

                                            switch (createType)
                                            {
                                                case 1:
                                                    {
                                                      
                                                        Region region = new Region();
                                                        region.InputCreate();
                                                        test.Add(region);

                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        
                                                        Region region = new Region();
                                                        region.RandomCreate();
                                                        test.Add(region);
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        {
                                            Console.WriteLine("Введите имя объекта, которого хотите удалить");
                                            string placeName = Console.ReadLine();
                                            if (test.RegionString.ContainsKey(placeName))
                                            {
                                                test.Remove(test.RegionString[placeName]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Удаление не возможно. В коллекции нет объекта, удовлетворяющему вашему запросу");
                                            }
                                        }
                                        break;
                                    case 3:
                                        {
                                            if (test.Size >= 4)
                                            {
                                                SearchTestCollections(test);
                                            }
                                            else
                                            {
                                                test = new TestCollections();

                                                for(int i = 0; i < random.Next(1,10); i++)
                                                {
                                                    Region region = new Region();
                                                    region.RandomCreate();

                                                    test.Add(region);
                                                }

                                                SearchTestCollections(test);
                                            }

                                        }
                                        break;
                                    case 4:
                                        {
                                            Console.WriteLine("Выберете какую именно коллекцию хотите распечатать из объекта типа TestCollections");
                                            Console.WriteLine("1) Regions\n2) Regions names\n3) Region Place\n4) Region String");
                                            int print;
                                            while(!(int.TryParse(Console.ReadLine(), out print)) || print < 1 || print > 4)
                                            {
                                                Console.WriteLine("Ошибка. Тип печати с таким номером не существует. Повторите ввод");
                                            }

                                            switch (print)
                                            {
                                                case 1:
                                                    {
                                                        test.PrintList(new List<Region>());
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        test.PrintList(new List<string>());
                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        test.PrintDictionary(new SortedDictionary<Place, Region>());
                                                    }
                                                    break;
                                                case 4:
                                                    {
                                                        test.PrintDictionary(new SortedDictionary<string, Region>());
                                                    }
                                                    break;
                                            }

                                        }
                                        break;

                                }
                                type = InputMode("номер задания", Chapter3Menu(), 4);
                            }
                        }
                        break;
                }
            }
        }
    }
}
