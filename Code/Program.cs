namespace Trees
{
    internal class Program
    {
        // example
        // not working with more than 75000 nodes
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();

            Random a = new Random();

            for (int i = 0; i < 75000; i++)
            {
                tree.Add(a.Next(0, 100000));
            }

            tree.PrintTree();
        }
    }
}