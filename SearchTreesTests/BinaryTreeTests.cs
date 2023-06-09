namespace Trees.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
        private TreeTests treeTests = new TreeTests(new BinaryTreeFactory());

        [TestMethod]
        public void AddingNodeTests()
        {
            treeTests.AddingNodesTests();
        }

        [TestMethod]
        public void RemovingNodeTests()
        {
            treeTests.RemovingNodesTests();
        }

        [TestMethod]
        public void NullTests()
        {
            treeTests.NullTests();
        }
    }
}