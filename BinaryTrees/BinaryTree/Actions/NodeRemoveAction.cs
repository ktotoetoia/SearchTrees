namespace Trees.Actions
{
    public class NodeRemoveAction : INodeAction
    {
        private readonly INode _node;

        public NodeRemoveAction(INode node)
        {
            _node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (!RecursiveRemove(value))
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

        private bool RecursiveRemove(IComparable value)
        {
            if (_node.Value.CompareTo(value) == 0)
            {
                return false;
            }
            if (_node.Value.CompareTo(value) > 0)
            {
                _node.Left = _node.Left.Remove(value);
            }
            else if (_node.Value.CompareTo(value) < 0)
            {
                _node.Right = _node.Right.Remove(value);
            }

            return true;
        }

        private void RemoveLeftNode()
        {
            INode leftMax = GetMax(_node.Left);

            _node.Value = leftMax.Value;
            _node.Left = _node.Left.Remove(leftMax.Value);
        }

        private INode GetMax(INode node)
        {
            if (node.Right == null)
            {
                return node;
            }

            return GetMax(node.Right);
        }
    }
}