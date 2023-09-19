namespace Trees.Actions
{
    public class AVLNodeBalanceAction
    {
        private readonly IAVLNode _node;

        public AVLNodeBalanceAction(IAVLNode node)
        {
            _node = node;
        }

        public INode Balance()
        {
            INode node = _node;
            int balance = _node.GetBalance();

            if (balance < -1)
            {
                node = RightRotate();
            }

            else if (balance > 1)
            {
                node = LeftRotate();
            }

            return node;
        }

        public INode RightRotate()
        {
            if (((IAVLRotations)_node.Left).GetBalance() > 0)
            {
                _node.Left = ((IAVLRotations)_node.Left).LeftRotate();
            }

            INode newRoot = _node.Left;
            _node.Left = newRoot.Right;
            newRoot.Right = _node;

            return newRoot;
        }

        public INode LeftRotate()
        {
            if (((IAVLRotations)_node.Right).GetBalance() < 0)
            {
                _node.Right = ((IAVLRotations)_node.Right).RightRotate();
            }

            INode newRoot = _node.Right;
            _node.Right = newRoot.Left;
            newRoot.Left = _node;

            return newRoot;
        }
    }
}