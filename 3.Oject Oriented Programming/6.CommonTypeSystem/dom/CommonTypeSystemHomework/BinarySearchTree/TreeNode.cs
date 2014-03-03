using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTree
{
    public class TreeNode<T> : IComparable<TreeNode<T>>
        where T : IComparable<T>
    {
        public TreeNode(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public TreeNode<T> Parent { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public int CompareTo(TreeNode<T> other)
        {
            return this.Data.CompareTo(other.Data);
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            if (this.Left != null)
            {
                foreach (TreeNode<T> node in this.Left)
                {
                    yield return node;
                }
            }

            yield return this;

            if (this.Right != null)
            {
                foreach (TreeNode<T> node in this.Right)
                {
                    yield return node;
                }
            }
        }

        public override string ToString()
        {
            return this.Data.ToString();
        }

        public override int GetHashCode()
        {
            return this.Data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> node = obj as TreeNode<T>;

            if (node == null)
            {
                return false;
            }

            return this.Data.CompareTo(node.Data) == 0;
        }

        public static bool operator ==(TreeNode<T> first, TreeNode<T> second)
        {
            return TreeNode<T>.Equals(first, second);
        }

        public static bool operator !=(TreeNode<T> first, TreeNode<T> second)
        {
            return !(TreeNode<T>.Equals(first, second));
        }
    }
}