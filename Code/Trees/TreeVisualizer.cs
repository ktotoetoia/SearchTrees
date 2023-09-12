namespace Trees
{
    public class TreeVisualizer : ITreeVizualizer
    {
        protected void PrintTree(INode node)
        {
            if (node == null)
            {
                return;
            }

            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        protected void PrintTreePaths(INode node)
        {
            if (node.Left != null)
            {
                Console.WriteLine(node.Value + ">" + node.Left.Value);
                PrintTreePaths(node.Left);
            }

            if(node.Right != null)
            {
                Console.WriteLine(node.Value + "<" + node.Right.Value);
                PrintTreePaths(node.Right);
            }
        }

        public void PrintTree<valueType>(ITree<valueType> tree)
            where valueType : IComparable
        {
            PrintTree(tree.Root);
        }

        public void PrintTreePaths<valueType>(ITree<valueType> tree)
            where valueType : IComparable
        {
            PrintTreePaths(tree.Root);
        }
    }
}