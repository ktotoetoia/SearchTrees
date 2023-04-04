namespace Trees
{
    public interface INode
    {
        public IComparable Value { get; set; }

        public INode Left { get; set; }
        public INode Right { get; set; }

        public INode Add(INode node);
        public INode Find(IComparable value);
    }
}