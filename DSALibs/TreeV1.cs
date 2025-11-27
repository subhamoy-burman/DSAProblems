
namespace DSALibs
{
    public class TreeNode
    {
        public int Value;
        public TreeNode? Left;
        public TreeNode? Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode? Root;

        public BinaryTree()
        {
            Root = null;
        }

        // Example: Insert value (simple BST insert)
        public void Insert(int value)
        {
            Root = InsertRec(Root, value);
        }

        private TreeNode InsertRec(TreeNode? node, int value)
        {
            if (node == null)
                return new TreeNode(value);

            if (value < node.Value)
                node.Left = InsertRec(node.Left, value);
            else
                node.Right = InsertRec(node.Right, value);

            return node;
        }

        public TreeNode CreateBinaryTreeForDiameter()
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(4);

            return root;
        }

        public int GetDiameterOfBinaryTree(TreeNode root)
        {
            return 0;
            //return GetDiameterMax(0, root.Left) + GetDiameterMax(0, root.Right);
        }

        private int GetHeightOfBinaryTree(TreeNode node)
        {
            int leftHeight = 0;
            int rightHeight = 0;

            leftHeight = node.Left != null ? GetHeightOfBinaryTree(node.Left) : 0;
            rightHeight = node.Right != null ? GetHeightOfBinaryTree(node.Right) : 0;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public int DiameterOfABT(TreeNode node)
        {
            if (node == null) return 0;
            //Find the local height of the each node
            //Then we will do recursion on left and right
            var height = GetHeightOfBinaryTree(node);

            //Recursion on left and Right
            var left = DiameterOfABT(node.Left);
            var diameter = Math.Max(left, height);

            diameter = Math.Max(diameter, DiameterOfABT(node.Right));
            return diameter;
        }

        private (int height, int diameter) HeightAndDiameter(TreeNode node)
        {
            if (node == null) return (0, 0);

            var left = HeightAndDiameter(node.Left);
            var right = HeightAndDiameter(node.Right);

            int height = 1 + Math.Max(left.height, right.height);

            int throughDiameter = left.height + right.height;

            int diameter = Math.Max(Math.Max(left.diameter, right.diameter), throughDiameter);

            return (height, diameter);
        }

        private (bool isBalanced, int height) CheckIfHeightBalanced(TreeNode node)
        {
            if (node == null) return (true, -1);

            var hBalanceLeft = CheckIfHeightBalanced(node.Left);
            if (!hBalanceLeft.isBalanced)
            {
                return (false, 0);
            }
            var leftHeight = hBalanceLeft.height;


            var hBalanceRight = CheckIfHeightBalanced(node.Right);
            if (!hBalanceRight.isBalanced)
            {
                return (false, 0);
            }
            var rightHeight = hBalanceRight.height;


            if (Math.Abs(leftHeight - rightHeight) > 1)
                return (false, -1);

            return (true, Math.Max(leftHeight, rightHeight) + 1);
        }


        private bool CheckIfHeightBalanceNaive(TreeNode node)
        {
            if (node == null)
            {
                return true;
            }
            var leftHeight = GetHeightOfBinaryTree(node.Left);
            var rightHeight = GetHeightOfBinaryTree(node.Right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return false;
            }

            return CheckIfHeightBalanceNaive(node.Left) && CheckIfHeightBalanceNaive(node.Right);
        }

        
    }
    
}