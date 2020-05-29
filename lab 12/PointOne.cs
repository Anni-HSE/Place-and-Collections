using Blab_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace lab_12
{
    public class PointOne : ICloneable, IEnumerable, IEnumerator
    {
        private static Random random = new Random();
        private static int position = -1; 

        public Place data;      // Информационное поле
        public PointOne next;   // Адресное поле

        public int Count
        {
            get
            {
                if (data == null)
                {
                    throw new Exception("Collection is empty");
                }

                int count = 1;
                PointOne tmp = this;
                while (next != null)
                {
                    count++;
                    tmp = tmp.next;
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

        // Конструктор класса без параметров
        public PointOne()
        {
            data = null;
            next = null;
        }

        // Конструктор класса c параметрами
        public PointOne(Place place)
        {
            position = 0;
            data = place;
            next = null;
        }

        // Поверхостное копирование
        public PointOne ShallowCopy()
        {
            return (PointOne)MemberwiseClone();
        }

        // Метод для поиска элемента по значению
        public int IndexOf(Place place)
        {
            int index = 0;
            bool check = false;

            PointOne point = (PointOne) this.Clone();
            while (point.next != null && !check)
            {
                if(point.data == place)
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
        }

        // Создание элемента одноправленного списка 
        public static PointOne MakePoint(Place place)
        {
            PointOne point = new PointOne(place);
            return point;
        }

        // Добавление в начало однонаправленного списка
        public static PointOne MakeList(int size)
        {
            int typeclass = random.Next(1, 4);
            PointOne beg = new PointOne();

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
                PointOne point = new PointOne();

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
                beg = point;
            }
            return beg;

        }

        // Добавление в конец однонаправленного списка
        public static PointOne MakeListToEnd(int size)
        {
            int typeclass = random.Next(1, 4);
            PointOne beg = new PointOne();

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

            PointOne r = beg;
            for (int i = 1; i < size; i++)
            {
                typeclass = random.Next(1, 4);
                PointOne point = new PointOne();

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

                r.next = point;
                r = point;
            }
            return beg;
        }

        // Добавление элемента в одноправленный список
        public static PointOne AddPoint(PointOne beg, int number)
        {
            int typeclass = random.Next(1, 4);
            PointOne point = new PointOne();

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

            if (beg == null)
            {
                switch (typeclass)
                {
                    case 1:
                        {
                            Place place = new Place();
                            place.RandomCreate();
                            beg = MakePoint(place);
                        }
                        break;
                    case 2:
                        {
                            Region region = new Region();
                            region.RandomCreate();
                            beg = MakePoint(region);
                        }
                        break;
                    case 3:
                        {
                            City city = new City();
                            city.RandomCreate();
                            beg = MakePoint(city);
                        }
                        break;
                    case 4:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.RandomCreate();
                            beg = MakePoint(megapolis);
                        }
                        break;
                }

                return beg;               
            }

            if (number == 1)
            {
                point.next = beg;
                beg = point;
                return beg;
            }

            // Вспом. переменная для прохода по списку
            PointOne p = beg;

            // Идем по списку до нужного элемента
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;
            
            if (p == null) //элемент не найден
            {
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }

            // Lобавляем новый элемент
            point.next = p.next;
            p.next = point;
            return beg;

        }

        // Удаление элемента из одноправленного списка
        public static PointOne RemovePoint(PointOne beg, int number)
        {
            if (beg == null) // Пустой список
            {
                Console.WriteLine("Error! The List is empty");
                return null;
            }

            if (number == 1) // Удаляем первый элемент
            {
                beg = beg.next;
                return beg;
            }

            PointOne p = beg;

            // Ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number - 1 && p != null; i++)
                p = p.next;

            if (p == null) // Если элемент не найден
            {
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }

            // исключаем элемент из списка
            p.next = p.next.next;
            return p;
        }

        // Печать одноправленного списка
        public static void ShowList(PointOne beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            PointOne p = beg;
            while (p != null)
            {
                Console.Write(p.ToString());
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();

        }

        // Вывод информационного поля
        public override string ToString()
        {
            Console.WriteLine();
            data.Show();
            return "\n";
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