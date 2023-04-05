namespace Trees
{
    class AVLTree<type> : BinarySearchTree<type>
        where type : IComparable<type>
    {
        /// <summary>
        /// adding node and balancing the tree
        /// </summary>
        /// <returns> parent of added node </returns>
        public override INode Add(type value)
        {
            AVLNode node = new AVLNode((IComparable)value);
            
            return Add(node);
        }
    }
}