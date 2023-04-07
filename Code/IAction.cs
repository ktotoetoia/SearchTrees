namespace Trees.Actions
{
    internal interface INodeAction
    {
        public INode DoAction(IComparable value);
    }

    public class NodeFindAction : INodeAction
    {
        public INode node { get; set; }

        public NodeFindAction(INode node)
        {
            this.node = node;
        }
        public INode DoAction(IComparable value)
        {
            if (node.Value.CompareTo(value) == 0)
            {
                return node;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                return node.Left == null ? null : node.Left.Find(value);
            }

            return node.Right == null ? null : node.Right.Find(value);
        }
    }

    public class NodeRemoveAction : INodeAction
    {
        public INode node { get; set; }

        public NodeRemoveAction(INode node)
        {
            this.node = node;
        }

        public INode DoAction(IComparable value)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                node.Left = node.Left.Remove(value);
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node.Right = node.Right.Remove(value);
            }
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    return (node.Left == null) ? node.Right : node.Left;
                }
                else
                {
                    INode leftMax = GetMax(node.Left);
                    node.Value = leftMax.Value;
                    node.Left = node.Left.Remove(leftMax.Value);
                }
            }

            return node;    
        }

        private INode GetMax(INode node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }
    }

    public class NodeAddAction : INodeAction
    {
        public INode node { get; set; }

        public NodeAddAction(INode node)
        {
            this.node = node;
        }

        public INode DoAction(IComparable value)
        {
            INode result = null;

            if (node.Value.CompareTo(value) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = node.InstantCreate(value);
                }
                else
                {
                    result = node.Left.Add(value);
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
                    result = node.Right.Add(value);
                }
            }


            return result;
        }
    }
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

            if (node is IHasHeight)
            {
                (node as IHasHeight).UpdateHeight();
            }

            if (node is IBalancing)
            {
                return (node as IBalancing).Balance();
            }

            return node;
        }
    }
}