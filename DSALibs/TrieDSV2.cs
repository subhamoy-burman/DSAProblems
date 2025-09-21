using System;
using System.Collections.Generic;

namespace DSALibs
{
    public class TrieDSV2
    {
        public TrieNode Root { get; set; } = new TrieNode();
        public class TrieNode
        {
            public TrieNode[] Childrens { get; set; }
            public bool IsWordEnd { get; set; }

            public TrieNode()
            {
                Childrens = new TrieNode[26];
            }
        }

        public void InsertWordInTrie(string word)
        {
            var currentNode = Root;
            foreach (var item in word.ToCharArray())
            {
                int index = item - 'a';

                if (currentNode.Childrens[index] == null)
                {
                    currentNode.Childrens[index] = new TrieNode();
                }

                currentNode = currentNode.Childrens[index];
            }
            currentNode.IsWordEnd = true;
        }

        public bool SearchWordInTrie(string word)
        {
            var currentNode = Root;
            foreach (var item in word)
            {
                int index = item - 'a';
                if (currentNode.Childrens[index] == null)
                {
                    return false;
                }
                else
                {
                    currentNode = currentNode.Childrens[index];
                }
            }
            return currentNode.IsWordEnd;
        }
    }
}