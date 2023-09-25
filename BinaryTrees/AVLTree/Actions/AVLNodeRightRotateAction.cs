namespace Trees.Actions
{
    public class AVLNodeRightRotateAction : IBalanceAction
    {
        private readonly IAVLNode _node;

        public AVLNodeRightRotateAction(IAVLNode node)
        {
            _node = node;
        }

        public INode DoAction()
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
    }
}