namespace Trees
{
    public class AVLTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        public event Action<INode> OnNodeRemoved;
        public event Action<INode> OnNodeAdded;
        
        private INodeFactory _nodeFactory = new AVLNodeFactory();

        public INode Root { get; set; }
        
        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> added node </returns>
        public INode Add(valueType value)
        {
            INode addedNode;

            if (Root != null)
            {
                addedNode = Root.Add(value);
                Root = ((IBalancing)Root).Balance();
            }

            else
            {
                addedNode = _nodeFactory.Create(value);
                Root = addedNode;
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