using Trees.Actions;

namespace Trees
{
    public class AVLNode : IAVLNode
    {
        private INodeFactory _nodeFactory = new AVLNodeFactory();
        private INode _left;
        private INode _right;
        private IBalanceAction _balanceAction;
        private IBalanceAction _rightRotate;
        private IBalanceAction _leftRotate;
        private INodeAction _findAction;
        private INodeAction _removeAction;
        private INodeAction _addAction;

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

            InitializeActions();
        }

        private void InitializeActions()
        {
            _findAction = new NodeFindAction(this);
            _removeAction = new NodeRemoveAction(this);
            _addAction = new AVLNodeAddAction(this, _nodeFactory);
            _balanceAction = new AVLNodeBalanceAction(this);
            _rightRotate = new AVLNodeRightRotateAction(this);
            _leftRotate = new AVLNodeLeftRotateAction(this);
        }

        public INode Balance()
        {
            return _balanceAction.DoAction();
        }

        public INode RightRotate()
        {
            return _rightRotate.DoAction();
        }

        public INode LeftRotate()
        {
            return _leftRotate.DoAction();
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

        public INode Add(IComparable value)
        {
            return _addAction.DoAction(value);
        }

        public INode Remove(IComparable value)
        {
            return _removeAction.DoAction(value);
        }

        public INode Find(IComparable value)
        {
            return _findAction.DoAction(value);
        }
    }
}