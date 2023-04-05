namespace Trees
{
    class AVLNode : INode
    {
        public int Height { get; private set; }

        public INode Left { get; set; }
        public INode Right { get; set; }

        public IComparable Value { get; set; }
        public AVLNode(IComparable value)
        {
            Value= value;
        }

        public int GetBalance()
        {
            return GetHeight(Right) - GetHeight(Left);
        }

        public int GetHeight(INode node)
        {
            return node == null ? -1: (node as AVLNode).Height;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left),GetHeight(Right))+1;
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>
        public INode Add(INode node)
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
                    Left =  Left.Add(node);
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
                    Right = Right.Add(node);
                }
            }
            UpdateHeight();
            return Balance();
        }

        protected INode RightRotate()
        {
            INode newRoot = Left;
            Left = newRoot.Right;
            newRoot.Right = this;

            UpdateHeight();
            (newRoot as AVLNode).UpdateHeight();

            return newRoot;
        }

        protected INode LeftRotate()
        {
            INode newRoot = Right;
            Right = newRoot.Left;
            newRoot.Left = this;

            UpdateHeight();
            (newRoot as AVLNode).UpdateHeight();
            return newRoot;
        }
        protected INode Balance()
        {
            UpdateHeight();

            int balance = GetBalance();
            INode node = this;
            if (balance < -1)
            {
                if (((AVLNode)Left).GetBalance() > 0)
                    Left = ((AVLNode)Left).LeftRotate();
                node = RightRotate();
            }

            else if (balance > 1)
            {
                if (((AVLNode)Right).GetBalance() < 0)
                    Right = ((AVLNode)Right).RightRotate();
                node = LeftRotate();
            }

            return node;
        }
        public INode Find(IComparable value)
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