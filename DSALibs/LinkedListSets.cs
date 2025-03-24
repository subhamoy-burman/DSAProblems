using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    internal class LinkedListSets
    {

    }

    public class DLNode
    {
        public int Value { get; set; }
        public DLNode? Prev { get; set; }
        public DLNode? Next { get; set; }
        public DLNode(int value)
        {

            this.Value = value;
        }
    }

    public class SingleDLNode
    {
        public int NodeValue { get; set; }
        public SingleDLNode? Next { get; set; }

        public SingleDLNode(int nodeValue)
        {
            NodeValue = nodeValue;
        }
    }

    public class SingleLinkedList
    {
        public SingleDLNode RotateLinkedList(int k)
        {
            if (Head == null || k == 0) return Head;
            var currentNode = Head;
            int length = 0;



            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                length++;
            }

            if (length == 1 || k%length == 0) return Head;

            SingleDLNode tempNode = null;
            SingleDLNode currentOpNode = Head;
            int traverseLength = length - (k % length);

            while (traverseLength > 0)
            {
                tempNode = currentOpNode;
                currentOpNode = currentOpNode.Next;
                traverseLength--;
            }

            tempNode.Next = null;

            var newHead = currentOpNode;

            while (currentOpNode.Next != null)
            {
                currentOpNode = currentOpNode.Next;
            }

            currentOpNode.Next = Head;
            Head = newHead;
            return Head;

        }
        public SingleDLNode? Head { get; set; }
        public SingleDLNode FindStartOfLoop()
        {
            if (Head == null) return null;
            if (Head.Next == null) return Head;
            var slowPointerStart = Head;

            if (slowPointerStart != null)
            {
                slowPointerStart = slowPointerStart.Next;
            }
            var fastPointerStart = Head.Next;
            if (fastPointerStart != null)
            {

                fastPointerStart = fastPointerStart.Next;
            }


            while (slowPointerStart != fastPointerStart)
            {
                slowPointerStart = slowPointerStart?.Next;
                fastPointerStart = fastPointerStart?.Next?.Next;

                if (slowPointerStart == null || fastPointerStart == null) return null; //No loop detected
            }

            slowPointerStart = Head;

            while (slowPointerStart != fastPointerStart)
            {
                slowPointerStart = slowPointerStart?.Next;
                fastPointerStart = fastPointerStart?.Next;
            }

            return slowPointerStart!;
        }
        public void RemoveKthNode(int k)
        {
            if (Head == null) return;
            var currentNode = Head;
            int totalLength = 0;

            while (currentNode != null) 
            { 
                currentNode = currentNode.Next;
                totalLength++;
            }

            int traverseLength = totalLength - k;

            

            if(k<1 || k> totalLength)
            {
                return;
            }

            if (traverseLength == 0) { 
            
                Head = Head.Next;
                return;
            }

            var prevToCurrentNode = Head;

            while (traverseLength > 1) 
            {
                prevToCurrentNode = prevToCurrentNode?.Next;
                traverseLength--;
            }

            if (prevToCurrentNode != null)
            {
                prevToCurrentNode.Next = prevToCurrentNode.Next?.Next;
            }
        }
        private void Remove(SingleDLNode? newCurrentNode, SingleDLNode? prevToCurrentNode)
        {
            prevToCurrentNode!.Next = newCurrentNode?.Next;
            newCurrentNode = null;
        }
        public void ReverseLinkedList()
        {
            var prev = Head;
            var curr = Head?.Next;
            SingleDLNode prevRef = null;

            while (curr != null)
            {
                var temp = curr.Next;
                curr.Next = prev;
                prev.Next = prevRef;
                prevRef = curr;
                prev = curr;
                curr = temp;
            }
            Head = prev;
        }
        public SingleDLNode? MergeSortLinkedList(SingleDLNode node1, SingleDLNode node2)
        {
            // Step 1: Decide the head of the merged list
            SingleDLNode head;
            if (node1.NodeValue <= node2.NodeValue)
            {
                head = node1;
                node1 = node1.Next;
            }
            else
            {
                head = node2;
                node2 = node2.Next;
            }

            // Step 2: Use a pointer to build the merged list
            SingleDLNode current = head;

            // Step 3: Iteratively merge the lists
            while (node1 != null && node2 != null)
            {
                if (node1.NodeValue <= node2.NodeValue)
                {
                    current.Next = node1;
                    node1 = node1.Next;
                }
                else
                {
                    current.Next = node2;
                    node2 = node2.Next;
                }
                current = current.Next;
            }

            return head;

        }

        public SingleDLNode SumOfLinkedLists(SingleDLNode? node1, SingleDLNode? node2)
        {
            SingleDLNode dummyNode = new SingleDLNode(0);
            var resultLL = dummyNode;
            int sum = 0;
            int carryForward = 0;

            while (node1 != null || node2 != null || carryForward>0)
            {
                int node1Value = node1!=null ? node1.NodeValue : 0;
                int node2Value = node2!=null ? node2.NodeValue : 0;
                int actualSum = node1Value + node2Value + carryForward;
                sum = actualSum % 10;
                carryForward = actualSum / 10;
                
                resultLL.Next = new SingleDLNode(sum);
                resultLL = resultLL.Next;
                
                if (node1!=null) node1 = node1.Next;
                if (node2!=null) node2 = node2.Next;
            }

            return dummyNode?.Next;
        }

       

        /*
                Write a DoublyLinkedList class that has a head and a tail, both of which point to either a linked list Node or None / null. The class should support:
                Setting the head and tail of the linked list.
                Inserting nodes before and after other nodes as well as at given positions (the position of the head node is 1).
                Removing given nodes and removing nodes with given values.
                Searching for nodes with given values.
                Note that the 
                setHead, setTail, insertBefore, insertAfter, insertAtPosition, and remove methods all take in actual Nodes as input parameters not integers 
                (except for insertAtPosition, which also takes in an integer representing the position); 
                this means that you don't need to create any new Nodes in these methods. 
                The input nodes can be either stand-alone nodes or nodes that are already in the linked list. 
                If they're nodes that are already in the linked list, the methods will effectively be moving the nodes within the linked list. 
                You won't be told if the input nodes are already in the linked list, so your code will have to defensively handle this scenario.
             */


        public class DoubleLinkedList
    {
        public DLNode? DLHead { get; set; }

        public void SetDoublyLinkedListHead(DLNode head)
        {
            if (DLHead == null)
            {
                DLHead = head;
                return;
            }

            if (DLHead == head)
            {
                return;
            }

            // Go through the whole list to understand if the head is there already in the list
            var currentNode = DLHead;
            while (currentNode != null)
            {
                if (currentNode == head)
                {
                    var savedNode = currentNode;
                    if (currentNode.Prev != null)
                    {
                        currentNode.Prev.Next = savedNode.Next;
                    }

                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Prev = savedNode.Prev;
                    }

                    currentNode.Prev = null;
                    currentNode.Next = null;

                    break;
                }
                currentNode = currentNode.Next;
            }

            var currentHead = DLHead;
            currentHead.Prev = head;
            head.Next = currentHead;
            DLHead = head;
        }

        public void InsertBefore(DLNode targetNode, DLNode newNode)
        {
            var currentNode = DLHead;

            while (currentNode != null)
            {
                if (currentNode == targetNode)
                {
                    var tempNode = currentNode;
                    if (currentNode.Prev != null)
                    {
                        currentNode.Prev.Next = newNode;
                    }
                    currentNode.Prev = newNode;
                    newNode.Prev = tempNode.Prev;
                    newNode.Next = currentNode;
                    break;
                }
                currentNode = currentNode.Next;
            }
        }

        public void InsertAfter(DLNode targetNode, DLNode newNode)
        {
            if (DLHead is null)
            {
                throw new Exception();
            }

            if (DLHead == targetNode)
            {
                SetDoublyLinkedListHead(newNode);
            }

            var currentNode = DLHead;

            while (currentNode != null)
            {
                if (currentNode == targetNode)
                {
                    newNode.Prev = currentNode;
                    newNode.Next = currentNode.Next;

                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Prev = newNode;
                    }
                    currentNode.Next = newNode;

                    break;
                }
                currentNode = currentNode.Next;
            }
        }

    }
}
