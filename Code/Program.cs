using System.Diagnostics;

namespace Trees
{
    internal class Program
    {
        // example
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            
            for (int i = 1; i <= 100; i++)
            {
                tree.Add(i);
            }

            tree.PrintTreePaths();
        }
    }
}