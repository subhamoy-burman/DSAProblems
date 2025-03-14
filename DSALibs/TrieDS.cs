using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSALibs
{
    public class TrieDS
    {
        public TrieNode RootNode { get; set; } = new TrieNode();
        public void Insert(string word)
        {
            var currentNode = RootNode;
            foreach (var character in word)
            {
                if (!currentNode.Childrens.ContainsKey(character))
                {
                    currentNode.Childrens.Add(character, new TrieNode());
                }
                currentNode = currentNode.Childrens[character];
                currentNode.PrefixCount = currentNode.PrefixCount + 1;
            }

            currentNode.IsLeaf = true;
        }

        public bool Search(string word)
        {
            var currentNode = RootNode;

            foreach (var character in word)
            {

                if (!currentNode.Childrens.ContainsKey(character))
                {
                    return false;
                }
                currentNode = currentNode.Childrens[character];
            }

            return currentNode.IsLeaf;

        }

        public string GetHighestFrequencyPrefix(string[] words)
        {
            foreach (var word in words)
            {
                Insert(word);
            }

            string result = string.Empty;
            int maxFrequency = 0;
            int maxLength = 0;


            void TrieDFS(TrieNode node, string currentPrefix)
            {
                if(node ==null)
                {
                    return;
                }

                if (node.PrefixCount > maxFrequency || 
                    (node.PrefixCount == maxFrequency && currentPrefix.Length>maxLength)) {

                    maxFrequency = node.PrefixCount;
                    result = currentPrefix;
                    maxLength = currentPrefix.Length;
                }


                foreach (var kvp in node.Childrens) { 
                
                    TrieDFS(kvp.Value, currentPrefix + kvp.Key);
                }

            }

            TrieDFS(RootNode, string.Empty);

            return result;

        }



        public TrieNode BuildSuffix(string str)
        {
            TrieNode suffixTreeNode = new TrieNode();
            for (int i = 0; i < str.Length; i++)
            {
                BuildSuffixTree(suffixTreeNode, str.Substring(i));
            }
            return suffixTreeNode;
        }

        private void BuildSuffixTree(TrieNode rootNode, string subStr)
        {
            var node = rootNode;
            foreach (var item in subStr)
            {
                if (!node.Childrens.ContainsKey(item))
                {
                    node.Childrens.Add(item, new TrieNode());
                }
                node = node.Childrens[item];
            }
            node.IsLeaf = true;
        }
    }

    public class SuffixTrie
    {
        public TrieNode RootNode { get; set; }

        public SuffixTrie()
        {
            RootNode = new TrieNode();
        }

        public void BuildSuffix(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                BuildSuffixTree(str.Substring(i));
            }
        }

        private void BuildSuffixTree(string subStr)
        {
            var node = RootNode;
            foreach (var item in subStr)
            {
                if (!node.Childrens.ContainsKey(item))
                {
                    node.Childrens.Add(item, new TrieNode());
                }
                node = node.Childrens[item];
            }
            node.IsLeaf = true;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Childrens;
        public int PrefixCount { get; set; }
        public bool IsLeaf { get; set; }

        public TrieNode()
        {
            Childrens = new Dictionary<char, TrieNode>();
            PrefixCount = 0;
        }
    }
}
