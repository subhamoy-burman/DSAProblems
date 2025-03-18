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
        public SingleDLNode? Head { get; set; }
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
