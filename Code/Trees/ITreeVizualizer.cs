namespace Trees
{
    public interface ITreeVizualizer
    {
        /// <summary>
        /// Prints tree in ascending order
        /// </summary>
        public void PrintTree<type>(ITree<type> tree)
            where type : IComparable<type>;

        /// <summary>
        /// Prints nodes with their childs
        /// </summary>
        public void PrintTreePaths<type>(ITree<type> tree)
            where type : IComparable<type>;
    }
}