namespace Trees
{
    internal class Program
    {
        // example
        static void Main()
        {
            ITree<int> tree = new AVLTree<int>();
            ITreeVizualizer visualizer = new TreeVisualizer();

            for (int i = 1; i <= 100; i++)
            {
                tree.Add(i);
            }

            visualizer.PrintTreePaths(tree);
        }
    }
}