﻿namespace _03.FindWordsInText
{
    /// <summary>
    /// Trie data structure which maps strings to generic values.
    /// </summary>
    /// <typeparam name="T">Type of values to map to. Must be referencable</typeparam>
    public class Trie<T> where T : class
    {

        private TrieNode<T> root;

        /// <summary>
        /// Matcher object for matching prefixes of strings to the strings stored in this trie.
        /// </summary>
        public PrefixMatcher<T> Matcher { get; private set; }

        /// <summary>
        /// Create an empty trie with an empty root node.
        /// </summary>
        public Trie()
        {
            this.root = new TrieNode<T>(null, '\0');
            this.Matcher = new PrefixMatcher<T>(this.root);
        }

        /// <summary>
        /// Put a new key value pair, overwriting the existing value if the given key is already in use.
        /// </summary>
        /// <param name="key">Key to search for value by.</param>
        /// <param name="value">Value associated with key.</param>
        public void Put(string key, T value)
        {
            TrieNode<T> node = this.root;
            foreach (char c in key)
            {
                node = node.AddChild(c);
            }
            node.Value = value;
        }

        /// <summary>
        /// Remove the value that a key leads to and any redundant nodes which result from this action.
        /// Clears the current matching process.
        /// </summary>
        /// <param name="key">Key of the value to remove.</param>
        public void Remove(string key)
        {
            TrieNode<T> node = this.root;
            foreach (char c in key)
            {
                node = node.GetChild(c);
            }
            node.Value = null;

            //Remove all ancestor nodes which don't lead to a value.
            while (node != this.root && !node.IsTerminater() && node.NumChildren() == 0)
            {
                char prevKey = node.Key;
                node = node.Parent;
                node.RemoveChild(prevKey);
            }

            this.Matcher.ResetMatch();
        }

    }
}