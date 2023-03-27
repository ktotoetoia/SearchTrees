namespace Trees
{
    class AVLTree<Comparable> : TreeBase<AVLNode>
         where Comparable : IComparable<Comparable>
    {
        public AVLNode root { get; private set; }
        public int LastKey { get; private set; }


        //this method needs to not change root node
        private void Swap(AVLNode a,AVLNode b)
        {
            (a.Key, b.Key) = (b.Key, a.Key);
            (a.Value, b.Value) = (b.Value, a.Value);
        }

        public int GetHeight(AVLNode node)
        {
            return node == null? -1 : node.Height;
        }

        public void UpdateHeight(AVLNode node)
        {
            node.Height = Math.Max(GetHeight(node.Left),GetHeight(node.Right)) + 1;
        }

        public int GetBalance(AVLNode node)
        {
            return (node == null) ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
        }

        public void RightRotate(AVLNode node)
        {
            Swap(node,node.Left);
            AVLNode buffer = node.Right;
            node.Right = node.Left;
            node.Left = node.Right.Left;
            node.Right.Left = node.Right.Right;
            node.Right.Right = buffer;

            UpdateHeight(node.Right);
            UpdateHeight(node);
        }

        public void LeftRotate(AVLNode node)
        {
            Swap(node, node.Right);
            AVLNode buffer = node.Left;
            node.Left = node.Right;
            node.Right = node.Left.Right;
            node.Right.Left = node.Right.Right;
            node.Left.Right = node.Left.Left;
            node.Left.Left = buffer;

            UpdateHeight(node.Left);
            UpdateHeight(node);
        }

        public void Balance(AVLNode node)
        {
            int balance = GetBalance(node);
            if (balance == -2)
            {
                if (GetBalance(node.Left) == 1) LeftRotate(node.Left);
                RightRotate(node);
            }
            else if (balance == 2)
            {
                if (GetBalance(node.Right) == -1) RightRotate(node.Right);
                LeftRotate(node);
            }
        }

        public void Insert(Comparable value)
        {
            AVLNode node = new AVLNode(LastKey, (IComparable)value);
            if (root == null) root = node;
            else Insert(node, root);
            LastKey++;
        }

        public override void Insert(AVLNode node, AVLNode comparableNode)
        {
            base.Insert(node, comparableNode);
            UpdateHeight(comparableNode);
            Balance(comparableNode);
        }

        public void Delete(int key)
        {
            Delete(root, key);
        }
        public AVLNode Delete(AVLNode node, int key)
        {
            if (node == null) return null;
            if (node.Key < key) node.Left = Delete(node.Left, key);
            else if (node.Key > key) node.Right = Delete(node.Right, key);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    node = (node.Left == null) ? node.Right : node.Left;
                }
                else
                {
                    AVLNode leftMax = GetMax(node.Left);
                    node.Key = leftMax.Key;
                    node.Value = leftMax.Value;
                    node.Right = Delete(node.Right, leftMax.Key);
                    node.Left = null;
                }
            }
            if (node != null)
            {
                UpdateHeight(node);
                Balance(node);
            }
            return node;
        }
    }

    class AVLNode : NodeBase<AVLNode>
    {
        public int Height { get; set; }

        public AVLNode(int key, IComparable value) : base(key, value) { }
    }
}