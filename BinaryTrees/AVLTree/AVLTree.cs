namespace Trees
{
    public class AVLTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        protected readonly INodeFactory _nodeFactory;
        protected IAVLNode _root;

        public INode Root { get { return _root; } }

        public AVLTree() : this(new AVLNodeFactory())
        {

        }

        public AVLTree(INodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(valueType value)
        {
            INode nodeToAdd;

            if (_root != null)
            {
                nodeToAdd = Root.Add(value);
                _root = (IAVLNode)_root.Balance();
            }
            else
            {
                nodeToAdd = _nodeFactory.Create(value);
                _root = (IAVLNode)nodeToAdd;
            }

            return nodeToAdd;
        }

        public INode Remove(valueType value)
        {
            return _root.Remove(value);
        }

        public INode Find(valueType value)
        {
            return _root.Find(value);
        }
    }
}