namespace Trees
{
    public interface INodeFactory
    {
        public INode Create(IComparable value);
    }
}