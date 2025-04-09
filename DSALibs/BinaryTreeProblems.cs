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
    internal class BinaryTreeProblems
    {
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
    }
}
