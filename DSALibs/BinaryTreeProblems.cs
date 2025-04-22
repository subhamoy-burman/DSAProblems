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

    public class PBinaryTreeNode
    {
        public int NodeValue { get; set; }
        public PBinaryTreeNode LeftNode { get; set; }
        public PBinaryTreeNode RightNode { get; set; }
        public PBinaryTreeNode ParentNode { get; set; }
        public bool IsVisited { get; set; }
    }
    public class BinaryTreeProblems
    {
        int maxHeight = int.MinValue;
        public void GetDiameter(BinaryTreeNode rootNode)
        {
            if (rootNode == null) return;
            int leftHeight = GetLeftHeight(rootNode);
            int rightHeight = GetRightHeight(rootNode);

            maxHeight = Math.Max(maxHeight, 1 + leftHeight + rightHeight);
            GetDiameter(rootNode.LeftNode);
            GetDiameter(rootNode.RightNode);
        }

        private int GetRightHeight(BinaryTreeNode rootNode)
        {
            if (rootNode == null) return 0;
            return 1 + GetRightHeight(rootNode.RightNode);
        }

        private int GetLeftHeight(BinaryTreeNode rootNode)
        {
            if (rootNode == null) return 0;
            return 1 + GetLeftHeight(rootNode.LeftNode);
        }

        public BinaryTreeNode InvertBinaryTree(BinaryTreeNode root)
        {
            InvertFunction(root);
            return root;
        }

        private void InvertFunction(BinaryTreeNode root)
        {
            if (root == null) return;
            var tempNode = root.RightNode;
            root.RightNode = root.LeftNode;
            root.LeftNode = tempNode;

            InvertFunction(root.LeftNode);
            InvertFunction(root.RightNode);
        }

        public int maxPathValue = int.MinValue;
        public int GetMaxPathSum(BinaryTreeNode root)
        {
            if (root == null) return 0;

            int rightMax = GetMaxPathSum(root.RightNode);
            int leftMax = GetMaxPathSum(root.LeftNode);

            maxPathValue = Math.Max(root.NodeValue, maxPathValue);
            maxPathValue = Math.Max(root.NodeValue + Math.Max(rightMax, leftMax), maxPathValue);

            return root.NodeValue + Math.Max(rightMax, leftMax);
        }

        public int[] BoundaryTraversal(BinaryTreeNode root)
        {
            List<int> result = new List<int>();
            AddLeftBoundary(root, result);
            AddLeafNodes(root, result);
            List<int> rightNodeList = new List<int>();
            AddRightBoundary(root.RightNode, rightNodeList);
            rightNodeList.Reverse();
            result.AddRange(rightNodeList);

            return result.ToArray();
        }

        private void AddRightBoundary(BinaryTreeNode root, List<int> result)
        {
            if (root == null) return;
            if (root.RightNode == null && root.LeftNode == null) return;
            result.Add(root.NodeValue);

            if (root.RightNode != null)
            {
                AddRightBoundary(root.RightNode, result);
            }
            else
            {
                AddRightBoundary(root.LeftNode, result);
            }
        }

        private void AddLeafNodes(BinaryTreeNode root, List<int> result)
        {
            if (root == null) return;

            if (root.LeftNode == null && root.RightNode == null)
            {
                result.Add(root.NodeValue);
                return;
            }

            AddLeafNodes(root.LeftNode, result);
            AddLeafNodes(root.RightNode, result);
        }

        private void AddLeftBoundary(BinaryTreeNode root, List<int> result)
        {
            if (root == null) return;
            if (root.RightNode == null && root.LeftNode == null) return;
            result.Add(root.NodeValue);
            if (root.LeftNode != null)
            {
                AddLeftBoundary(root.LeftNode, result);
            }
            else
            {
                AddLeftBoundary(root.RightNode, result);
            }

        }


        public int FindSuccessor(PBinaryTreeNode node)
        {
            if (node == null) return -1;
            List<int> result = new List<int>();

            if (node.RightNode != null)
            {
                InOrder(node.RightNode, result);
                return result[0];
            }
            else
            {
                var parentNode = node.ParentNode;

                if (parentNode.LeftNode == node)
                {
                    return parentNode.NodeValue;
                }
                else
                {
                    while (parentNode.LeftNode != node && parentNode != null)
                    {

                        node = parentNode;
                        parentNode = node.ParentNode;
                    }
                    return parentNode.NodeValue;
                }
            }
        }

        private void InOrder(PBinaryTreeNode node, List<int> result)
        {
            if (node == null) return;

            InOrder(node.LeftNode, result);
            result.Add(node.NodeValue);
            InOrder(node.RightNode, result);
        }




        private void TraverseToK(PBinaryTreeNode node, int target, List<int> result, int level = 0)
        {
            if (node == null) return;
            if (node.IsVisited) return;
            if (target == 0) return;
            node.IsVisited = true;
            if (target == level)
            {
                result.Add(node.NodeValue);
                return;
            }
            TraverseToK(node.LeftNode, target, result, level + 1);
            TraverseToK(node.RightNode, target, result, level + 1);
            TraverseToK(node.ParentNode, target, result, level + 1);
        }

        public List<int> FindNodeAtKDistance(PBinaryTreeNode node, int distance)
        {
            var result = new List<int>();
            TraverseToK(node, distance, result, 0);
            return result;
        }

        public void MergeBinaryTrees(BinaryTreeNode node1, BinaryTreeNode node2, BinaryTreeNode result)
        {

            if(node1 == null && node2 == null) return;

            if (node1 != null && node2 != null)
            {
                result.NodeValue = node1.NodeValue + node2.NodeValue;
            }
            else if (node1 != null)
            {
                result.NodeValue = node1.NodeValue;
            }
            else if (node2 != null)
            {
                result.NodeValue = node2.NodeValue;
            }

            if (node1?.LeftNode != null || node2?.LeftNode != null)
            {
                result.LeftNode = new BinaryTreeNode(-1);
            }

            if(node1?.RightNode != null || node2?.RightNode!=null)
            {
                result.RightNode = new BinaryTreeNode(-1);
            }

            BinaryTreeNode? node1Left = null;
            BinaryTreeNode? node1Right = null;

            BinaryTreeNode? node2Left = null;
            BinaryTreeNode? node2Right = null;


            if (node1?.LeftNode != null)
            {
                node1Left = node1.LeftNode;
            }

            if(node1?.RightNode != null)
            {
                node1Right = node1.RightNode;
            }

            if (node2?.LeftNode != null)
            {
                node2Left = node2.LeftNode;
            }

            if (node2?.RightNode != null)
            {
                node2Right = node2.RightNode;
            }

            if (result.LeftNode != null)
            {
                MergeBinaryTrees(node1Left, node2Left, result.LeftNode);
            }
            if (result.RightNode != null)
            {
                MergeBinaryTrees(node1Right, node2Right, result.RightNode);
            }

        }

        public bool IsSymmetric(BinaryTreeNode node1, BinaryTreeNode node2)
        {
            if (node1 == null && node2 == null) return true;
            if (node1 != null && node2 != null)
            {
                return node1.NodeValue.Equals(node2.NodeValue) && IsSymmetric(node1.RightNode, node2.RightNode) && IsSymmetric(node1.LeftNode, node2.RightNode);
            }
            else
            {
                return false;
            }
        }

        public int SplitBinaryTree(BinaryTreeNode btNode)
        {
            List<int> result = new List<int>();
            int actualSum = DetermineActualSumOfBinaryTree(btNode, result);

            if(actualSum % 2 != 0) return 0;

            if(result.Contains(actualSum/2)) return actualSum/2;
            return 0;

        }

        private int DetermineActualSumOfBinaryTree(BinaryTreeNode btNode, List<int> results)
        {
            if(btNode == null) return 0;

            var nodeSumResult = btNode.NodeValue + DetermineActualSumOfBinaryTree(btNode.LeftNode, results) + DetermineActualSumOfBinaryTree(btNode.RightNode, results);
            results.Add(nodeSumResult);
            return nodeSumResult;
        }
    }
}
