namespace Trees
{
    public class BinarySearchTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        public event Action<INode> OnNodeRemoved;
        public event Action<INode> OnNodeAdded;
        
        private INodeFactory _nodeFactory = new BinaryNodeFactory();

        public INode Root { get; set; }

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(valueType value)
        {
            INode addedNode = AddNode(value);
            
            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        private INode AddNode(valueType value)
        {
            INode addedNode = Root?.Add(value);
            
            if(Root == null)
            {
                Root = _nodeFactory.Create(value);
                addedNode = Root;
            }

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