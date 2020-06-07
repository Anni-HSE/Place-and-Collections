using Blab_10;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_11
{
    public class TestCollections
    {
        private protected int size = 0;

        public List<Region> Regions = null;
        public List<string> RegionsNames = null;

        public SortedDictionary<Place, Region> RegionPlace = null;
        public SortedDictionary<string, Region> RegionString = null;

        public int Size
        {
            get
            {
                return size;
            }
        }

        public virtual Region this[int index]
        {
            get
            {
                return Regions[index];
            }
            set
            {
                if (index >= 0 && index < size)
                {
                    Regions[index] = value;
                    RegionsNames[index] = value.PlaceName;

                    RegionPlace[value.BasePlace] = value;
                    RegionString[value.PlaceName] = value;
                }
                else
                {
                    throw new Exception("position that is out of line with the size of the collection");
                }
            }
        }

        public TestCollections()
        {
            Regions = new List<Region>();
            RegionsNames = new List<string>();

            RegionPlace = new SortedDictionary<Place, Region>();
            RegionString = new SortedDictionary<string, Region>();
        } 
        public TestCollections(int _size)
        {
            if (_size >= 0)
            {
                size = _size;
                for (int i = 0; i < _size; i++)
                {
                    Region region = new Region();
                    Regions.Add(region);
                    RegionsNames.Add(region.PlaceName);
                    RegionPlace.Add(region.BasePlace, region);
                    RegionString.Add(region.PlaceName, region);
                }
            }
            else
            {
                throw new Exception("Размер коллекций не может быть отрицательным!");
            }
        }

        public void PrintList(List<Region> regions)
        {
            Console.WriteLine("PRINT LIST PLACES");
            foreach (Place item in Regions)
            {
               item.Show();
            }
        }
        public void PrintList(List<string> regionsNames)
        {
            Console.WriteLine("PRINT LIST REGIONSNAMES");
            foreach (string item in RegionsNames)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintDictionary(SortedDictionary<Place, Region> regionPlace)
        {
            Console.WriteLine("PRINT DICTIONARY REGIONPLACE");
            foreach (KeyValuePair<Place, Region> keyValue in RegionPlace)
            {
                Place obj = keyValue.Value as Place;
                if (obj != null)
                {
                   obj.Show();
                }
            }
        }
        public void PrintDictionary(SortedDictionary<string, Region> regionString)
        {
            Console.WriteLine("PRINT DICTIONARY REGIONSTRING");
            foreach (string key in RegionString.Keys)
            {
                Console.WriteLine("Ключ: " + key);
                Console.WriteLine("Значение: ");
                RegionString[key].Show();
            }
        }

        public virtual void Add(Region item)
        {
            Regions.Add(item);
            RegionsNames.Add(item.PlaceName);

            if (!RegionPlace.ContainsKey(item.BasePlace))
            {
                RegionPlace.Add(item.BasePlace, item);
            }
            else
            {
                Region itemCopy = item.ShallowCopy();
                Place tmp = itemCopy.BasePlace;
                tmp.PlaceName += " 1";
                RegionPlace.Add(tmp, itemCopy);
            }

            if (!RegionString.ContainsKey(item.PlaceName))
            {
                RegionString.Add(item.PlaceName, item);
            }
            else
            {
                string tmp = item.PlaceName + "1";
                RegionString.Add(tmp, item);
            }

            size++;
        }

        public virtual bool Remove(Region item)
        {

            if (Regions.IndexOf(item) != -1)
            {
                Regions.Remove(item);
                RegionsNames.Remove(item.PlaceName);

                RegionPlace.Remove(item.BasePlace);
                RegionString.Remove(item.PlaceName);

                size--;

                return true;
            }

            Console.WriteLine("Удалить элемент невозможно, так как его нет в коллекции");
            return false;

        }

        public virtual bool Remove(int position)
        {
            if (position < size && position >= 0)
            {
                Region item = Regions[position];
                Regions.Remove(item);
                RegionsNames.Remove(item.PlaceName);

                RegionPlace.Remove(item.BasePlace);
                RegionString.Remove(item.PlaceName);

                size--;

                return true;
            }

            Console.WriteLine("Удалить элемент невозможно, так как его нет в коллекции");
            return false;

        }
    }
}