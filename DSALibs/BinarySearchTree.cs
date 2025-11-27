


namespace DSALibs
{
    public class BSTNode
    {
        public int NodeValue { get; set; }
        public BSTNode? RightNode { get; set; }
        public BSTNode? LeftNode { get; set; }

        public BSTNode()
        {
            
        }

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

        private BSTNode findMax(BSTNode node)
        {
            while(node.RightNode!=null)
            {
                node = node.RightNode;
            }
            return node;
        }

        //Find Kth largest or smallest

        //Is BT a BST


        // Build BST from Preorder
        public BSTNode BuildBSTFromPreorder(int[] preOrderArray)
        {
            BSTNode bstNode = new BSTNode();
            recursiveBuildBST(bstNode, preOrderArray, 0, preOrderArray.Length - 1);
            return bstNode;

        }

        private void recursiveBuildBST(BSTNode bst, int[] preOrderArray, int start, int end)
        {
            if(start>end)
            {
                return;
            }

            bst.NodeValue = preOrderArray[start];
            int i = 0;

            for(i = start + 1; i<= end; i++)
            {
                if(preOrderArray[i]> preOrderArray[start])
                {
                    break;
                }
            }

            if(start+1 <= i-1)
            {
                bst.LeftNode = new BSTNode();
                recursiveBuildBST(bst.LeftNode, preOrderArray, start+1, i-1);
            }

            if(end >= i)
            {
                bst.RightNode = new BSTNode();
                recursiveBuildBST(bst.RightNode, preOrderArray, i, end);
            }
        }

        public Tuple<int,int> FindInorderSuccessorPredecessor(BSTNode bSTNode, int targetKey)
        {
            int inorderSuccessor = int.MaxValue;
            int inorderPredecessor = int.MinValue;

            recursiveFindInorderSuccessorPredecessor(bSTNode, ref inorderPredecessor, ref inorderSuccessor, targetKey);

            return new Tuple<int, int>(inorderPredecessor, inorderSuccessor);
        }

        private void recursiveFindInorderSuccessorPredecessor(BSTNode bSTNode, ref int inorderPredecessor, 
        ref int inorderSuccessor, int target)
        {
            if(bSTNode is null) return;

            if (target ==  bSTNode.NodeValue)
            {
                if(bSTNode.LeftNode!=null)
                {
                    inorderPredecessor = findMax(bSTNode.LeftNode).NodeValue;
                }
                if(bSTNode.RightNode != null)
                {
                    inorderSuccessor = findMin(bSTNode.RightNode).NodeValue;
                }
                return;
            }
            else if(target>bSTNode.NodeValue)
            {
                inorderPredecessor = Math.Max(inorderPredecessor, bSTNode.NodeValue);
                if(bSTNode.RightNode!=null)
                recursiveFindInorderSuccessorPredecessor(bSTNode.RightNode, ref inorderPredecessor, ref inorderSuccessor, target);
            }
            else if(target<bSTNode.NodeValue)
            {
                inorderSuccessor = Math.Min(inorderSuccessor, bSTNode.NodeValue);
                if(bSTNode.LeftNode != null)
                recursiveFindInorderSuccessorPredecessor(bSTNode.LeftNode, ref inorderPredecessor, ref inorderSuccessor, target);
            }
        }
    }
}