using Trees.Actions;

namespace Trees
{
    class Node : INode
    {
        public IComparable Value { get; set; }
        public virtual INode Left { get; set; }
        public virtual INode Right { get; set; }

        protected INodeAction nodeFindAction;
        protected INodeAction nodeRemoveAction;
        protected INodeAction nodeAddAction;

        public Node(IComparable value)
        {
            Value = value;
            nodeFindAction = new NodeFindAction(this);
            nodeRemoveAction = new NodeRemoveAction(this);
            nodeAddAction = new NodeAddAction(this);
        }

        /// <summary>
        /// create node of this class
        /// </summary>
        /// <returns>node of this class</returns>
        public INode InstantCreate(IComparable value)
        {
            Node node = new Node(value);
            return node;
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>
        public virtual INode Add(IComparable value)
        {
            return nodeAddAction.DoAction(value);
        }
        /// <summary>
        /// removes node from child of this
        /// </summary>
        /// <param name="value"></param>
        /// <returns>node that chenged removed</returns>

        public virtual INode Remove(IComparable value)
        {
            return nodeRemoveAction.DoAction(value);
        }

        /// <summary>
        /// finding node with value, from childs of this
        /// </summary>
        /// <returns> returns node or null if node is not exist in this</returns>
        public virtual INode Find(IComparable value)
        {
            return nodeFindAction.DoAction(value);
        }
    }
}