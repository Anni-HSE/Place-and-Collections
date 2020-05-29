using Blab_10;
using System;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1");

            Console.WriteLine("Работа с одноправленным списоком");
            PointOne one = new PointOne();
            one = PointOne.MakeList(10);
            Console.WriteLine("Одноправленный список");
            PointOne.ShowList(one);
            Console.WriteLine("Добавление в конец");
            one = PointOne.MakeListToEnd(7);
            Console.WriteLine("Одноправленный список");
            PointOne.ShowList(one);

            Console.WriteLine();

            Console.WriteLine("Работа с двунаправленным списоком");
            PointTwo two = new PointTwo();
            two = PointTwo.MakeList(10);
            Console.WriteLine("Двунаправленный список");
            PointTwo.ShowList(two);
            Console.WriteLine("Удаление четных элементов");
            two = PointTwo.RemoveEvenElems(two);
            Console.WriteLine("Двунаправленный список");
            PointTwo.ShowList(two);

            Console.WriteLine();

            Console.WriteLine("Работа с деревоом");
            PointTree tree = new PointTree();
            Console.WriteLine("Создание сбалансированного дерева");
            tree = PointTree.IdealTree(10, tree);
            Console.WriteLine("Дерево");
            PointTree.ShowTree(tree, 200);
        }
    }
}
