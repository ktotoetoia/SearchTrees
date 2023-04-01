namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();

            tree.Add("m");
            tree.Add("a");
            tree.Add("n");
            tree.Add("c");
            tree.Add("a");
            tree.Add("o");
            tree.Add("n");

            tree.Remove("n");
            tree.Remove("c");

            tree.PrintTree();
            tree.PrintTreePaths();
        }
    }
}