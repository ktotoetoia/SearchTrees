namespace Trees.Actions
{
    public class AVLNodeAddAction : INodeAction
    {
        private readonly INodeFactory _nodeFactory;
        private readonly IAVLNode _node;

        public AVLNodeAddAction(IAVLNode node, INodeFactory nodeFactory)
        {
            _node = node;
            _nodeFactory = nodeFactory;
        }

        public INode DoAction(IComparable value)
        {
            if (_node.Value.CompareTo(value) >= 0)
            {
                return AddToLeftNode(value);
            }

            return AddToRightNode(value);
        }

        private INode AddToLeftNode(IComparable value)
        {
            if (_node.Left == null)
            {
                return _node.Left = _nodeFactory.Create(value);
            }

            INode result = _node.Left.Add(value);

            _node.Left = ((IBalancing)_node.Left).Balance();

            return result;
        }

        private INode AddToRightNode(IComparable value)
        {
            if (_node.Right == null)
            {
                return _node.Right = _nodeFactory.Create(value);
            }

            INode result = _node.Right.Add(value);

            _node.Right = ((IBalancing)_node.Right).Balance();

            return result;
        }
    }
}