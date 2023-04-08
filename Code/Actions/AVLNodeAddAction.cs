namespace Trees.Actions
{
    public class AVLNodeAddAction : INodeAction
    {
        public INode Node { get; set; }

        public AVLNodeAddAction(INode node)
        {
            Node = node;
        }
        
        public INode DoAction(IComparable value)
        {
            INode result;
            if (Node.Value.CompareTo(value) >= 0)
            {
                if (Node.Left == null)
                {
                    return Node.Left = Node.InstantCreate(value);
                }

                result = Node.Left.Add(value);
                Node.Left = UpdateBalance(Node.Left);
                return result;
            }

            if (Node.Right == null)
            {
                return Node.Right = Node.InstantCreate(value);
            }

            result = Node.Right.Add(value);
            Node.Right = UpdateBalance(Node.Right);
            return result;
        }

        public INode UpdateBalance(INode node)
        {
            return  (node as IBalancing).Balance();
        }
    }
}