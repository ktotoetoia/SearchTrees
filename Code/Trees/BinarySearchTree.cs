using System.Xml.Linq;

namespace Trees
{
    class BinarySearchTree<type> : ITree<type>, ITreeVizualizer
         where type : IComparable<type>
    {
        public INode root { get; set; }

        public event ITree<type>.NodeDelegate OnNodeRemoved;
        public event ITree<type>.NodeDelegate OnNodeAdded;

        /// <summary>
        /// add, and balance node
        /// </summary>
        /// <returns> added node </returns>
        public virtual INode Add(type value)
        {
            INode addedNode = null;
            if (root != null)
            {
                addedNode = root.Add((IComparable)value);
            }

            else
            {
                root = new Node((IComparable)value);
                addedNode = root;
            }

            OnNodeAdded?.Invoke(addedNode);

            return addedNode;
        }

        /// <summary>
        /// remove first node with same value
        /// </summary>
        /// <returns> node that replaced the removed node</returns>
        public INode Remove(type value)
        {
            INode result = root.Remove((IComparable)value);
            OnNodeRemoved?.Invoke(result);
            return result;
        }

        /// <returns> returns node or null if node is not exist </returns>
        public INode Find(type value)
        {
            return root.Find((IComparable)value);
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

        protected virtual void PrintTree(INode node)
        {
            if (node == null) return;
            PrintTree(node.Left);
            Console.WriteLine(node.Value);
            PrintTree(node.Right);
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
    }
}