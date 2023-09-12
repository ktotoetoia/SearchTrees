namespace Trees.Tests
{
    public class TreeTests
    {
        private ITreeFactory treeFactory;
        
        public TreeTests(ITreeFactory treeFactory)
        {
            this.treeFactory = treeFactory;
        }

        public void AddingNodesTests()
        {
            int treeSize = 30;
            ITree<int> tree = treeFactory.CreateTree(treeSize);

            for (int i = 1; i <= treeSize; i++)
            {
                Assert.IsNotNull(tree.Find(i));
            }
        }

        public void RemovingNodesTests()
        {
            ITree<int> tree = treeFactory.CreateTree(30);

            tree.Remove(3);
            tree.Remove(5);

            Assert.IsNotNull(tree.Find(4));
            Assert.IsNotNull(tree.Find(14));
            Assert.IsNotNull(tree.Find(16));
            Assert.IsNotNull(tree.Find(1));
            Assert.IsNotNull(tree.Find(10));

            Assert.IsNull(tree.Find(3));
            Assert.IsNull(tree.Find(5));
        }

        public void NullTests()
        {
            EmptyTreeNullTest();
            NotEmptyTreeNullTest();
        }

        private void EmptyTreeNullTest()
        {
            ITree<int> tree = treeFactory.CreateTree(0);
            Assert.IsNull(tree.Root);
        }

        private void NotEmptyTreeNullTest()
        {
            ITree<int> tree = treeFactory.CreateTree(1);
            Assert.IsNotNull(tree.Root);
        }
    }
}