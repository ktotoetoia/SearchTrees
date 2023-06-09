namespace Trees
{
    public class BinarySearchTree<type> : ITree<type>
        where type : IComparable<type>
    {
        public INode Root { get; set; }

        public event INodeEvents.NodeDelegate OnNodeRemoved;
        public event INodeEvents.NodeDelegate OnNodeAdded;

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(type value)
        {
            INode addedNode;
            if (Root != null)
            {
                addedNode = Root.Add((IComparable)value);
            }

            else
            {
                Root = new Node((IComparable)value);
                addedNode = Root;
            }

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        public INode Remove(type value)
        {
            INode result = Root.Remove((IComparable)value);
            OnNodeRemoved?.Invoke(result);
            return result;
        }

        public INode Find(type value)
        {
            return Root.Find((IComparable)value);
        }
    }
}