using Trees.Actions;

namespace Trees
{
    public class AVLNode : INode, IAVLRotations
    {
        private INodeFactory _nodeFactory = new AVLNodeFactory();
        private INode _left;
        private INode _right;
        protected AVLNodeBalanceAction _nodeBalanceAction;
        protected INodeAction _nodeFindAction;
        protected INodeAction _nodeRemoveAction;
        protected INodeAction _nodeAddAction;

        public INode Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
                UpdateHeight();
            }
        }

        public INode Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
                UpdateHeight();
            }
        }

        public IComparable Value { get; set; }
        public int Height { get; set; }

        public AVLNode(IComparable value)
        {
            Value = value;

            _nodeFindAction = new NodeFindAction(this);
            _nodeRemoveAction = new NodeRemoveAction(this);
            _nodeAddAction = new AVLNodeAddAction(this,_nodeFactory);
            _nodeBalanceAction = new AVLNodeBalanceAction(this);
        }

        public INode Balance()
        {
            return _nodeBalanceAction.Balance();
        }

        public INode RightRotate()
        {
            return _nodeBalanceAction.RightRotate();
        }

        public INode LeftRotate()
        {
            return _nodeBalanceAction.LeftRotate();
        }

        public int GetBalance()
        {
            return GetHeight(Right) - GetHeight(Left);
        }

        public int GetHeight(INode node)
        {
            return node == null ? -1 : ((IHasHeight)node).Height;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left), GetHeight(Right)) + 1;
        }

        public virtual INode Add(IComparable value)
        {
            return _nodeAddAction.DoAction(value);
        }

        public virtual INode Remove(IComparable value)
        {
            return _nodeRemoveAction.DoAction(value);
        }

        public virtual INode Find(IComparable value)
        {
            return _nodeFindAction.DoAction(value);
        }
    }
}