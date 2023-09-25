namespace Trees.Tests
{
    [TestClass]
    public class AVLTreeTests
    {
        private AVLTreeFactory factory = new AVLTreeFactory();
        private TreeTests treeTests;

        public AVLTreeTests()
        {
            treeTests = new TreeTests(factory);
        }

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

        [TestMethod]
        public void NodesChildTests()
        {
            ITree<int> tree = factory.CreateTree(3);
            TestNodeChilds(tree, 2, 1, 3);

            tree = factory.CreateTree(12);
            TestNodeChilds(tree, 8, 4, 10);
            TestNodeChilds(tree, 4, 2, 6);
            TestNodeChilds(tree, 10, 9, 11);
            TestNodeChilds(tree, 11, -1, 12);
            TestNodeChilds(tree, 6, 5, 7);
            TestNodeChilds(tree, 2, 1, 3);

            tree = factory.CreateTree(24);
            TestNodeChilds(tree, 16, 8, 20);
            TestNodeChilds(tree, 8, 4, 12);
            TestNodeChilds(tree, 12, 10, 14);
            TestNodeChilds(tree, 10, 9, 11);
            TestNodeChilds(tree, 14, 13, 15);
            TestNodeChilds(tree, 20, 18, 22);
            TestNodeChilds(tree, 23, -1, 24);
        }

        private void TestNodeChilds(ITree<int> tree, int nodeNum, int leftChild, int rightChild)
        {
            INode node = tree.Find(nodeNum);
            if (node.Left != null)
            {
                Assert.AreEqual(node.Left.Value, leftChild);
            }

            if (node.Right != null)
            {
                Assert.AreEqual(node.Right.Value, rightChild);
            }
        }

        //To Do;
        [TestMethod]
        public void BalanceTests()
        {
            ITree<int> tree = factory.CreateTree(100);

        }
    }
}