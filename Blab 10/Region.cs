using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blab_10
{
    public class Region : Place, IComparer, IComparable, IPlace, ICloneable
    {
        // Характеристика Region
        private protected int populationSize;

        // Свйоство: Численность населения
        public int PopulationSize
        {
            get
            {
                return populationSize;
            }
            set
            {
                if (value >= 0)
                {
                    populationSize = value;
                }
                else
                {
                    Console.WriteLine("Error. The sqaure can't take negative values.");
                }
            }
        }

        // Констурктор клааса без параметров
        public Region()
            : base()
        { 
            populationSize = 0; 
        }

        // Конструктор класса с параметрами
        public Region(string cont, string coun, string name, double sq, int pSize)
            :base(cont, coun, name, sq)
        {
            populationSize = pSize;
        }

        // Мметод класса, показывающий плотность населения в Region
        public double PopulationDensity()
        {
             return populationSize / square;
        }

        // Вирутальный метод класса, показывающий информацию о Region
        public override void Show()
        {
            Console.WriteLine(placeName);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Характеристика");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Тип: область;");
            Console.WriteLine($"Континент: {continent};");
            Console.WriteLine($"Страна: {country};");
            Console.WriteLine($"Площадь: {square};");
            Console.WriteLine($"Население: {populationSize}.\n");
        }

        // Виртуальный метод класса, создающую информацию о Place с помощью вводимой информации
        public override void InputCreate()
        {
            Console.WriteLine("Введите континент: ");
            string cont = Console.ReadLine();
            while (ContinentName.IndexOf(cont) == -1)
            {
                Console.WriteLine("Error. There's no such continent. Please repeat the input.");
                cont = Console.ReadLine();
            }
            continent = cont;

            Console.WriteLine("Введите страну: ");
            country = Console.ReadLine();

            Console.WriteLine("Введите название области: ");
            placeName = Console.ReadLine();

            Console.WriteLine("Введите площадь: ");
            double number;
            while (!(double.TryParse(Console.ReadLine(), out number)) || number <= 0)
            {
                Console.WriteLine("Error. The sqaure can't take negative values. Please repeat the input.");
            }
            square = number;

            Console.WriteLine("Введите численность населения: ");
            int size;
            while (!(int.TryParse(Console.ReadLine(), out size)) || number <= 0)
            {
                Console.WriteLine("Error. The sqaure can't take negative values. Please repeat the input.");
            }
            populationSize = size;
        }

        // Виртуальный метод класса, создающую информацию о Place с помощью рандомайзера
        public override void RandomCreate()
        {
            Random random = new Random();
            int contPos = random.Next(0, ContinentName.Count);

            switch (contPos)
            {
                case 0:
                    country = CountriesList[random.Next(0, 1)];
                    if (country == "Россия")
                    {
                        placeName = "Пермский край";
                        square = 160600;
                        populationSize = 2637032;
                    }
                    else
                    {
                        placeName = "Провинция Аньхой";
                        square = 140200;
                        populationSize = 59500000;
                    }
                    break;
                case 1:
                    country = CountriesList[random.Next(2, 3)];
                    if (country == "США")
                    {
                        placeName = "Штат Аляска";
                        square = 1718000;
                        populationSize = 731545;
                    }
                    else
                    {
                        placeName = "Провинция Квебек";
                        square = 1667441;
                        populationSize = 8294656;
                    }
                    break;
                case 2:
                    country = CountriesList[random.Next(4, 5)];
                    if (country == "Бразилия")
                    {
                        placeName = "Штат Сан-Паулу";
                        square = 248197;
                        populationSize = 41262000;
                    }
                    else
                    {
                        placeName = "Провинция Буэнос-Айрес";
                        square = 307571;
                        populationSize = 16660000;
                    }
                    break;
                case 3:
                    country = CountriesList[random.Next(6, 7)];
                    if (country == "Египет")
                    {
                        placeName = "Провинция Александрия";
                        square = 2300;
                        populationSize = 4110015;
                    }
                    else
                    {
                        placeName = "Восточно-Капская провинция";
                        square = 168966;
                        populationSize = 6562053;
                    }
                    break;
                case 4:
                    country = CountriesList[random.Next(8, 9)];
                    if (country == "Австралия")
                    {
                        placeName = "Штат Виктория";
                        square = 277416;
                        populationSize = 5354042;
                    }
                    else
                    {
                        placeName = "Район Нортленд";
                        square = 13941;
                        populationSize = 1551692;
                    }
                    break;
                case 5:
                    country = "";
                    placeName = "земля королевы мод";
                    square = 27000000;
                    populationSize = 0;

                    break;
            }
            continent = ContinentName[contPos];
        }

        // Виртуальный метод класса, который проверяет, принадлежит ли Region заданному запросу (прворяет название области по запросу)
        public override bool Search(object search)
        {
            return search is string contry ? placeName == search : false;
        }

        // Реализация интрефейса IComparable для возможности сравнения двух Region по численности населения
        public new int CompareTo(object o)
        {
            if (o is Region place)
                return PopulationSize.CompareTo(place.PopulationSize);
            throw new Exception("Невозможно сравнить два объекта");
        }

        // Реализация интрефейса IComparable для возможности сравнения двух Region по всем параметрам
        public int CompareTo(Region other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var continentComparison = string.Compare(Continent, other.Continent, StringComparison.Ordinal);
            if (continentComparison != 0) return continentComparison;

            var countryComparison = string.Compare(Country, other.Country, StringComparison.Ordinal);
            if (countryComparison != 0) return countryComparison;

            var placeNameComparison = string.Compare(PlaceName, other.PlaceName, StringComparison.Ordinal);
            if (placeNameComparison != 0) return placeNameComparison;

            var PopulationSizeComparison = this.Compare(PopulationSize, other.PopulationSize);
            if (PopulationSizeComparison != 0) return PopulationSizeComparison;

            return Square.CompareTo(other.Square);
        }

        // Реализация интрефейса IComparer для возможности сравнения двух Region по численности населения с возвратом значения, указывающего, является ли один объект меньшим, равным или большим другого.
        public new int Compare(object o1, object o2)
        {
            Region p1 = o1 as Region;
            Region p2 = o2 as Region;
            if (p1.PopulationSize > p2.PopulationSize)
                return 1;
            if (p1.PopulationSize < p2.PopulationSize)
                return -1;
            else
                return 0;
        }

        // Метод класса, позволяющий поверхостное копирование
        public Region ShallowCopy()
        {
            return (Region)MemberwiseClone();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public Place BasePlace
        {
            get
            {
                return new Place(continent, country, placeName, square);
            }
        }

        public override string ToString()
        {
            Console.WriteLine();
            this.Show();
            return "\n";
        }
    }
}
