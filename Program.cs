namespace Trees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree<string> tree = new AVLTree<string>();

            tree.Insert("a");
            tree.Insert("b");
            tree.Insert("c");
            tree.Insert("d");
            tree.Insert("e");
            tree.Delete(1);
            tree.PrintTreePaths(tree.root);
        }
    }
}