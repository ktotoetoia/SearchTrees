namespace Trees
{
    class AVLTree<Comparable> : TreeBase<AVLNode>
         where Comparable : IComparable<Comparable>
    {
        public AVLNode root { get; private set; }
        public int LastKey { get; private set; }

        public AVLTree()
        {
            OnNodeDeleted += UpdateNode;
        }

        //this method needs to not change root node
        private void Swap(AVLNode a,AVLNode b)
        {
            (a.Key, b.Key) = (b.Key, a.Key);
            (a.Value, b.Value) = (b.Value, a.Value);
        }

        private AVLNode Search(AVLNode node, Comparable value)
        {
            if (node == null) return null;
            if (node.Value.CompareTo(value) == 0) return node;
            return node.Value.CompareTo(value) > 0 ? Search(node.Left, value) : Search(node.Right, value);
        }

        private int GetHeight(AVLNode node)
        {
            return node == null? -1 : node.Height;
        }

        private void UpdateHeight(AVLNode node)
        {
            node.Height = Math.Max(GetHeight(node.Left),GetHeight(node.Right)) + 1;
        }

        private void UpdateNode(AVLNode node)
        {
            if (node != null)
            {
                UpdateHeight(node);
                Balance(node);
            }
        }

        private int GetBalance(AVLNode node)
        {
            return (node == null) ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
        }

        private void RightRotate(AVLNode node)
        {
            Swap(node, node.Left);
            AVLNode buffer = node.Right;
            node.Right = node.Left;
            node.Left = node.Right.Left;
            node.Right.Left = node.Right.Right;
            node.Right.Right = buffer;

            UpdateHeight(node.Right);
            UpdateHeight(node);
        }

        private void LeftRotate(AVLNode node)
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

        public AVLNode Search(Comparable value)
        {
            return Search(root, value);
        }

        public void Delete(int key)
        {
            Delete(root, key);
        }

        public AVLNode Delete(Comparable value)
        {
            return Delete(root, Search(value).Key);
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
    }

    class AVLNode : NodeBase<AVLNode>
    {
        public int Height { get; set; }

        public AVLNode(int key, IComparable value) : base(key, value) { }
    }
}