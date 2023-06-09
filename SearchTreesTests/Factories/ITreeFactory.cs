namespace Trees
{
    public interface ITreeFactory
    {
        ITree<int> CreateTree(int size);

        public void FillTree(ITree<int> tree,int size)
        {
            for (int i = 1; i <= size; i++)
            {
                tree.Add(i);
            }
        }
    }
}