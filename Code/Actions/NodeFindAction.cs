namespace Trees.Actions
{
    public class NodeFindAction : INodeAction
    {
        protected INode _node;

        public NodeFindAction(INode node)
        {
            _node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (_node.Value.CompareTo(value) == 0)
            {
                return _node;
            }

            if (_node.Value.CompareTo(value) > 0)
            {
                return _node.Left?.Find(value);
            }
            
            return _node.Right?.Find(value);
        }
    }
}