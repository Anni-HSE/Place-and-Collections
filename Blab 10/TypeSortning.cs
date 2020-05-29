using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blab_10
{
    // Сортировка массива PlaceArray по названию объекта
    public class SortByName : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            Place p2 = (Place)obj2;
            return String.Compare(p1.PlaceName, p2.PlaceName);
        }
    }

    // Сортировка массива PlaceArray по континенту
    public class SortByContinent : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            Place p2 = (Place)obj2;
            return String.Compare(p1.Continent, p2.Continent);
        }
    }

    // Сортировка массива PlaceArray по стране
    public class SortByContry : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            Place p2 = (Place)obj2;
            return String.CompareOrdinal(p1.Country, p2.Country);
        }
    }

    // Сортировка массива PlaceArray по площади
    public class SortBySquare : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            Place p2 = (Place)obj2;

            if (p1.Square > p2.Square)
                return 1;
            if (p1.Square > p2.Square)
                return -1;
            return 0;
        }
    }

    // Поиск  по массиву PlaceArray по площади
    public class SearchBySquare : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            double p2 = (double)obj2;

            if (p1.Square > p2)
                return 1;
            if (p1.Square > p2)
                return -1;
            return 0;
        }
    }

    //Поиск по массиву PlaceArray по названию объекта
    public class SearchByName : IComparer
    {
        int IComparer.Compare(object obj1, object obj2)
        {
            Place p1 = (Place)obj1;
            string p2 = (string)obj2;
            return String.Compare(p1.PlaceName, p2);
        }
    }

    public class SortbyKey : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            string p1 = (string)x;
            string p2 = (string)y;
            return String.Compare(p1, p2);
        }
    }
}
