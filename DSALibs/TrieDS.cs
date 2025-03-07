using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }

            currentNode.IsLeaf = true;
        }

        public bool Search(string word) {

            var currentNode = RootNode;

            foreach (var character in word) {

                if (!currentNode.Childrens.ContainsKey(character)) { 
                
                    return false;
                }
                currentNode = currentNode.Childrens[character];
            }

            return currentNode.IsLeaf;
        
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> Childrens;
        public bool IsLeaf { get; set; }

        public TrieNode()
        {
            Childrens = new Dictionary<char, TrieNode>();
        }
    }
}
