using System;
using System.Collections;
using System.Collections.Generic;

namespace Blab_10
{
    public class Place : IComparer, IComparable, IPlace
    {
        // Список существующих континентов
        private protected List<string> ContinentName = new List<string>()
        {
            "Евразия", "Северная Америка",
            "Южная Америка", "Африка", "Австралия", "Антарктида"
        };

        // Список стран для рандомной генерации
        private protected List<string> CountriesList = new List<string>()
        {
            "Россия", "Китай",
            "США", "Канада",
            "Бразилия", "Аргентина",
            "Египет", "ЮАР",
            "Австралия", "Новая Зеландия"
        };

        // Харкатеристики Place
        private protected double square;
        private protected string continent;
        private protected string country;
        private protected string placeName;

        // Свойство: Занимаемая площадь Place
        public double Square
        {
            get
            {
                return square;
            }
            set
            {
                if(value >= 0) 
                {
                    square = value;
                }
                else
                {
                    Console.WriteLine("Error. The sqaure can't take negative values.");
                }
            }
        }

        // Свойство: На каком континенте распложен Place
        public string Continent
        {
            get
            {
                return continent;
            }
            set
            {
                if(ContinentName.IndexOf(value) != -1)
                {
                    continent = value;
                }
                else
                {
                    Console.WriteLine("Error. There's no such continent.");
                }
            }
        }

        // Свойство: В какой стране распложен Place
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        // Свойство: Название Place
        public string PlaceName
        {
            get
            {
                return placeName;
            }
            set
            {
                placeName = value;
            }
        }

        // Конструктор класса без параметров
        public Place()
        {
            square = 0;
            continent = "";
            country = "";
            placeName = "";
        }

        // Конструктор класса с параметрами
        public Place(string cont, string coun, string name, double sq)
        {
            continent = cont;
            country = coun;
            placeName = name;
            square = sq;
        }

        // Вирутальный метод класса, показывающий информацию о Place
        public virtual void Show()
        {
            Console.WriteLine(placeName);
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Континент: {continent}");
            Console.WriteLine($"Страна: {country}");
            Console.WriteLine($"Площадь: {square}\n");
        }

        // Виртуальный метод класса, создающую информацию о Place с помощью вводимой информации
        public virtual void InputCreate()
        {
            Console.WriteLine("Введите континент: ");
            string cont = Console.ReadLine();
            while(ContinentName.IndexOf(cont) == -1)
            {
                Console.WriteLine("Error. There's no such continent. Please repeat the input.");
                cont = Console.ReadLine();
            }
            continent = cont;

            Console.WriteLine("Введите страну: ");
            country = Console.ReadLine();

            Console.WriteLine("Введите наименование места: ");
            placeName = Console.ReadLine();

            Console.WriteLine("Введите площадь: ");
            double number;
            while(!(double.TryParse(Console.ReadLine(), out number)) || number <= 0)
            {
                Console.WriteLine("Error. The sqaure can't take negative values. Please repeat the input.");
            }
            square = number;
        }

        // Виртуальный метод класса, создающую информацию о Place с помощью рандомайзера
        public virtual void RandomCreate()
        {
            Random random = new Random();
            int contPos = random.Next(0, ContinentName.Count);

            switch (contPos)
            {
                case 0:
                    country = CountriesList[random.Next(0, 1)];
                    if (country == "Россия")
                    {
                        placeName = "Байкал";
                        square = 560000;
                    }
                    else
                    {
                        PlaceName = "Желтое море";
                        square = 380000;
                    }
                    break;
                case 1:
                    country = CountriesList[random.Next(2, 3)];
                    if (country == "США")
                    {
                        placeName = "Мичиган";
                        square = 58016;
                    }
                    else
                    {
                        placeName = "Морейн";
                        square = 0.5;
                    }
                    break;
                case 2:
                    country = CountriesList[random.Next(4, 5)];
                    if (country == "Бразилия")
                    {
                        placeName = "Пантанал";
                        square = 195000;
                    }
                    else
                    {
                        placeName = "Анды";
                        square = 3371000;
                    }
                    break;
                case 3:
                    country = CountriesList[random.Next(6, 7)];
                    if (country == "Египет")
                    {
                        placeName = "Аравийская пустыня";
                        square = 2330000;
                    }
                    else
                    {
                        placeName = "Национальный парк Крюгер";
                        square = 19485;
                    }
                    break;
                case 4:
                    country = CountriesList[random.Next(8, 9)];
                    if (country == "Австралия")
                    {
                        placeName = "АБольшой Барьерный риф";
                        square = 3487000;
                    }
                    else
                    {
                        placeName = "Хоббитон";
                        square = 5;
                    }
                    break;
                case 5:
                    country = "";
                    PlaceName = "земля королевы мод";
                    Square = 27000000;
                    break;
            }
            continent = ContinentName[contPos];
        }

        // Виртуальный метод класса, который проверяет, принадлежит ли Place заданному запросу
        public virtual bool Search(object search)
        {
            return search is string contry ? country == search : false;
        }

        // Реализация интрефейса IComparable для возможности сравнения двух Place по площади
        public int CompareTo(object o)
        {
            if (o is Place place)
                return Square.CompareTo(place.Square);
            throw new Exception("Невозможно сравнить два объекта");
        }

        // Реализация интрефейса IComparable для возможности сравнения двух Place по всем параметрам
        public int CompareTo(Place other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var continentComparison = string.Compare(Continent, other.Continent, StringComparison.Ordinal);
            if (continentComparison != 0) return continentComparison;

            var countryComparison = string.Compare(Country, other.Country, StringComparison.Ordinal);
            if (countryComparison != 0) return countryComparison;

            var placeNameComparison = string.Compare(PlaceName, other.PlaceName, StringComparison.Ordinal);
            if (placeNameComparison != 0) return placeNameComparison;

            return Square.CompareTo(other.Square);
        }

        // Реализация интрефейса IComparer для возможности сравнения двух Place по площади с возвратом значения, указывающего, является ли один объект меньшим, равным или большим другого.
        public int Compare(object o1, object o2)
        {
            Place p1 = o1 as Place;
            Place p2 = o2 as Place;
            if (p1.Square > p2.Square)
                return 1;
            if (p1.Square < p2.Square)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            Console.WriteLine();
            this.Show();
            return "\n";
        }

        public static bool operator >(Place place1, Place place2)
        {
            return place1.Square > place2.Square;
        }

        public static bool operator <(Place place1, Place place2)
        {
            return place1.Square < place2.Square;
        }
    }
}