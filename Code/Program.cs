namespace Trees
{
    internal class Program
    {
        // example
        // not working with more than 75000 nodes
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 1; i <= 24; i++)
            {
                tree.Add(i);
            }

            tree.PrintTreePaths();
        }
    }
}