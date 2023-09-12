namespace Trees
{
    public class BinaryNodeFactory : INodeFactory
    {
        public INode Create(IComparable value)
        {
            return new Node(value);
        }
    }
}