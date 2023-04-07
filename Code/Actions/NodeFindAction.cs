namespace Trees.Actions
{
    public class NodeFindAction : INodeAction
    {
        public INode node { get; set; }

        public NodeFindAction(INode node)
        {
            this.node = node;
        }
        public INode DoAction(IComparable value)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return node.Left == null ? null : node.Left.Find(value);
            }

            return node.Right == null ? null : node.Right.Find(value);
        }
    }
}