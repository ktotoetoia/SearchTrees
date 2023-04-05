namespace Trees
{
    internal class Program
    {
        // example
        // not working with more than 75000 nodes
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 1; i <= 9; i++)
            {
                tree.Add(i);
                if(i%3 == 0)
                {
                    tree.Remove(i-2);
                }
            }

            tree.PrintTreePaths();

        }
    }
}