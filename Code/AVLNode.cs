namespace Trees
{
    class AVLNode : Node
    {
        public int Height { get; private set; }

        public override INode Left { get; set; }
        public override INode Right { get; set; }

        public AVLNode(IComparable value) : base(value)
        {

        }

        public int GetBalance()
        {
            return GetHeight(Right) - GetHeight(Left);
        }

        public int GetHeight(INode node)
        {
            return node == null ? -1: (node as AVLNode).Height;
        }

        public void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left),GetHeight(Right))+1;
        }

        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> parent of added node </returns>
        public override INode Add(INode node)
        {
            AVLNode result = (AVLNode) base.Add(node);
            UpdateHeight();
            
            return result;
        }
    }
}