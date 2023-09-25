namespace Trees.Actions
{
    public class AVLNodeLeftRotateAction : IBalanceAction
    {
        private readonly IAVLNode _node;

        public AVLNodeLeftRotateAction(IAVLNode node)
        {
            _node = node;
        }

        public INode DoAction()
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