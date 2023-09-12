namespace Trees.Actions
{
    public class AVLNodeAddAction : NodeAddAction
    {
        public AVLNodeAddAction(INode node, INodeFactory nodeFactory) 
            : base(node, nodeFactory) { }

        protected override INode AddToLeftNode(IComparable value)
        {
            if (_node.Left == null)
            {
                return _node.Left = _nodeFactory.Create(value);
            }

            INode result = _node.Left.Add(value);

            _node.Left = UpdateBalance(_node.Left);
            
            return result;
        }

        protected override INode AddToRightNode(IComparable value)
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