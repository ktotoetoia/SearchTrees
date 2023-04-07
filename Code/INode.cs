namespace Trees
{
    public interface INode
    {
        public IComparable Value { get; set; }

        public INode Left { get; set; }
        public INode Right { get; set; }

        public INode InstantCreate(IComparable value);
        public INode Add(IComparable value);
        public INode Find(IComparable value);
        public INode Remove(IComparable value);
    }

    public interface IHasHeight
    {
        public int Height { get;}
        public void UpdateHeight();
    }

    public interface IBalancing
    {
        public INode Balance();
    }
}