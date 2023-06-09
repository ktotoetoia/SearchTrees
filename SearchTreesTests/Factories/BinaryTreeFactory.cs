namespace Trees
{
    public class BinaryTreeFactory : ITreeFactory
    {
        public ITree<int> CreateTree(int size)
        {
            ITree<int> tree = new BinarySearchTree<int>();
            (this as ITreeFactory).FillTree(tree, size);

            return tree;
        }
    }
}