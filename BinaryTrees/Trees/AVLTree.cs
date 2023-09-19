namespace Trees
{
    public class AVLTree<valueType> : ITree<valueType>
        where valueType : IComparable
    {
        private INodeFactory _nodeFactory;

        public INode Root { get; set; }

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