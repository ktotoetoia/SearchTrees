namespace Trees
{
    public class AVLTree<valueType> : ITree<valueType>
        where valueType : IComparable<valueType>
    {
        public INode Root { get; set; }

        public event INodeEvents.NodeDelegate OnNodeRemoved;
        public event INodeEvents.NodeDelegate OnNodeAdded;

        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> added node </returns>
        public INode Add(valueType value)
        {
            INode addedNode;
            if (Root != null)
            {
                addedNode = Root.Add((IComparable)value);
                Root = ((IBalancing)Root).Balance();
            }

            else
            {
                addedNode = new AVLNode((IComparable)value);
                Root = addedNode;
            }

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        public INode Remove(valueType value)
        {
            INode result = Root.Remove((IComparable)value);
            OnNodeRemoved?.Invoke(result);
            return result;
        }

        public INode Find(valueType value)
        {
            return Root.Find((IComparable)value);
        }
    }
}