namespace Trees
{
    public class BinarySearchTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        public event Action<INode> OnNodeRemoved;
        public event Action<INode> OnNodeAdded;

        public INode Root { get; set; }
        private INodeFactory _nodeFactory = new BinaryNodeFactory();

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(valueType value)
        {
            INode addedNode;

            if (Root != null)
            {
                addedNode = Root.Add(value);
            }

            else
            {
                Root = _nodeFactory.Create(value);
                addedNode = Root;
            }

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        public INode Remove(valueType value)
        {
            INode result = Root.Remove(value);
            
            OnNodeRemoved?.Invoke(result);
            
            return result;
        }

        public INode Find(valueType value)
        {
            return Root.Find(value);
        }
    }
}