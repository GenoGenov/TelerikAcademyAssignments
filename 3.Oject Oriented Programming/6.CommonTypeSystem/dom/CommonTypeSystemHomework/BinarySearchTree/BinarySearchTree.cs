using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> : ICloneable, IEnumerable<T>, IEnumerable<TreeNode<T>>
        where T : IComparable<T>
    {
        private TreeNode<T> root;

        public BinarySearchTree()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            this.NextNode(this.root, nodes);

            foreach (TreeNode<T> node in nodes)
            {
                yield return node;
            }
        }

        public void NextNode(TreeNode<T> node, List<TreeNode<T>> nodes)
        {
            if (node == null)
            {
                return;
            }

            this.NextNode(node.Left, nodes);
            nodes.Add(node);
            this.NextNode(node.Right, nodes);
        }

        public void Add(T item)
        {
            if (item != null)
            {
                this.root = this.Add(item, this.root, null);
            }
            else
            {
                throw new ArgumentException("Item cannot be null.");
            }
        }

        public void Remove(T item)
        {
            TreeNode<T> nodeToDelete = this.Find(item);
            if (nodeToDelete == null)
            {
                return;
            }

            this.Remove(nodeToDelete);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.root != null)
            {
                this.ToStringRecursive(this.root, ref result);
            }
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            BinarySearchTree<T> other = obj as BinarySearchTree<T>;

            if (other == null)
            {
                return false;
            }

            return this.EqualsRecursive(this.root, other.root);
        }

        public BinarySearchTree<T> Clone()
        {
            BinarySearchTree<T> clone = new BinarySearchTree<T>();
            this.Copy(clone, this.root);
            return clone;
        }

        public override int GetHashCode()
        {
            int hashCode = 7;

            foreach (TreeNode<T> node in this)
            {
                hashCode ^= node.Data.GetHashCode();
            }
            return hashCode;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (this.root != null)
            {
                if (this.root.Left != null)
                {
                    foreach (TreeNode<T> node in this.root.Left)
                    {
                        yield return node.Data;
                    }
                }

                yield return this.root.Data;

                if (this.root.Right != null)
                {
                    foreach (TreeNode<T> node in this.root.Right)
                    {
                        yield return node.Data;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        private TreeNode<T> Add(T item, TreeNode<T> node, TreeNode<T> parentNode)
        {
            if (node == null)
            {
                node = new TreeNode<T>(item);
                node.Parent = parentNode;

                this.Count++;
            }
            else
            {
                if (node.Data.CompareTo(item) > 0)
                {
                    node.Left = this.Add(item, node.Left, node);
                }
                else if (node.Data.CompareTo(item) < 0)
                {
                    node.Right = this.Add(item, node.Right, node);
                }
            }

            return node;
        }

        private void Copy(BinarySearchTree<T> clone, TreeNode<T> node)
        {
            if (node != null)
            {
                clone.Add(node.Data);
                this.Copy(clone, node.Left);
                this.Copy(clone, node.Right);
            }
        }

        private TreeNode<T> Find(T item)
        {
            TreeNode<T> node = this.root;

            while (node != null)
            {
                if (node.Data.CompareTo(item) > 0)
                {
                    node = node.Left;
                }
                else if (node.Data.CompareTo(item) < 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        private void Remove(TreeNode<T> node)
        {
            if (node.Left != null && node.Right != null)
            {
                TreeNode<T> tempNode = this.Min(node.Right);
                node.Data = tempNode.Data;
                node = tempNode;
            }

            TreeNode<T> successor = node.Left != null ? node.Left : node.Right;

            if (successor != null)
            {
                successor.Parent = node.Parent;
            }

            if (node.Parent == null)
            {
                this.root = successor;
            }
            else
            {
                if (node == node.Parent.Left)
                {
                    node.Parent.Left = successor;
                }
                else
                {
                    node.Parent.Right = successor;
                }
            }

            this.Count--;
        }

        private TreeNode<T> Min(TreeNode<T> node)
        {
            TreeNode<T> min = node;

            while (min.Left != null)
            {
                min = min.Left;
            }

            return min;
        }

        private bool EqualsRecursive(TreeNode<T> a, TreeNode<T> b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            else if (a != null && b != null && a == b)
            {
                return this.EqualsRecursive(a.Left, b.Left) && this.EqualsRecursive(a.Right, b.Right);
            }
            else
            {
                return false;
            }
        }

        private void ToStringRecursive(TreeNode<T> node, ref StringBuilder result)
        {
            if (node != null)
            {
                this.ToStringRecursive(node.Left, ref result);
                this.ToStringRecursive(node.Right, ref result);
                result.AppendLine(node.ToString());
            }
            else
            {
                return;
            }
        }

        public static bool operator ==(BinarySearchTree<T> a, BinarySearchTree<T> b)
        {
            return BinarySearchTree<T>.Equals(a, b);
        }

        public static bool operator !=(BinarySearchTree<T> a, BinarySearchTree<T> b)
        {
            return !(BinarySearchTree<T>.Equals(a, b));
        }
    }
}