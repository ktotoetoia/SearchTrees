namespace Trees
{
    public interface ITree<type, nodeType>
        where type : IComparable<type>
        where nodeType : INode<nodeType>
    {
        public nodeType root { get; set; }
        
        public delegate void NodeDelegate(nodeType node);
        public event NodeDelegate OnNodeRemoved;
        public event NodeDelegate OnNodeAdded;

        public void Add(type value);

        public nodeType Remove(type value);

        public nodeType Find(type value);
    }

    public interface ITreeVizualizer
    {
        public void PrintTree();
        public void PrintTreePaths();
    }

    class BinarySearchTree<type> : ITree<type,Node>, ITreeVizualizer
         where type : IComparable<type>
    {
        public Node root { get; set; }
        
        public event ITree<type,Node>.NodeDelegate OnNodeRemoved;
        public event ITree<type,Node>.NodeDelegate OnNodeAdded;

        protected void Add(Node node)
        {
            root.Add(node);
        }

        protected Node GetMin(Node node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;
            return GetMin(node.Left);
        }

        protected Node GetMax(Node node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }

        protected Node Remove(type value, Node node)
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
                    Node leftMax = GetMax(node.Left);
                    node.Value = leftMax.Value;
                    node.Right = Remove(value, node.Right);
                    node.Left = null;
                }
                OnNodeRemoved?.Invoke(node);
            }
            
            return node;
        }
        
        public Node Remove(type value)
        {
            return Remove(value, root);
        }

        public Node Find(type value)
        {
            return root.Find((IComparable)value);
        }

        public void Add(type value)
        {
            Node node = new Node((IComparable)value);
            if (root == null) root = node;
            else Add(node);
        }

        protected void PrintTree(Node node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        protected void PrintTreePaths(Node node)
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

        public void PrintTree()
        {
            PrintTree(root);
        }
        
        public void PrintTreePaths()
        {
            PrintTreePaths(root);
        }
    }
}