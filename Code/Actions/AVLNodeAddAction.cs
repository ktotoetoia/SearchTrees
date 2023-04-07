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
            if (node.Value.CompareTo(value) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = node.InstantCreate(value);
                }
                else
                {
                    node.Left = node.Left.Add(value);
                }
            }

            else
            {
                if (node.Right == null)
                {
                    node.Right = node.InstantCreate(value);
                }
                else
                {
                    node.Right = node.Right.Add(value);
                }
            }

            (node as IHasHeight)?.UpdateHeight();
            
            return (node as IBalancing)?.Balance() ?? node;
        }
    }
}