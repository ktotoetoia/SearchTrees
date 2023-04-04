namespace Trees
{
    class AVLTree<type> : BinarySearchTree<type>
        where type : IComparable<type>
    {
        protected int GetBalance(INode node)
        {
            return (node == null) ? 0 : (node as AVLNode).GetBalance();
        }

        protected INode RightRotate(INode node)
        {
            INode newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;

            (node as AVLNode).UpdateHeight();
            (newRoot as AVLNode).UpdateHeight();

            return newRoot;
        }

        protected INode LeftRotate(INode node)
        {
            INode newRoot = node.Right;
            node.Right = newRoot.Left;
            newRoot.Left = node;

            (node as AVLNode).UpdateHeight();
            (newRoot as AVLNode).UpdateHeight();
            return newRoot;
        }

        /// <summary>
        /// balancing whole path from current to node
        /// </summary>
        /// <param name="node"> end</param>
        /// <param name="current"> start</param>
        public INode RecursiveBalance(INode node, INode current)
        {
            if (node == null || current == null) return null;

            if (current.Value.CompareTo(node.Value) > 0)
            {
                current.Left = RecursiveBalance(node, current.Left);
            }

            else
            {
                current.Right = RecursiveBalance(node, current.Right);
            }

            return Balance(current);
        }

        protected INode Balance(INode node)
        {
            (node as AVLNode).UpdateHeight();

            int balance = GetBalance(node);
            if(node.Value.CompareTo(2)==0)
            {
                
            }
            if (balance < -1)
            {
                if (GetBalance(node.Left) > 0) 
                    node.Left = LeftRotate(node.Left);
                node = RightRotate(node);
            }

            else if (balance > 1)
            {
                if (GetBalance(node.Right) < 0) 
                    node.Right = RightRotate(node.Right);
                node = LeftRotate(node);
            }

            return node;
        }

        protected override INode Add(INode node)
        {
            INode n = base.Add(node);

            root = RecursiveBalance(node, root);
            return n;
        }

        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> parent of added node </returns>
        public override INode Add(type value)
        {
            AVLNode node = new AVLNode((IComparable)value);
            if (root == null)
            {
                root = node;
                return root;
            }
            return Add(node);
        }
    }
}