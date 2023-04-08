namespace Trees.Actions
{
    public class NodeRemoveAction : INodeAction
    {
        public INode Node { get; set; }

        public NodeRemoveAction(INode node)
        {
            Node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (Node.Value.CompareTo(value) > 0)
            {
                Node.Left = Node.Left.Remove(value);
            }
            else if (Node.Value.CompareTo(value) < 0)
            {
                Node.Right = Node.Right.Remove(value);
            }
            else
            {
                if (Node.Left == null || Node.Right == null)
                {
                    return Node.Left == null ? Node.Right : Node.Left;
                }
                else
                {
                    INode leftMax = GetMax(Node.Left);
                    Node.Value = leftMax.Value;
                    Node.Left = Node.Left.Remove(leftMax.Value);
                }
            }

            return Node;
        }

        private INode GetMax(INode node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }
    }
}