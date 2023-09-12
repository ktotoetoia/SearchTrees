namespace Trees.Actions
{
    public class NodeRemoveAction : INodeAction
    {
        protected INode _node;

        public NodeRemoveAction(INode node)
        {
            _node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (_node.Value.CompareTo(value) > 0)
            {
                _node.Left = _node.Left.Remove(value);
            }
         
            else if (_node.Value.CompareTo(value) < 0)
            {
                _node.Right = _node.Right.Remove(value);
            }
            
            else
            {
                if (_node.Left == null || _node.Right == null)
                {
                    return _node.Left ?? _node.Right;
                }

                else
                {
                    RemoveLeftNode();
                }
            }

            return _node;
        }

        private void RemoveLeftNode()
        {
            INode leftMax = GetMax(_node.Left);
            _node.Value = leftMax.Value;
            _node.Left = _node.Left.Remove(leftMax.Value);
        }

        private INode GetMax(INode node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }
    }
}