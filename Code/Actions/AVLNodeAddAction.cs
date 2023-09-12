namespace Trees.Actions
{
    public class AVLNodeAddAction : INodeAction
    {
        private readonly INodeFactory _nodeFactory;
        private readonly INode _node;

        public AVLNodeAddAction(INode node, INodeFactory nodeFactory) 
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

            _node.Left = UpdateBalance(_node.Left);
            
            return result;
        }

        private INode AddToRightNode(IComparable value)
        {
            if (_node.Right == null)
            {
                return _node.Right = _nodeFactory.Create(value);
            }

            INode result = _node.Right.Add(value);

            _node.Right = UpdateBalance(_node.Right);
            
            return result;
        }

        private INode UpdateBalance(INode node)
        {
            return ((IBalancing)node).Balance();
        }
    }
}