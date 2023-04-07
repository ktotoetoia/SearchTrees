namespace Trees
{
    internal class TreeVisualizer : ITreeVizualizer
    {
        protected void PrintTree(INode node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        protected void PrintTreePaths(INode node)
        {
            if(node == null) return;

            if (node.Left != null)
            {
                Console.WriteLine(node.Value + ">" + node.Left.Value);
            }
            PrintTreePaths(node.Left);
            if(node.Right != null)
            {
                Console.WriteLine(node.Value + "<" + node.Right.Value);
            }

            PrintTreePaths(node.Right);
        }

        public void PrintTree<type>(ITree<type> tree)
            where type : IComparable<type>
        {
            PrintTree(tree.root);
        }

        public void PrintTreePaths<type>(ITree<type> tree)
            where type : IComparable<type>
        {
            PrintTreePaths(tree.root);
        }
    }
}