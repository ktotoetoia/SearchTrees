namespace Trees.Actions
{
    public class AVLNodeAddAction : NodeAddAction
    {
        public AVLNodeAddAction(INode node) : base(node) { }
        
        protected override INode AddToLeftNode(IComparable value)
        {
            if (Node.Left == null)
            {
                return Node.Left = Node.InstantCreate(value);
            }

            INode result = Node.Left.Add(value);
            Node.Left = UpdateBalance(Node.Left);
            
            return result;
        }

        protected override INode AddToRightNode(IComparable value)
        {
            if (Node.Right == null)
            {
                return Node.Right = Node.InstantCreate(value);
            }

            INode result = Node.Right.Add(value);
            Node.Right = UpdateBalance(Node.Right);
            
            return result;
        }

        private INode UpdateBalance(INode node)
        {
            return  (node as IBalancing).Balance();
        }
    }
}