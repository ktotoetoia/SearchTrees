namespace Trees
{
    public interface INode : ILeftRightPointer , IHasValue
    {
        /// <summary>
        /// adding node as child of this
        /// </summary>
        /// <returns> added node </returns>
        public INode Add(IComparable value);

        /// <summary>
        /// removes node from child of this
        /// </summary>
        /// <returns>node that chenged removed</returns>
        public INode Remove(IComparable value);

        /// <summary>
        /// finding node with value, from childs of this
        /// </summary>
        /// <returns> returns node or null if node is not exist in this</returns>
        public INode Find(IComparable value);
    }

    public interface IHasHeight
    {
        public int Height { get; }
        public void UpdateHeight();
    }

    public interface IHasValue
    {
        public IComparable Value { get; set; }
    }

    public interface IBalancing
    {
        public int GetBalance();
        public INode Balance();
    }

    public interface IAVLRotations : IBalancing, IHasHeight
    {
        public INode RightRotate();
        public INode LeftRotate();
    }

    public interface ILeftRightPointer
    {
        public INode Left { get; set; }
        public INode Right { get; set; }
    }
}