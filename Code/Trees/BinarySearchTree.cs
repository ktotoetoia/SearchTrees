namespace Trees
{
    class BinarySearchTree<type> : ITree<type>
        where type : IComparable<type>
    {
        public INode root { get; set; }

        public event ITree<type>.NodeDelegate OnNodeRemoved;
        public event ITree<type>.NodeDelegate OnNodeAdded;

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(type value)
        {
            INode addedNode = null;
            if (root != null)
            {
                addedNode = root.Add((IComparable)value);
            }

            else
            {
                root = new Node((IComparable)value);
                addedNode = root;
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