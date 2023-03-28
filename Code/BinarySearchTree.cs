using System;

namespace Trees
{
    abstract class TreeBase<Node> where Node : NodeBase<Node>
    {
        public Node root { get; protected set; }
        public int LastKey { get; protected set; }

        public delegate void NodeDelegate(Node node);
        public event NodeDelegate OnNodeDeleted;

        public virtual void Insert(Node node, Node comparableNode)
        {

            if (node.Value.CompareTo(comparableNode.Value) >= 1)
            {
                if (comparableNode.Right == null)
                    comparableNode.Right = node;
                else
                    Insert(node, comparableNode.Right);
            }
            else if (node.Value.CompareTo(comparableNode.Value) < 1)
            {
                if (comparableNode.Left == null)
                    comparableNode.Left = node;
                else
                    Insert(node, comparableNode.Left);
            }
        }

        public virtual Node Search(Node node, int key)
        {
            if (node == null) return null;
            if (node.Key == key) return node;
            return node.Value.CompareTo(key) > 1 ? Search(node.Left, key) : Search(node.Right, key);
        }

        public Node GetMin(Node node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;
            return GetMin(node.Left);
        }

        public Node GetMax(Node node)
        {
            if (node == null) return null;
            if (node.Right == null) return node;
            return GetMax(node.Right);
        }

        public Node Delete(Node node, int key)
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
                    Node leftMax = GetMax(node.Left);
                    node.Key = leftMax.Key;
                    node.Value = leftMax.Value;
                    node.Right = Delete(node.Right, leftMax.Key);
                    node.Left = null;
                }
            }

            OnNodeDeleted?.Invoke(node);

            return node;
        }

        public void PrintTree(Node node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
        }

        public void PrintTreePaths(Node node)
        {
            if (node == null) return;
            if (node.Left != null)
            {
                Console.WriteLine(node.Value+" "+ node.Left.Value);
            }
            if (node.Right != null)
            {
                Console.WriteLine(node.Value + " " + node.Right.Value);
            }
            PrintTreePaths(node.Left);
            PrintTreePaths(node.Right);
        }
    }
    abstract class NodeBase<Node> where Node : NodeBase<Node>
    {
        public int Key { get; set; }
        public IComparable Value { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public NodeBase(int key, IComparable value)
        {
            Key = key;
            Value = value;
        }
    }

    class Node : NodeBase<Node>
    {
        public Node(int key, IComparable value) : base(key, value) { }
    }

    class BinarySearchTree<T> : TreeBase<Node>
         where T : IComparable<T>
    {
        public void Delete(int key)
        {
            Delete(root, key);
        }
        public void Insert(T value)
        {
            Node node = new Node(LastKey, (IComparable)value);
            if (root == null) root = node;
            else Insert(node, root);
            LastKey++;
        }
    }
}