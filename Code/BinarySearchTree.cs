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

    public interface INode<N>
    {
        public IComparable Value { get; set; }

        public N Left { get; set; }
        public N Right { get; set; }
    }

    class Node : INode<Node>
    {
        public IComparable Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node( IComparable value)
        {
            Value = value;
        }
    }

    class BinarySearchTree<type> : ITree<type,Node>, ITreeVizualizer
         where type : IComparable<type>
    {
        public Node root { get; set; }
        
        public event ITree<type,Node>.NodeDelegate OnNodeRemoved;
        public event ITree<type,Node>.NodeDelegate OnNodeAdded;

        protected void Add(Node node, Node comparableNode)
        {
            if (node.Value.CompareTo(comparableNode.Value) >= 1)
            {
                if (comparableNode.Right == null)
                    comparableNode.Right = node;
                else
                    Add(node, comparableNode.Right);
            }
            else if (node.Value.CompareTo(comparableNode.Value) < 1)
            {
                if (comparableNode.Left == null)
                    comparableNode.Left = node;
                else
                    Add(node, comparableNode.Left);
            }
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

        protected Node Find(type value, Node currentNode)
        {
            if (currentNode == null) return null;
            if (currentNode.Value == (IComparable)value) return currentNode;
            return currentNode.Value.CompareTo(value) > 1 ? Find(value, currentNode.Left) : Find(value, currentNode.Right);
        }

        protected Node Delete(type value, Node node)
        {
            if (node == null) return null;

            if (node.Value.CompareTo((IComparable)value)>0) node.Left = Delete(value,node.Left);
            else if (node.Value.CompareTo((IComparable)value) < 0) node.Right = Delete(value,node.Right);
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
                    node.Right = Delete(value,node.Right);
                    node.Left = null;
                }
                OnNodeRemoved?.Invoke(node);
            }

            return node;
        }

        public Node Remove(type value)
        {
            return Delete(value, root);
        }

        public Node Find(type value)
        {
            return Find(value,root);
        }

        public void Add(type value)
        {
            Node node = new Node((IComparable)value);
            if (root == null) root = node;
            else Add(node, root);
        }



        protected void PrintTree(Node node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        private void PrintTreePaths(Node node)
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