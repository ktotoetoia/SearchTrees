namespace Trees
{
    public interface ITreeVizualizer
    {
        /// <summary>
        /// Prints tree in ascending order
        /// </summary>
        public void PrintTree<valueType>(ITree<valueType> tree)
            where valueType : IComparable;

        /// <summary>
        /// Prints nodes with their childs
        /// </summary>
        public void PrintTreePaths<valueType>(ITree<valueType> tree)
            where valueType : IComparable;
    }
}