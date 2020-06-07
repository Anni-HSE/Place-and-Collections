using Blab_10;
using lab_11;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_14
{
    class Inquiry
    {
        #region LINQ
        // Запрос LINQ: Название всех Регионов заданной страны (выборка данных)
        static void ListRegionLINQ(TestCollections list, string country)
        {
              var  regionsNames  =  from region in list.Regions     // определяем каждый объект из list.Regions как region
                                    where region.Country == country // фильтрация по критерию
                                    orderby region                  // упорядочиваем по возрастанию
                                    select region;                  // выбираем объект

            
            if(regionsNames == null)
            {
                Console.WriteLine("В колекции не существует такой страны как " + country);
                return;
            }

            Console.WriteLine("Список названий регионов страны " + country);
            foreach (Region region in regionsNames)
            {
                Console.WriteLine(region.PlaceName);
            }

        }

        // Запрос LINQ:	Количество регионов с данным населением (получение счетчика)
        static void CountPeopleCountryLINQ(TestCollections list, int populationSize)
        {
            var regionlist = from region 
                             in list.Regions
                             where region.PopulationSize == populationSize
                             select region;

            Console.WriteLine("Количество регионов с населением в " + populationSize + " человек = " + regionlist.Count());
        }

        // Запрос LINQ: Суммарное количество жителей всех стран на континенте (агрегирование данных)
        static void SumPoeopleContinentLINQ(TestCollections list, string continent)
        {
            int count = (from region in list.Regions where region.Continent == continent select region.PopulationSize).ToArray().Sum();
            Console.WriteLine("Суммарное количество жителей всех стран на континенте " + continent + " = " + count);
        }

        // Запрос LINQ: регионы которые храняться в двух колллекциях (пересечние данных)
        static void CommonItemsInCollectionsLINQ(TestCollections list1, TestCollections list2)
        {
            var collection = (from region in list1.Regions select region).Union(from region1 in list2.Regions select region1);

            if (collection == null)
            {
                Console.WriteLine("Нет общих регионов в коллекциях");
                return;
            }

            Console.WriteLine("Общие регионы:");
            foreach(Region item in collection)
            {
                item.Show();
            }
        }

        // Запрос LINQ: регионы которые есть в одной колллекции, но нет в другой (разность данных)
        static void ExceptItemsInCollectionsLINQ(TestCollections list1, TestCollections list2)
        {
            var collection = (from region in list1.Regions select region).Except(from region1 in list2.Regions select region1);

            if (collection == null)
            {
                Console.WriteLine("В обеих коллекциях храняться одинаовые элементы");
                return;
            }

            Console.WriteLine("Регионы, которых нет во второй коллекции:");
            foreach (Region item in collection)
            {
                item.Show();
            }
        }
        #endregion

        #region Методы_Расширения
        // Метод расширения: Название всех Регионов заданной страны (выборка данных)
        static void ListRegionExtension(TestCollections list, string country)
        {
            var regionsNames = list.Regions.Where(region => region.Country == country).OrderBy(region => region);


            if (regionsNames == null)
            {
                Console.WriteLine("В колекции не существует такой страны как " + country);
                return;
            }

            Console.WriteLine("Список названий регионов страны " + country);
            foreach (Region region in regionsNames)
            {
                Console.WriteLine(region.PlaceName);
            }

        }

        // Метод расширения:	Количество регионов с данным населением (получение счетчика)
        static void CountPeopleCountryExtension(TestCollections list, int populationSize)
        {
            var regionlist = list.Regions.Where(region => region.PopulationSize == populationSize).Count();

            Console.WriteLine("Количество регионов с населением в " + populationSize + " человек = " + regionlist);
        }

        // Метод расширения: Суммарное количество жителей всех стран на континенте (агрегирование данных)
        static void SumPoeopleContinentExtension(TestCollections list, string continent)
        {
            int count = list.Regions.Where(region => region.Continent == continent).Select(region => region.PopulationSize).ToArray().Sum();
            Console.WriteLine("Суммарное количество жителей всех стран на континенте " + continent + " = " + count);
        }

        // Метод расширения: регионы которые храняться в двух колллекциях (пересечние данных)
        static void CommonItemsInCollectionsExtension(TestCollections list1, TestCollections list2)
        {
            var collection = list1.Regions.Select(region => region).Union(list2.Regions.Select(region1 => region1));

            if (collection == null)
            {
                Console.WriteLine("Нет общих регионов в коллекциях");
                return;
            }

            Console.WriteLine("Общие регионы:");
            foreach (Region item in collection)
            {
                item.Show();
            }
        }

        // Метод расширения: регионы которые есть в одной колллекции, но нет в другой (разность данных)
        static void ExceptItemsInCollectionsExtension(TestCollections list1, TestCollections list2)
        {
            var collection = list1.Regions.Select(region => region).Except(list2.Regions.Select(region1 => region1));

            if (collection == null)
            {
                Console.WriteLine("В обеих коллекциях храняться одинаовые элементы");
                return;
            }

            Console.WriteLine("Регионы, которых нет во второй коллекции:");
            foreach (Region item in collection)
            {
                item.Show();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            TestCollections collections1 = new TestCollections(10);
            for(int i = 0; i < collections1.Size; i++)
            {
                Region region = new Region();
                region.RandomCreate();
                collections1[i] = region;
            }

            TestCollections collections2 = new TestCollections(5);
            for (int i = 0; i < collections2.Size; i++)
            {
                Region region = new Region();
                region.RandomCreate();
                collections2[i] = region;
            }

            int number = TypeInquiry();

            while (number != 0)
            {
                Console.Clear();

                switch (number)
                {
                    case 1:
                        {
                            int type = NumberUnquiry(number);
                            switch (type)
                            {
                                case 1:
                                    ListRegionLINQ(collections1, "Россия");
                                    break;
                                case 2:
                                    CountPeopleCountryLINQ(collections1, 200000);
                                    break;
                                case 3:
                                    SumPoeopleContinentLINQ(collections1, "Евразия");
                                    break;
                                case 4:
                                    CommonItemsInCollectionsLINQ(collections1, collections2);
                                    break;
                                case 5:
                                    ExceptItemsInCollectionsLINQ(collections1, collections2);
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            int type = NumberUnquiry(number);
                            switch (type)
                            {
                                case 1:
                                    ListRegionExtension(collections1, "Китай");
                                    break;
                                case 2:
                                    CountPeopleCountryExtension(collections1, 100000);
                                    break;
                                case 3:
                                    SumPoeopleContinentExtension(collections1, "Африка");
                                    break;
                                case 4:
                                    CommonItemsInCollectionsExtension(collections2, collections1);
                                    break;
                                case 5:
                                    ExceptItemsInCollectionsExtension(collections2, collections1);
                                    break;
                            }
                        }
                        break;
                }

                Console.Clear();
                number = TypeInquiry();
            }
        }

        private static int NumberUnquiry(int type)
        {
            int number;

            if (type == 1)
            {
                Console.WriteLine("Работа с Linq запросами");
            }
            else
            {
                Console.WriteLine("Работа с методами расширения");
            }
            
            Console.WriteLine("Меню\nВыберете тип запросов");
            Console.WriteLine("1. Название всех Регионов заданной страны (выборка данных)\n" +
                              "2. Количество регионов с данным населением (получение счетчика)\n" +
                              "3. Суммарное количество жителей всех стран на континенте (агрегирование данных)\n" +
                              "4. регионы которые храняться в двух колллекциях (пересечние данных)\n" +
                              "5. регионы которые есть в одной колллекции, но нет в другой (разность данных)\n" +
                              "0. В главное меню");

            while (!(int.TryParse(Console.ReadLine(), out number)) || number < 0 || number > 5)
            {
                Console.WriteLine("Ошибка. Вы вввели некоректное число. Повторите ввод!");

            }

            return number;


        }

        private static int TypeInquiry()
        {
            int number;

            Console.WriteLine("Работа с запросами");
            Console.WriteLine("Меню\nВыберете тип запросов");
            Console.WriteLine("1. Linq запросы\n2. Методы расширения\n0. Exit");

            while(!(int.TryParse(Console.ReadLine(), out number)) || number < 0 || number > 2)
            {
                Console.WriteLine("Ошибка. Вы вввели некоректное число. Повторите ввод!");

            }

            return number;
        }
    }
}
