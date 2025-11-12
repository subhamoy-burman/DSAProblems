namespace DSALibs
{
    public class BSTNode
    {
        public int NodeValue { get; set; }
        public BSTNode? RightNode { get; set; }
        public BSTNode? LeftNode { get; set; }

        public BSTNode(int value)
        {
            NodeValue = value;
        }
    }

    public class BinarySearchTree
    {
        public BSTNode Root { get; set; }
        public void InsertIntoBST(int nodeValue)
        {
            Root = InsertIntoBSTRecursion(Root, nodeValue);
        }

        private BSTNode InsertIntoBSTRecursion(BSTNode node, int value)
        {
            if(node == null)
            {
                return new BSTNode(value);
            }

            if (node.NodeValue > value)
            {
                node.LeftNode = InsertIntoBSTRecursion(node.LeftNode, value);
            }
            else
            {
                node.RightNode = InsertIntoBSTRecursion(node.RightNode, value);
            }

            return node;
        }
    }
}