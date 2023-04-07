namespace Trees
{
    public interface ITree<valueType>
        where valueType : IComparable<valueType>
    {
        public INode root { get; set; }

        public delegate void NodeDelegate(INode node);
        public event NodeDelegate OnNodeRemoved;
        public event NodeDelegate OnNodeAdded;

        public INode Add(valueType value);

        public INode Remove(valueType value);

        public INode Find(valueType value);
    }

    public interface ITreeVizualizer
    {
        public void PrintTree();
        public void PrintTreePaths();
    }
}