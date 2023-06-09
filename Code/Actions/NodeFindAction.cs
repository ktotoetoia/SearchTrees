namespace Trees.Actions
{
    public class NodeFindAction : INodeAction
    {
        public INode Node { get; set; }

        public NodeFindAction(INode node)
        {
            Node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (Node.Value.CompareTo(value) == 0)
            {
                return Node;
            }

            if (Node.Value.CompareTo(value) > 0)
            {
                return Node.Left?.Find(value);
            }
            
            return Node.Right?.Find(value);
        }
    }
}