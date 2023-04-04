namespace Trees
{
    class Node : INode
    {
        public IComparable Value { get; set; }
        public virtual INode Left { get; set; }
        public virtual INode Right { get; set; }

        public Node(IComparable value)
        {
            Value = value;
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>

        public virtual INode Add(INode node)
        {
            INode result;

            if (node.Value.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = node;
                    result = this;
                }
                else
                {
                    result = Left.Add(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                    result = this;
                }
                else
                {
                    result = Right.Add(node);
                }
            }

            return result;
        }

        /// <summary>
        /// finding node with value, from childs of this
        /// </summary>
        /// <returns> returns node or null if node is not exist in this</returns>

        public virtual INode Find(IComparable value)
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