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
                return AddToLeftNode(value);
            }

            return AddToRightNode(value);
        }

        protected virtual INode AddToLeftNode(IComparable value)
        {
            if (Node.Left == null)
            {
                Node.Left = Node.InstantCreate(value);
                return Node.Left;
            }

            return Node.Left.Add(value);
        }

        protected virtual INode AddToRightNode(IComparable value)
        {
            if (Node.Right == null)
            {
                Node.Right = Node.InstantCreate(value);
                return Node.Right;
            }

            return Node.Right.Add(value);
        }
    }
}