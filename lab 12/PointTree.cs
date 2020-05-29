using Blab_10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_12
{
    public class PointTree : ICloneable, IEnumerable, IEnumerator
    {
        private static Random random = new Random();
        private static int position = -1;

        object IEnumerator.Current
        {
            get
            {
                if (position == -1)
                    throw new InvalidOperationException();

                return position;
            }
        }

        public Place data;      // Информационное поле
        public PointTree left,  // Aдрес левого поддерева 
                         right; // Aдрес правого поддерева

        public int Count
        {
            get
            {
                int count = 0;
                PointTree point = (PointTree)this.Clone();

                if (point != null)
                    count = 1 + left.Count + right.Count;

                return count;
            }
        }

        // Конструктор без параметров
        public PointTree()
        {
            data = null;
            left = null;
            right = null;
        }

        // Конструктор с параметрам
        public PointTree(Place place)
        {
            data = place;
            left = null;
            right = null;
        }

        // Поверхостное копирование
        public PointTree ShallowCopy()
        {
            return (PointTree)MemberwiseClone();
        }

        // Метод для поиска элемента по значению
        public bool IndexOf(Place place)
        {
            bool index = false;

            PointTree point = (PointTree)this.Clone();

            if (point.data == place)
            {
                return true;
            }

            if (point.left != null)
            {
                index = point.left.IndexOf(place);
            }

            if (!index && point.right != null)
            {
                index = point.right.IndexOf(place);
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
            left = null;
            right = null;
        }

        // Рекурсивная функция для печати дерева по уровням с обходом слева направо
        public static void ShowTree(PointTree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);//переход к левому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.ToString());//печать узла
                ShowTree(p.right, l + 3);//переход к правому поддереву
            }
        }

        // Формирование первого элемента дерева
        public static PointTree first(Place place)
        {
            PointTree p = new PointTree(place);
            return p;
        }

        // Добавление элемента d в дерево поиска
        public static PointTree Add(PointTree root, Place place)
        {
            PointTree p = root; // корень дерева
            PointTree r = null;

            // Флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                // элемент уже существует
                if (place == p.data)
                {
                    ok = true;
                }
                else
                {
                    if (place < p.data)
                    {
                        // Пойти в левое поддерево
                        p = p.left;
                    }
                    else
                    {
                        // Пойти в правое поддерево
                        p = p.right;
                    }
                }
            }

            // Если найдено, то не добавляем
            if (ok) return p;
                             
            // создаем узел с выделением памяти
            PointTree NewPoint = new PointTree(place);

            // Если place < r.key, то добавляем его в левое поддерево
            if (place < r.data)
            {
                r.left = NewPoint;
            }
            // если place >r.key, то добавляем его в правое поддерево
            else
            {
                r.right = NewPoint; 
            }

            return r;
        }

        // Построение идеально сбалансированного дерева
        public static PointTree IdealTree(int size, PointTree p)
        {
            PointTree r;
            int nl, nr;
            if (size == 0) 
            { 
                p = null;
                return p; 
            }
            nl = size / 2;
            nr = size - nl - 1;

            r = new PointTree();

            int typeclass = random.Next(1, 4);
            switch (typeclass)
            {
                case 1:
                    {
                        Place place = new Place();
                        place.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", place.ToString());
                        r = first(place);
                    }
                    break;
                case 2:
                    {
                        Region region = new Region();
                        region.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", region.ToString());
                        r = first(region);
                    }
                    break;
                case 3:
                    {
                        City city = new City();
                        city.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", city.ToString());
                        r = first(city);
                    }
                    break;
                case 4:
                    {
                        Megapolis megapolis = new Megapolis();
                        megapolis.RandomCreate();
                        Console.WriteLine("The element {0} is adding...", megapolis.ToString());
                        r = first(megapolis);
                    }
                    break;
            }

            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        // Печать информационного поля
        public override string ToString()
        {
            return data.PlaceName + " ";
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        bool IEnumerator.MoveNext()
        {
            if (data != null || left != null || right != null)
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
