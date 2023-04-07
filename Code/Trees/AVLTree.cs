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
        /// <returns> added node </returns>
        public INode Add(type value)
        {
            INode addedNode = null;
            if (root != null)
            {
                addedNode = root.Add((IComparable)value);
                (root as IHasHeight).UpdateHeight();
                root = (root as IBalancing).Balance();
            }

            else
            {
                addedNode = new AVLNode((IComparable)value);
                root = addedNode;
            }

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        public INode Remove(type value)
        {
            INode result = root.Remove((IComparable)value);
            OnNodeRemoved?.Invoke(result);
            return result;
        }

        public INode Find(type value)
        {
            return root.Find((IComparable)value);
        }
    }
}