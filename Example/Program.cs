using Trees;

namespace Example
{
    internal class Program
    {
        static void Main()
        {
            ITree<int> tree = new AVLTree<int>();

            for (int i = 1; i <= 30; i++)
            {
                tree.Add(i);
            }

            tree.Remove(3);
            tree.Remove(5);
        }
    }
}