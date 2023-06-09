namespace Trees
{
    public interface ITree<valueType> : INodeEvents, IHasRoot
        where valueType : IComparable<valueType>
    {
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
    
    public interface INodeEvents
    {
        public delegate void NodeDelegate(INode node);
        public event NodeDelegate OnNodeRemoved;
        public event NodeDelegate OnNodeAdded;
    }

    public interface IHasRoot
    {
        public INode Root { get; set; }
    }
}