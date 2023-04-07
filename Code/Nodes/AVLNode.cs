using Trees.Actions;

namespace Trees
{
    class AVLNode : INode, IAVLRotations
    {
        public int Height { get; private set; }

        public INode Left { get; set; }
        public INode Right { get; set; }

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

            UpdateHeight();
            (newRoot as IHasHeight)?.UpdateHeight();

            return newRoot;
        }

        public INode LeftRotate()
        {
            INode newRoot = Right;
            Right = newRoot.Left;
            newRoot.Left = this;

            UpdateHeight();
            (newRoot as IHasHeight)?.UpdateHeight();
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

        /// <summary>
        /// create node of this class
        /// </summary>
        /// <returns>node of this class</returns>
        public INode InstantCreate(IComparable value)
        {
            return new AVLNode(value);
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>
        public INode Add(IComparable value)
        {
            return nodeAddAction.DoAction(value);
        }

        /// <summary>
        /// removes node from child of this
        /// </summary>
        /// <returns>node that chenged removed</returns>
        public virtual INode Remove(IComparable value)
        {
            return nodeRemoveAction.DoAction(value);
        }

        /// <summary>
        /// finding node with value, from childs of this
        /// </summary>
        /// <returns> returns node or null if node is not exist in this</returns>
        public INode Find(IComparable value)
        {
            return nodeFindAction.DoAction(value);
        }
    }
}