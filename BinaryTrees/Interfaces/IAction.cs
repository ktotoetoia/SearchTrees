namespace Trees
{
    public interface INodeAction
    {
        public INode DoAction(IComparable value);
    }

    public interface IBalanceAction
    {
        public INode DoAction();
    }
}