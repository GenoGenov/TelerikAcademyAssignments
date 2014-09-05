namespace _03.FindWordsInText
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Search through a trie for all the strings which have a given prefix which will be entered character by character.
    /// </summary>
    /// <typeparam name="T">Type of the value stored in the trie.</typeparam>
    public class PrefixMatcher<T> where T : class
    {

        private TrieNode<T> root;

        private TrieNode<T> currMatch;

        private string prefixMatched;

        /// <summary>
        /// Create a matcher, associating it to the trie to search in.
        /// </summary>
        /// <param name="root">Root node of the trie which the matcher will search in.</param>
        public PrefixMatcher(TrieNode<T> root)
        {
            this.root = root;
            this.currMatch = root;
        }

        /// <summary>
        /// Get the prefix entered so far.
        /// </summary>
        /// <returns>The prefix.</returns>
        public String GetPrefix()
        {
            return this.prefixMatched;
        }

        /// <summary>
        /// Clear the currently entered prefix.
        /// </summary>
        public void ResetMatch()
        {
            this.currMatch = this.root;
            this.prefixMatched = "";
        }

        /// <summary>
        /// Remove the last character of the currently entered prefix.
        /// </summary>
        public void BackMatch()
        {
            if (this.currMatch != this.root)
            {
                this.currMatch = this.currMatch.Parent;
                this.prefixMatched = this.prefixMatched.Substring(0, this.prefixMatched.Length - 1);
            }
        }

        /// <summary>
        /// Get the last character of the currently entered prefix.
        /// </summary>
        /// <returns></returns>
        public char LastMatch()
        {
            return this.currMatch.Key;
        }

        /// <summary>
        /// Add another character to the end of the prefix if new prefix is actually a prefix to some strings in the trie.
        /// If no strings have a matching prefix, character will not be added.
        /// </summary>
        /// <param name="next">Next character in the prefix.</param>
        /// <returns>True if the new prefix was a prefix to some strings in the trie, false otherwise.</returns>
        public bool NextMatch(char next)
        {
            if (this.currMatch.ContainsKey(next))
            {
                this.currMatch = this.currMatch.GetChild(next);
                this.prefixMatched += next;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all the corresponding values of the keys which have a prefix corresponding to the currently entered prefix.
        /// </summary>
        /// <returns>List of values.</returns>
        public List<T> GetPrefixMatches()
        {
            return this.currMatch.PrefixMatches();
        }

        /// <summary>
        /// Check if the currently entered prefix is an existing string in the trie.
        /// </summary>
        /// <returns>True if the currently entered prefix is an existing string, false otherwise.</returns>
        public bool IsExactMatch()
        {
            return this.currMatch.IsTerminater();
        }

        /// <summary>
        /// Get the value mapped by the currently entered prefix.
        /// </summary>
        /// <returns>The value mapped by the currently entered prefix or null if current prefix does not map to any value.</returns>
        public T GetExactMatch()
        {
            return this.IsExactMatch() ? this.currMatch.Value : null;
        }

    }
}