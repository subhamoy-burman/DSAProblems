

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

        public void DeleteNode(int nodeValue)
        {
            Root = DeleteNodeRec(Root, nodeValue);
        }

        private BSTNode DeleteNodeRec(BSTNode node, int nodeValue)
        {
            if(node == null)
            {
                return node;
            }

            if(node.NodeValue > nodeValue)
            {
                node.LeftNode = DeleteNodeRec(node.LeftNode, nodeValue);
            }
            else if (node.NodeValue < nodeValue)
            {
                node.RightNode = DeleteNodeRec(node.RightNode, nodeValue);
            }
            else if(node.NodeValue == nodeValue)
            {
                if(node.LeftNode is null) return node.RightNode;
                if(node.RightNode is null) return node.LeftNode;

                var successor = findMin(node.RightNode); //inorder successor
                node.NodeValue = successor.NodeValue;
                node.RightNode = DeleteNodeRec(node.RightNode, successor.NodeValue);
            }
            return node;
        }

        private BSTNode findMin(BSTNode node)
        {
            while(node.LeftNode!=null)
            {
                node = node.LeftNode;
            }
            return node;
        }
    }
}