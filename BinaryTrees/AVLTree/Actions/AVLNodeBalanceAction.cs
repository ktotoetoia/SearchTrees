namespace Trees.Actions
{
    public class AVLNodeBalanceAction : IBalanceAction
    {
        private readonly IAVLNode _node;

        public AVLNodeBalanceAction(IAVLNode node)
        {
            _node = node;
        }

        public INode DoAction()
        {
            IAVLNode node = _node;
            int balance = _node.GetBalance();

            if (balance < -1)
            {
                node = (IAVLNode)node.RightRotate();
            }

            else if (balance > 1)
            {
                node = (IAVLNode)node.LeftRotate();
            }

            return node;
        }
    }
}