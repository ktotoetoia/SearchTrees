namespace Trees
{
    class Node : INode
    {
        public IComparable Value { get; set; }
        public virtual INode Left { get; set; }
        public virtual INode Right { get; set; }

        protected INodeAction nodeFindAction;
        protected INodeAction nodeRemoveAction;
        protected INodeAction nodeAddAction;
        public Node(IComparable value)
        {
            Value = value;
            nodeFindAction = new NodeFindAction(this);
            nodeRemoveAction = new NodeRemoveAction(this);
            nodeAddAction = new NodeAddAction(this);
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>
        public virtual INode Add(INode node)
        {
            return nodeAddAction.DoAction(node.Value);
        }


        public virtual INode Remove(IComparable value)
        {
            return nodeRemoveAction.DoAction(value);
        }

        /// <summary>
        /// finding node with value, from childs of this
        /// </summary>
        /// <returns> returns node or null if node is not exist in this</returns>
        public INode Find(IComparable value)
        {
            return nodeFindAction.DoAction(value);
        }

        public INode InstantCreate(IComparable value)
        {
            Node node = new Node(value);
            return node;
        }
    }
}