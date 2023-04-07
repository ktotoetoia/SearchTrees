namespace Trees
{
    class AVLTree<type> : ITree<type>
        where type : IComparable<type>
    {
        public INode root { get; set; }

        public event ITree<type>.NodeDelegate OnNodeRemoved;
        public event ITree<type>.NodeDelegate OnNodeAdded;

        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> new root </returns>
        public INode Add(type value)
        {
            INode addedNode = null;
            if (root != null)
            {
                addedNode = root.Add((IComparable)value);
            }

            else
            {
                addedNode = new AVLNode((IComparable)value);
            }

            root = addedNode;

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        /// <summary>
        /// remove first node with same value
        /// </summary>
        /// <returns> node that replaced the removed node</returns>
        public INode Remove(type value)
        {
            INode result = root.Remove((IComparable)value);
            OnNodeRemoved?.Invoke(result);
            return result;
        }

        /// <returns> returns node or null if node is not exist </returns>
        public INode Find(type value)
        {
            return root.Find((IComparable)value);
        }
    }
}