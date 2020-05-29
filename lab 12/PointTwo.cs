using Blab_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_12
{
    public class PointTwo : ICloneable, IEnumerable, IEnumerator
    {
        private static Random random = new Random();
        private static int position = -1;

        public Place data;      // Информационное поле
        public PointTwo next,   // Адрес следующего элемента
                        pred;   // Адрес предыдущего элемента

        public int Count
        {
            get
            {
                if (data == null)
                {
                    throw new Exception("Collection is empty");
                }

                PointTwo point = (PointTwo)this.Clone();

                while(point.pred != null)
                {
                    point = point.pred;
                }

                int count = 1;
                while(point.next != null)
                {
                    count++;
                    point = point.next;
                }

                return count;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (position == -1)
                    throw new InvalidOperationException();

                return position;
            }
        }

        // Конструктор без параметров
        public PointTwo()
        {
            data = null;
            next = null;
            pred = null;
        }

        // Конструктор с параметром
        public PointTwo(Place place)
        {
            position = 0;
            data = place;
            next = null;
            pred = null;
        }

        // Поверхостное копирование
        public PointTwo ShallowCopy()
        {
            return (PointTwo)MemberwiseClone();
        }

        // Метод для поиска элемента по значению
        public int IndexOf(Place place)
        {
            int index = 0;
            bool check = false;

            PointTwo point = (PointTwo)this.Clone();

            while (point.pred != null)
            {
                point = point.pred;
            }

            while (point.next != null && !check)
            {
                if (point.data == place)
                {
                    check = true;
                }

                index++;
                point = point.next;
            }

            if (!check)
            {
                return -1;
            }

            return index;
        }

        // Клонирование
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // Полное удаление коллекции
        public void Clear()
        {
            data = null;
            next = null;
            pred = null;
        }

        // Создание элемента двунаправленного списка 
        public static PointTwo MakePoint(Place place)
        {
            PointTwo point = new PointTwo(place);
            return point;
        }

        // Добавление элементов в начало двунаправленного списка
        public static PointTwo MakeList(int size) //добавление в начало
        {
            int typeclass = random.Next(1, 4);

            PointTwo beg = new PointTwo();
            switch (typeclass)
            {
                case 1:
                    {
                        Place place = new Place();
                        place.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", place.ToString());
                        beg = MakePoint(place);
                    }
                    break;
                case 2:
                    {
                        Region region = new Region();
                        region.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", region.ToString());
                        beg = MakePoint(region);
                    }
                    break;
                case 3:
                    {
                        City city = new City();
                        city.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", city.ToString());
                        beg = MakePoint(city);
                    }
                    break;
                case 4:
                    {
                        Megapolis megapolis = new Megapolis();
                        megapolis.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", megapolis.ToString());
                        beg = MakePoint(megapolis);
                    }
                    break;
            }

            for (int i = 1; i < size; i++)
            {
                typeclass = random.Next(1, 4);
                PointTwo point = new PointTwo();

                switch (typeclass)
                {
                    case 1:
                        {
                            Place place = new Place();
                            place.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", place.ToString());
                            point = MakePoint(place);
                        }
                        break;
                    case 2:
                        {
                            Region region = new Region();
                            region.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", region.ToString());
                            point = MakePoint(region);
                        }
                        break;
                    case 3:
                        {
                            City city = new City();
                            city.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", city.ToString());
                            point = MakePoint(city);
                        }
                        break;
                    case 4:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", megapolis.ToString());
                            point = MakePoint(megapolis);
                        }
                        break;
                }
                point.next = beg;
                beg.pred = point;
                beg = point;
            }
            return beg;
        }

        // Печать двунаправленного списка
        public static void ShowList(PointTwo beg)
        {
            // проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            PointTwo p = beg;

            // Идем к левому краю списка
            while(p.pred != null)
            {
                p = p.pred;
            }

            while (p != null)
            {
                Console.Write(p.ToString());
                p = p.next; //переход к следующему элементу
            }
            Console.WriteLine();
        }

        // УДаление элементов с четными номерами
        public static PointTwo RemoveEvenElems(PointTwo beg)
        {
            if (beg == null) // Пустой список
            {
                Console.WriteLine("Error! The List is empty");
                return null;
            }

            while (beg.pred != null)
            {
                beg = beg.pred;
            }

            int count = 1;

            while (beg.next != null)
            {
                beg = beg.next;
                count++;
            }

            if (count % 2 == 1)
            {
                beg = beg.pred;
                beg.next = null;
                count--;
            }

            PointTwo p = beg;

            for (int i = 0; i < count / 2 - 1; i++)
            {
                p = p.pred.pred;
                p.next = p.next.next;
            }

            p.pred = null;
            return p;
        }

        // Печать информационного поля
        public override string ToString()
        {            
            return data.ToString() + " ";
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        bool IEnumerator.MoveNext()
        {
            if (data != null && next != null)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        void IEnumerator.Reset()
        {

            if (data != null)
            {   
                position = 0;
            }
            else
            {
                position = -1;
            }
        }

    }
}
