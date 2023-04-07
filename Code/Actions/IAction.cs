namespace Trees.Actions
{
    internal interface INodeAction
    {
        public INode DoAction(IComparable value);
    }
}