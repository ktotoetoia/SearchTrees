namespace Trees.Actions
{
    public class AVLNodeAddAction : INodeAction
    {
        public INode node { get; set; }

        public AVLNodeAddAction(INode node)
        {
            this.node = node;
        }
        
        public INode DoAction(IComparable value)
        {
            INode result = node;
            if (node.Value.CompareTo(value) >= 0)
            {
                if (node.Left == null)
                {
                    return node.Left = node.InstantCreate(value);
                }

                result = node.Left.Add(value);
                node.Left = UpdateBalance(node.Left);
                return result;
            }

            if (node.Right == null)
            {
                return node.Right = node.InstantCreate(value);
            }

            result = node.Right.Add(value);
            node.Right = UpdateBalance(node.Right);
            return result;
        }

        public INode UpdateBalance(INode noda)
        {
            (noda as IHasHeight).UpdateHeight();
            return  (noda as IBalancing).Balance();
        }
    }
}