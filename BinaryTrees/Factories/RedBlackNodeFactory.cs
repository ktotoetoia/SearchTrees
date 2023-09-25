namespace Trees
{
    public class RedBlackNodeFactory : INodeFactory
    {
        public INode Create(IComparable value)
        {
            return new RedBlackNode(value);
        }
    }
}