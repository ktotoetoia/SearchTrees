namespace Trees.Actions
{
    public class NodeRemoveAction : INodeAction
    {
        public INode node { get; set; }

        public NodeRemoveAction(INode node)
        {
            this.node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                node.Left = node.Left.Remove(value);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = node.Right.Remove(value);
            }
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    return node.Left == null ? node.Right : node.Left;
                }
                else
                {
                    INode leftMax = GetMax(node.Left);
                    node.Value = leftMax.Value;
                    node.Left = node.Left.Remove(leftMax.Value);
                }
            }

            return node;
        }

        private INode GetMax(INode node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }
    }
}