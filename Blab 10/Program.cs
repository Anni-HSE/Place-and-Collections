using System;
using System.Collections.Generic;

namespace Blab_10
{
    public class Program
    {
        // Функция ввода номера части лабораторной работы
        private static int InputMode()
        {
            int number;
            Console.WriteLine("Введите часть (1-3) лабораторной работы (0 - выход из программы):");
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || number > 3)
            {
                Console.WriteLine("Ошибка. Вы неверно ввели часть лабораторной работы");
            }

            return number;
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

        static void Main()
        {
            PlaceArray placeArray;
            int mode = InputMode();
            while (mode != 0)
            {
                switch (mode)
                {
                    case 1:
                        {
                            placeArray = new PlaceArray(PlaceArray.InputSize());
                            for (int i = 0; i < placeArray.Count; i++)
                            {
                                int type = InputClass();
                                switch (type)
                                {
                                    case 1:
                                        {
                                            Region region = new Region();
                                            placeArray[i] = region;
                                            placeArray[i].InputCreate();
                                        }
                                        break;
                                    case 2:
                                        {
                                            City city = new City();
                                            placeArray[i] = city;
                                            placeArray[i].InputCreate();
                                        }
                                        break;
                                    case 3:
                                        {
                                            Megapolis megapolis = new Megapolis();
                                            placeArray[i] = megapolis;
                                            placeArray[i].InputCreate();
                                        }
                                        break;
                                }
                            }

                            placeArray.Show();
                            break;
                        }
                    case 2:
                        {
                            placeArray = new PlaceArray(10);
                            placeArray.RandomGeneration(placeArray.Count);
                            placeArray.Show();

                            Console.WriteLine("Выберете запрос");
                            Console.WriteLine("1) Названия всех городов заданной области.");
                            Console.WriteLine("2) Количество жителей данного континента.");
                            Console.WriteLine("3) Суммарное количество жителей всех городов в области.");

                            int type;
                            while(!(int.TryParse(Console.ReadLine(), out type)) || type < 1 || type > 3)
                            {
                                Console.WriteLine("Ошибка. Вы неверно выбрали запрос. Повторите ввод");
                            }

                            switch (type)
                            {
                                case 1:
                                    {
                                        List<string> result = new List<string>();

                                        Console.WriteLine("Введите название области");
                                        string inquiry = Console.ReadLine();

                                        for (int i=0; i < placeArray.Count; i++)
                                        {                                         
                                            if (placeArray[i] is City)
                                            {
                                                City city = placeArray[i] as City;
                                                if(city.RegionName == inquiry)
                                                {
                                                    result.Add(city.PlaceName);
                                                }
                                                break;
                                            }
                                            if (placeArray[i] is Megapolis)
                                            {
                                                Megapolis city = placeArray[i] as Megapolis;
                                                if (city.RegionName == inquiry)
                                                {
                                                    result.Add(city.PlaceName);
                                                }
                                                break;
                                            }
                                        }

                                        if (result.Count != 0)
                                        {
                                            Console.WriteLine("Названия всех городов заданной области.");
                                            for (int i = 0; i < result.Count; i++)
                                            {
                                                Console.WriteLine(result[i]);
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("По вашему запросу ничего не найдено");
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        int result = 0;
                                        Console.WriteLine("Введите название континента");
                                        string inquiry = Console.ReadLine();

                                        for (int i = 0; i < placeArray.Count; i++)
                                        {
                                            if (placeArray[i] is City)
                                            {
                                                City city = placeArray[i] as City;
                                                if (city.Continent == inquiry)
                                                {
                                                    result += city.PopulationSize;
                                                }
                                            }
                                            else if (placeArray[i] is Megapolis)
                                            {
                                                Megapolis city = placeArray[i] as Megapolis;
                                                if (city.Continent == inquiry)
                                                {
                                                    result += city.PopulationSize;
                                                }
                                            }
                                            else if (placeArray[i] is Region)
                                            {
                                                Region city = placeArray[i] as Region;
                                                if (city.Continent == inquiry)
                                                {
                                                    result += city.PopulationSize;
                                                }
                                            }
                                        }                                  

                                        if (result != 0)
                                        {
                                            Console.WriteLine($"Количество жителей данного континента - {result}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("По вашему запросу ничего не найдено");
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        int result = 0;
                                        Console.WriteLine("Введите название области");
                                        string inquiry = Console.ReadLine();

                                        for (int i = 0; i < placeArray.Count; i++)
                                        {
                                            if (placeArray[i] is City)
                                            {
                                                City city = placeArray[i] as City;
                                                if (city.RegionName == inquiry)
                                                {
                                                    result += city.PopulationSize;
                                                }
                                                break;
                                            }
                                            if (placeArray[i] is Megapolis)
                                            {
                                                Megapolis city = placeArray[i] as Megapolis;
                                                if (city.RegionName == inquiry)
                                                {
                                                    result += city.PopulationSize;
                                                }
                                                break;
                                            }
                                        }

                                        if (result != 0)
                                        {
                                            Console.WriteLine($"Суммарное количество жителей всех городов в области - {result}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("По вашему запросу ничего не найдено");
                                        }
                                    }
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            Random random = new Random();
                            int size = random.Next(3, 9);
                            // 1.Составить иерархию классов в соответствии с вариантом. Иерархия должна содержать хотя бы один интерфейс и хотя бы один абстрактный класс.
                            Console.WriteLine("Иерархия классов:");
                            Console.WriteLine("Place - абстрактный класс, является 'родителем' остальных классов.");
                            Console.WriteLine("City, Megapolis, Region - классы, наследующие методы от Place.");

                            //2.Создать массив интерфейсных элементов и поместить в него экземпляры различных классов иерархии.
                            placeArray = new PlaceArray(size);
                            placeArray.RandomGeneration(size);
                            placeArray.Show();
                            //3.Реализовать сортировку элементов массива, используя стандартные интерфейсы и методы класса Array.
                            placeArray.Sort();
                            Console.WriteLine("Сортировка прошла успешно.");
                            placeArray.Show();
                            //4.Реализовать поиск элемента в массиве, используя стандартные интерфейсы и методы класса Array.
                            int index = placeArray.Search(1718000);
                            Console.WriteLine(index > -1
                                ? $"Искомая место находится на позиции {index + 1}"
                                : "Место с заданными параметрами найдена не была!");
                            index = placeArray.Search("Штат Аляска");
                            Console.WriteLine(index > -1
                                ? $"Искомая место находится на позиции {index + 1}"
                                : "Место с заданными параметрами найдена не была!");
                            //5.Реализовать в одном из классов метод клонирования объектов.Показать клонирование объектов.
                            Region region = new Region();
                            region.RandomCreate();
                            Region newRegion = region.ShallowCopy();
                            region.Show();
                            newRegion.Show();
                            break;
                        }
                }
                mode = InputMode();              
            }
        }
    }
}
