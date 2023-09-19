using Trees.Actions;

namespace Trees
{
    public class Node : INode
    {
        protected INodeFactory _nodeFactory = new BinaryNodeFactory();
        protected INodeAction _nodeFindAction;
        protected INodeAction _nodeRemoveAction;
        protected INodeAction _nodeAddAction;

        public IComparable Value { get; set; }
        public virtual INode Left { get; set; }
        public virtual INode Right { get; set; }

        public Node(IComparable value)
        {
            Value = value;

            _nodeFindAction = new NodeFindAction(this);
            _nodeRemoveAction = new NodeRemoveAction(this);
            _nodeAddAction = new NodeAddAction(this, _nodeFactory);
        }

        public virtual INode Add(IComparable value)
        {
            return _nodeAddAction.DoAction(value);
        }

        public virtual INode Remove(IComparable value)
        {
            return _nodeRemoveAction.DoAction(value);
        }

        public virtual INode Find(IComparable value)
        {
            return _nodeFindAction.DoAction(value);
        }
    }
}