using Trees.Actions;

namespace Trees
{
    public class Node : INode
    {
        private INodeFactory _nodeFactory = new BinaryNodeFactory();
        private INodeAction _findAction;
        private INodeAction _removeAction;
        private INodeAction _addAction;

        public IComparable Value { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }

        public Node(IComparable value)
        {
            Value = value;

            _findAction = new NodeFindAction(this);
            _removeAction = new NodeRemoveAction(this);
            _addAction = new NodeAddAction(this, _nodeFactory);
        }

        public INode Add(IComparable value)
        {
            return _addAction.DoAction(value);
        }

        public INode Remove(IComparable value)
        {
            return _removeAction.DoAction(value);
        }

        public INode Find(IComparable value)
        {
            return _findAction.DoAction(value);
        }
    }
}