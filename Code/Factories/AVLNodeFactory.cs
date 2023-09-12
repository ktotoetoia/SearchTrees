namespace Trees
{
    public class AVLNodeFactory : INodeFactory
    {
        public INode Create(IComparable value)
        {
            return new AVLNode(value);
        }
    }
}