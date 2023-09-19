namespace Trees
{
    public class BinarySearchTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        private INodeFactory _nodeFactory;

        public INode Root { get; set; }

        public BinarySearchTree() : this(new BinaryNodeFactory())
        {

        }

        public BinarySearchTree(INodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(valueType value)
        {
            INode addedNode = Root?.Add(value);

            if (Root == null)
            {
                Root = _nodeFactory.Create(value);
                addedNode = Root;
            }

            return addedNode;
        }

        public INode Remove(valueType value)
        {
            return Root.Remove(value);
        }

        public INode Find(valueType value)
        {
            return Root.Find(value);
        }
    }
}