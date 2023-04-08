using Trees.Actions;

namespace Trees
{
    class AVLNode : INode, IAVLRotations
    {
        public int Height { get; private set; }

        private INode left;
        private INode right;
        public INode Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
                UpdateHeight();
            }
        }

        public INode Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
                UpdateHeight();
            }
        }

        public IComparable Value { get; set; }

        protected INodeAction nodeFindAction;
        protected INodeAction nodeRemoveAction;
        protected INodeAction nodeAddAction;

        public AVLNode(IComparable value)
        {
            Value = value;

            nodeFindAction = new NodeFindAction(this);
            nodeRemoveAction = new NodeRemoveAction(this);
            nodeAddAction = new AVLNodeAddAction(this);
        }

        public INode RightRotate()
        {
            INode newRoot = Left;
            Left = newRoot.Right;
            newRoot.Right = this;

            return newRoot;
        }

        public INode LeftRotate()
        {
            INode newRoot = Right;
            Right = newRoot.Left;
            newRoot.Left = this;

            return newRoot;
        }

        public INode Balance()
        {
            int balance = GetBalance();
            INode node = this;
            if (balance < -1)
            {
                if (((IAVLRotations)Left).GetBalance() > 0)
                    Left = ((IAVLRotations)Left).LeftRotate();
                node = RightRotate();
            }

            else if (balance > 1)
            {
                if (((IAVLRotations)Right).GetBalance() < 0)
                    Right = ((IAVLRotations)Right).RightRotate();
                node = LeftRotate();
            }

            return node;
        }

        public int GetBalance()
        {
            return GetHeight(Right) - GetHeight(Left);
        }

        public int GetHeight(INode node)
        {
            return node == null ? -1 : (node as IHasHeight).Height;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left), GetHeight(Right)) + 1;
        }

        public virtual INode InstantCreate(IComparable value)
        {
            return new AVLNode(value);
        }

        public virtual INode Add(IComparable value)
        {
            return nodeAddAction.DoAction(value);
        }

        public virtual INode Remove(IComparable value)
        {
            return nodeRemoveAction.DoAction(value);
        }

        public virtual INode Find(IComparable value)
        {
            return nodeFindAction.DoAction(value);
        }
    }
}