namespace Trees.Actions
{
    public class NodeAddAction : INodeAction
    {
        public INode node { get; set; }

        public NodeAddAction(INode node)
        {
            this.node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (node.Value.CompareTo(value) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = node.InstantCreate(value);
                    return node.Left;
                }
                return node.Left.Add(value);
            }

            if (node.Right == null)
            {
                node.Right = node.InstantCreate(value);
                return node.Right;
            }

            return node.Right.Add(value);    
        }
    }
}