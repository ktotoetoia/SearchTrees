namespace Trees
{
    class BinarySearchTree<type> : ITree<type>, ITreeVizualizer
         where type : IComparable<type>
    {
        public INode root { get; set; }
        
        public event ITree<type>.NodeDelegate OnNodeRemoved;
        public event ITree<type>.NodeDelegate OnNodeAdded;

        protected INode GetMin(INode node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;
            return GetMin(node.Left);
        }

        protected INode GetMax(INode node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }

        protected virtual INode Add(INode node)
        {
            INode n = root.Add(node);
            OnNodeAdded?.Invoke(n);
            return n;
        }

        protected virtual INode Remove(type value, INode node)
        {
            if (node.Value.CompareTo((IComparable)value) > 0)
            {
                node.Left = Remove(value, node.Left);
            }
            else if (node.Value.CompareTo((IComparable)value) < 0)
            {
                node.Right = Remove(value, node.Right);
            }
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    node = (node.Left == null) ? node.Right : node.Left;
                }
                else
                {
                    INode leftMax = GetMax(node.Left);
                    node.Value = leftMax.Value;
                    node.Right = Remove(value, node.Right);
                    node.Left = null;
                }
                OnNodeRemoved?.Invoke(node);
            }
            
            return node;
        }

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> parent of added node </returns>

        public virtual INode Add(type value)
        {
            Node node = new Node((IComparable)value);
            if (root == null)
            {
                root = node;
                return root;
            }
            return Add(node);
        }

        /// <summary>
        /// remove first node with same value
        /// </summary>
        /// <returns> node that replaced the removed node</returns>
        public INode Remove(type value)
        {
            return Remove(value, root);
        }

        /// <returns> returns node or null if node is not exist </returns>

        public INode Find(type value)
        {
            return root.Find((IComparable)value);
        }
        
        protected virtual void PrintTree(INode node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        protected virtual void PrintTreePaths(INode node)
        {
            if (node == null) return;
            if (node.Left != null)
            {
                Console.WriteLine(node.Value + " > " + node.Left.Value);
            }
            if (node.Right != null)
            {
                Console.WriteLine(node.Value + " < " + node.Right.Value);
            }
            PrintTreePaths(node.Left);
            PrintTreePaths(node.Right);
        }

        /// <summary>
        /// prints tree in ascending order
        /// </summary>
        public void PrintTree()
        {
            PrintTree(root);
        }
        
        /// <summary>
        /// prints right and left value of every node
        /// </summary>
        public void PrintTreePaths()
        {
            PrintTreePaths(root);
        }

        public void PrintAllBalance(INode n)
        {
            if(n==null) return;

            AVLNode a = (AVLNode)n;
            Console.WriteLine(a.GetHeight(a.Right)-a.GetHeight(a.Left));

            PrintAllBalance(n.Left);
            PrintAllBalance(n.Right);
        }
    }
}