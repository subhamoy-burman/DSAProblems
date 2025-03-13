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

            var nodeChildrens = RootNode.Childrens;
            KeyValuePair<char, int> characterCountKvp = new('\0', 0);
            int maxCount = 0;

            foreach (var node in nodeChildrens) { 
            
                if(node.Value.PrefixCount > maxCount)
                {
                    maxCount = node.Value.PrefixCount;
                    characterCountKvp = new KeyValuePair<char, int>(node.Key, node.Value.PrefixCount);
                }
            }

            //Search By key and prefix count
            var rootNode = RootNode.Childrens[characterCountKvp.Key];

            StringBuilder result = new StringBuilder();
            while(rootNode.PrefixCount == characterCountKvp.Value)
            {
                char valueToAppend = rootNode.Childrens.Where(x => x.Value.PrefixCount == maxCount).FirstOrDefault().Key;
                result.Append(valueToAppend);
                rootNode = rootNode.Childrens[valueToAppend];
            }

            return result.ToString();
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
