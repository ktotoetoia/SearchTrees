namespace Trees
{
    public interface INode<Node>
    {
        public IComparable Value { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    class Node : INode<Node>
    {
        public IComparable Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(IComparable value)
        {
            Value = value;
        }

        public void Add(Node node)
        {
            if (node.Value.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = node;
                    return;
                }
                Left.Add(node);
                return;
            }

            if (Right == null)
            {
                Right = node;
                return;
            }

            Right.Add(node);
        }

        public Node Find(IComparable value)
        {
            if (Value.CompareTo(value) == 0)
            {
                return this;
            }

            if (Value.CompareTo(value) > 0)
            {
                return Left == null ? null : Left.Find(value);
            }

            return Right == null ? null : Right.Find(value);
        }
    }
}