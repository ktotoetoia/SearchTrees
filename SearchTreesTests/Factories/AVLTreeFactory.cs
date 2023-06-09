namespace Trees
{
    public class AVLTreeFactory : ITreeFactory
    {
        public ITree<int> CreateTree(int size)
        {
            ITree<int> tree = new AVLTree<int>();

            (this as ITreeFactory).FillTree(tree, size);

            return tree;
        }
    }
}