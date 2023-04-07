namespace Trees
{
    internal class Program
    {
        // example
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            for (int i = 1; i <= 20; i++)
            {
                tree.Add(i);
            }

            tree.PrintTree();
        }
    }
}