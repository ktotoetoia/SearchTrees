namespace Trees.Actions
{
    public class NodeAddAction : INodeAction
    {
        public INode Node { get; set; }

        public NodeAddAction(INode node)
        {
            Node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (Node.Value.CompareTo(value) >= 0)
            {
                if (Node.Left == null)
                {
                    Node.Left = Node.InstantCreate(value);
                    return Node.Left;
                }
                return Node.Left.Add(value);
            }

            if (Node.Right == null)
            {
                Node.Right = Node.InstantCreate(value);
                return Node.Right;
            }

            return Node.Right.Add(value);    
        }
    }
}