﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blab_10
{
    public class City : Region, IComparer, IComparable, IPlace, ICloneable
    {
        // Характеристика City
        private protected string regionName;

        // Переопределение Свойства: Численность населения
        public new int PopulationSize
        {
            get
            {
                return populationSize;
            }
            set
            {
                if (value >= 0 && value < 1000000)
                {
                    populationSize = value;
                }
                else if (value >= 0 && value >= 1000000)
                {
                    Console.WriteLine("Error. The population does not correspond to a City.");
                }
                else
                {
                    Console.WriteLine("Error. The sqaure can't take negative values.");
                }
            }
        }

        // Название области
        public string RegionName
        {
            get
            {
                return regionName;
            }
            set
            {
                regionName = value;
            }
        }

        // Конструктор класса без параметров
        public City()
            : base()
        {
            populationSize = 0;
            regionName = "";
        }

        // Конструктор класса с параметрами
        public City(string cont, string coun, string name, string Rname, double sq, int pSize)
            : base(cont, coun, name, sq, pSize)
        {
            regionName = Rname;
        }

        // Вирутальный метод класса, показывающий информацию о Region
        public override void Show()
        {
            Console.WriteLine(placeName);
            Console.WriteLine("------------------------------");
            Console.WriteLine("Характеристика");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Тип: город;");
            Console.WriteLine($"Континент: {continent};");
            Console.WriteLine($"Страна: {country};");
            Console.WriteLine($"Область: {regionName};");
            Console.WriteLine($"Площадь: {square};");
            Console.WriteLine($"Население: {populationSize}.\n");
        }

        // Виртуальный метод класса, создающую информацию о City с помощью вводимой информации
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
            regionName = Console.ReadLine();

            Console.WriteLine("Введите название города: ");
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
                        placeName = "Пермь";
                        regionName = "Пермский край";
                        square = 801.44;
                        populationSize = 1055397;
                    }
                    else
                    {
                        placeName = "Пекин";
                        regionName = "Города центрального подчинения";
                        square = 16410.54;
                        populationSize = 21710000;
                    }
                    break;
                case 1:
                    country = CountriesList[random.Next(2, 3)];
                    if (country == "США")
                    {
                        placeName = "Нью-Йорк";
                        regionName = "Штат Нью-Йорк";
                        square = 1214.9;
                        populationSize = 8405837;
                    }
                    else
                    {
                        placeName = "Монреаль";
                        regionName = "Провинция Квебек";
                        square = 363.13;
                        populationSize = 1942694;
                    }
                    break;
                case 2:
                    country = CountriesList[random.Next(4, 5)];
                    if (country == "Бразилия")
                    {
                        placeName = "Бразилиа";
                        regionName = "Федеральный округ";
                        square = 5801.937;
                        populationSize = 2609997;
                    }
                    else
                    {
                        placeName = "Буэнос-Айрес";
                        regionName = "Провинция Буэнос-Айрес";
                        square = 202;
                        populationSize = 3063728;
                    }
                    break;
                case 3:
                    country = CountriesList[random.Next(6, 7)];
                    if (country == "Египет")
                    {
                        placeName = "Каир";
                        regionName = "Провинция Каир";
                        square = 606;
                        populationSize = 9840591;
                    }
                    else
                    {
                        placeName = "Кейптаун";
                        regionName = "Западно-Капская провинция";
                        square = 2444.97;
                        populationSize = 3740026;
                    }
                    break;
                case 4:
                    country = CountriesList[random.Next(8, 9)];
                    if (country == "Австралия")
                    {
                        placeName = "Штат Виктория";
                        regionName = "Штат Новый южный Уэльс";
                        square = 12144;
                        populationSize = 5131326;
                    }
                    else
                    {
                        placeName = "";
                        regionName = "";
                        square = 0;
                        populationSize = 0;
                    }
                    break;
                case 5:
                    country = "";
                    placeName = "";
                    regionName = "земля королевы мод";
                    square = 27000000;
                    populationSize = 0;

                    break;
            }
            continent = ContinentName[contPos];
        }

        // Виртуальный метод класса, который проверяет, принадлежит ли City заданному запросу (проверяет: принадлежит ли город заданной области)
        public override bool Search(object search)
        {
            return search is string contry ? regionName == search : false;
        }

        // Реализация интрефейса IComparable для возможности сравнения двух City по численности населения
        public new int CompareTo(object o)
        {
            if (o is City place)
                return PopulationSize.CompareTo(place.PopulationSize);
            throw new Exception("Невозможно сравнить два объекта");
        }

        // Реализация интрефейса IComparable для возможности сравнения двух City по всем параметрам
        public int CompareTo(City other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var continentComparison = string.Compare(Continent, other.Continent, StringComparison.Ordinal);
            if (continentComparison != 0) return continentComparison;

            var countryComparison = string.Compare(Country, other.Country, StringComparison.Ordinal);
            if (countryComparison != 0) return countryComparison;

            var placeNameComparison = string.Compare(PlaceName, other.PlaceName, StringComparison.Ordinal);
            if (placeNameComparison != 0) return placeNameComparison;

            var RegionNameComparison = string.Compare(RegionName, other.RegionName, StringComparison.Ordinal);
            if (RegionNameComparison != 0) return RegionNameComparison;

            var PopulationSizeComparison = this.Compare(PopulationSize, other.PopulationSize);
            if (PopulationSizeComparison != 0) return PopulationSizeComparison;

            return Square.CompareTo(other.Square);
        }

        // Реализация интрефейса IComparer для возможности сравнения двух City по численности населения с возвратом значения, указывающего, является ли один объект меньшим, равным или большим другого.
        public new int Compare(object o1, object o2)
        {
            City p1 = o1 as City;
            City p2 = o2 as City;
            if (p1.PopulationSize > p2.PopulationSize)
                return 1;
            if (p1.PopulationSize < p2.PopulationSize)
                return -1;
            else
                return 0;
        }

        // Метод класса, позволяющий поверхостное копирование
        public new City ShallowCopy()
        {
            return (City)MemberwiseClone();
        }

        public Region BaseRegion
        {
            get
            {
                return new Region(continent, country, regionName, square, populationSize);
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
