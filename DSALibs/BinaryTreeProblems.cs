using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class BinaryTreeNode
    {
        public int NodeValue { get; set; }
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }

        public BinaryTreeNode(int value) 
        {
            NodeValue = value;
        }
    }
    public class BinaryTreeProblems
    {
        int maxHeight = int.MinValue;
        public void GetDiameter(BinaryTreeNode rootNode)
        {
            if(rootNode == null) return;
            int leftHeight = GetLeftHeight(rootNode);
            int rightHeight = GetRightHeight(rootNode);

            maxHeight = Math.Max(maxHeight, 1 + leftHeight + rightHeight);
            GetDiameter(rootNode.LeftNode);
            GetDiameter(rootNode.RightNode);
        }

        private int GetRightHeight(BinaryTreeNode rootNode)
        {
            if(rootNode == null) return 0;
            return 1 + GetRightHeight(rootNode.RightNode);
        }

        private int GetLeftHeight(BinaryTreeNode rootNode)
        {
            if(rootNode == null) return 0;
            return 1 + GetLeftHeight(rootNode.LeftNode);
        }

        public BinaryTreeNode InvertBinaryTree(BinaryTreeNode root)
        {
            InvertFunction(root);
            return root;
        }

        private void InvertFunction(BinaryTreeNode root)
        {
           if(root == null) return;
           var tempNode = root.RightNode;
           root.RightNode = root.LeftNode;
           root.LeftNode = tempNode;

           InvertFunction(root.LeftNode);
           InvertFunction(root.RightNode);
        }

        public int maxPathValue = int.MinValue;
        public int GetMaxPathSum(BinaryTreeNode root)
        {
            if(root == null) return 0;

            int rightMax = GetMaxPathSum(root.RightNode);
            int leftMax = GetMaxPathSum(root.LeftNode);

            maxPathValue = Math.Max(root.NodeValue, maxPathValue);
            maxPathValue = Math.Max(root.NodeValue + Math.Max(rightMax, leftMax), maxPathValue);

            return root.NodeValue + Math.Max(rightMax, leftMax);
        }
    }
}
