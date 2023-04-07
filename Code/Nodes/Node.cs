using Trees.Actions;

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

        public INode InstantCreate(IComparable value)
        {
            return new Node(value);
        }

        public virtual INode Add(IComparable value)
        {
            return nodeAddAction.DoAction(value);
        }

        public virtual INode Remove(IComparable value)
        {
            return nodeRemoveAction.DoAction(value);
        }

        public virtual INode Find(IComparable value)
        {
            return nodeFindAction.DoAction(value);
        }
    }
}