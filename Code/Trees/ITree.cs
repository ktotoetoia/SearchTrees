namespace Trees
{
    public interface ITree<valueType>
        where valueType : IComparable<valueType>
    {
        public INode root { get; set; }

        public delegate void NodeDelegate(INode node);
        public event NodeDelegate OnNodeRemoved;
        public event NodeDelegate OnNodeAdded;

        /// <summary>
        /// Creates and add node 
        /// </summary>
        /// <returns> Added node </returns>
        public INode Add(valueType value);

        /// <summary>
        /// Removes first node with the same value
        /// </summary>
        /// <returns> Node that replaces removed </returns>
        public INode Remove(valueType value);

        /// <returns> First node with the same value, or null if node is not exist</returns>
        public INode Find(valueType value);
    }

    public interface ITreeVizualizer
    {
        /// <summary>
        /// Prints tree in ascending order
        /// </summary>
        public void PrintTree<type>(ITree<type> tree)
            where type : IComparable<type>;

        /// <summary>
        /// Prints nodes with their childs
        /// </summary>
        public void PrintTreePaths<type>(ITree<type> tree)
            where type : IComparable<type>;
    }
}