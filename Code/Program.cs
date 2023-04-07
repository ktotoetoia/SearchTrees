namespace Trees
{
    internal class Program
    {
        // example
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            TreeVisualizer visualizer = new TreeVisualizer();

            for (int i = 1; i <= 24; i++)
            {
                tree.Add(i);
            }

            visualizer.PrintTree(tree);
        }
    }
}