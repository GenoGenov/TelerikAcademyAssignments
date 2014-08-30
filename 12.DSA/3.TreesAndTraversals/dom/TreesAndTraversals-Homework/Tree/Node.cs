using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T>
    {
        public T Value { get; set; }

        public HashSet<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Children=new HashSet<Node<T>>();
            this.HasParent = false;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode() + this.Children.Sum(x => x.GetHashCode());
        }
    }
}
