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

            tree.Delete("b");
            
            tree.PrintTree(tree.root);
            tree.PrintTreePaths(tree.root);
        }
    }
}