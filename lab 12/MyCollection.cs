using Blab_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_12
{
    public class MyCollection: ICloneable, IEnumerable, IEnumerator
    {   
        private protected static Random random = new Random();
        private protected static int count = 0;
        private protected static int position = -1;

        object IEnumerator.Current
        {
            get
            {
                if (position == -1)
                    throw new InvalidOperationException();

                return position;
            }
        }

        public Place data;
        public MyCollection next;
        public MyCollection pred;

        public int Count
        {
            get { return count; }
        }

        public MyCollection()
        {
            data = null;
            next = null;
            pred = null;
        }

        public MyCollection(Place place)
        {
            count = 1;
            data = place;
            next = null;
            pred = null;
        }

        public MyCollection(int capacity)
        {
            MyCollection stack = MakeStack(new Place());

            for (int i = 1; i < capacity; i++)
            {
                MyCollection collection = new MyCollection(new Place());

                collection.next = stack;
                stack.pred = collection;
                stack = collection;
            }

            count = capacity;
            data = stack.pred.data;
            pred = stack;
        }

        public MyCollection(MyCollection c)
        {
            data = c.data;
            pred = c.pred;
            next = c.next;
            count = c.Count;
        }

        public MyCollection ShallowCopy()
        {
            return (MyCollection)MemberwiseClone();
        }

        public int IndexOf(Place place)
        {
            int index = 0;

            MyCollection beg = this;

            while (beg.pred != null) beg = beg.pred;

            while(beg.next != null)
            {
                if (beg.data == place)
                {
                    return index;
                }

                index++;
                beg = beg.next;
            }

            if (beg.data == place)
            {
                return index;
            }

            return -1;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Clear()
        {
            data = null;
            next = null;
            pred = null;
            count = 0;
        }

        public static MyCollection Add(MyCollection beg, Place place)
        {

            MyCollection collection = MakeStack(place);
            collection.pred = beg;
            beg.next = collection;
            count++;

            return beg;
        }

        public static MyCollection MakeList(int size)
        {
            int typeclass = random.Next(1, 4);

            MyCollection beg = new MyCollection();
            switch (typeclass)
            {
                case 1:
                    {
                        Place place = new Place();
                        place.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", place.ToString());
                        beg = MakeStack(place);
                    }
                    break;
                case 2:
                    {
                        Region region = new Region();
                        region.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", region.ToString());
                        beg = MakeStack(region);
                    }
                    break;
                case 3:
                    {
                        City city = new City();
                        city.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", city.ToString());
                        beg = MakeStack(city);
                    }
                    break;
                case 4:
                    {
                        Megapolis megapolis = new Megapolis();
                        megapolis.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", megapolis.ToString());
                        beg = MakeStack(megapolis);
                    }
                    break;
            }

            for (int i = 1; i < size; i++)
            {
                typeclass = random.Next(1, 4);
                MyCollection point = new MyCollection();

                switch (typeclass)
                {
                    case 1:
                        {
                            Place place = new Place();
                            place.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", place.ToString());
                            point = MakeStack(place);
                        }
                        break;
                    case 2:
                        {
                            Region region = new Region();
                            region.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", region.ToString());
                            point = MakeStack(region);
                        }
                        break;
                    case 3:
                        {
                            City city = new City();
                            city.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", city.ToString());
                            point = MakeStack(city);
                        }
                        break;
                    case 4:
                        {
                            Megapolis megapolis = new Megapolis();
                            megapolis.RandomCreate();
                            Console.WriteLine("The element {0} is adding...", megapolis.ToString());
                            point = MakeStack(megapolis);
                        }
                        break;
                }
                point.next = beg;
                beg.pred = point;
                beg = point;
            }
            return beg;
        }

        public static MyCollection Remove(MyCollection beg)
        {
            MyCollection collection = beg;
            while(collection.pred != null)
            {
                collection = collection.pred;
            }

            collection = collection.next;
            collection.pred = null;
            count--;

            return collection;
        }

        public static MyCollection RemoveAt(MyCollection beg, int count)
        {
            MyCollection collection = beg;

            while (collection.next != null) collection = collection.next;

            for(int i = collection.Count; i > collection.Count - count; i--)
            {
                collection = collection.pred;
            }

            collection.next = null;

            return collection;
        }

        public static MyCollection MakeStack(Place place)
        {
            MyCollection stack = new MyCollection(place);
            return stack;
        }

        public static void ShowList(MyCollection beg)
        {
            // проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            MyCollection p = beg;

            // Идем к левому краю списка
            while (p.pred != null)
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
