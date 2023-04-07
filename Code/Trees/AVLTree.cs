namespace Trees
{
    class AVLTree<type> : BinarySearchTree<type>
        where type : IComparable<type>
    {
        public event ITree<type>.NodeDelegate OnNodeRemoved;
        public event ITree<type>.NodeDelegate OnNodeAdded;

        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> new root </returns>
        public override INode Add(type value)
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
    }
}