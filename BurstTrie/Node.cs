using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node<T>
    {
        public T Value;
        public Node<T> LeftChild;
        public Node<T> RightChild;

        public Node(T value)
        {
            Value = value;
        }
    }
}
