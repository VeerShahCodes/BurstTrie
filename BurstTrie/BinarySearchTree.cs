using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root;

        public void Insert(T value)
        {
            Node<T> Current = Root;

            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }
            while (true)
            {

                if (value.CompareTo(Current.Value) < 0)
                {
                    if(Current.LeftChild != null)
                    {
                        Current = Current.LeftChild;
                    }
                    else
                    {
                        Current.LeftChild = new Node<T>(value);
                        return;
                    }

                    
                }
                else if (value.CompareTo(Current.Value) > 0)
                {
                    if(Current.RightChild != null)
                    {
                        Current = Current.RightChild;
                    }
                    else
                    {
                        Current.RightChild = new Node<T>(value);
                        return;
                    }
                }
                else if(value.Equals(Current.Value))
                {
                    throw new Exception("no");
                }
            }

        }

        public Node<T> FindNode(T value)
        {
            Node<T> current = Root;

            if(Root.LeftChild == null && Root.RightChild == null)
            {
                throw new Exception("there is no wwere to go");
            }
            else
            {
                while (!current.Value.Equals(value))
                {
                    if (value.CompareTo(current.Value) < 0)
                    {
                        current = current.LeftChild;

                    }
                    else if(value.CompareTo(current.Value) > 0)
                    {
                        current = current.RightChild;

                    }
                }
                return current;
            }
        }
        public bool DelNode(T value)
        {

            Node<T> current = Root;
            Node<T> currentParent = Root;
            bool right = false;
            if (Root.LeftChild == null && Root.RightChild == null)
            {
                if(value.CompareTo(Root.Value) == 0)
                {
                    Root = null;
                    return true;
                }
                return false;
            }
            else
            {
                while (!current.Value.Equals(value))
                {
                    if (value.CompareTo(current.Value) < 0)
                    {
                        currentParent = current;
                        current = current.LeftChild;
                        right = false;

                    }
                    else if (value.CompareTo(current.Value) > 0)
                    {
                        currentParent = current;
                        current = current.RightChild;
                        right = true;

                    }
                }
              
            }
            if (current.LeftChild == null && current.RightChild == null)
            {
                if(right == true)
                {
                    currentParent.RightChild = null;
                }
                else
                {
                    currentParent.LeftChild = null;
                }
            }
            else if(current.LeftChild != null && current.RightChild == null)
            {
                if(current == Root)
                {
                    Root = current.LeftChild;
                 //   current = current.LeftChild;
                }
                else
                {
                    if (right == true)
                    {
                        currentParent.RightChild = current.LeftChild;
                    }
                    else
                    {
                        currentParent.LeftChild = current.LeftChild;
                    }
                }

            }
            else if (current.LeftChild == null && current.RightChild != null)
            {
                if(current == Root)
                {
                    Root = current.RightChild;
                    //current = current.RightChild;
                    
                }
                else
                {
                    if (right == true)
                    {
                        currentParent.RightChild = current.RightChild;
                    }
                    else
                    {
                        currentParent.LeftChild = current.RightChild;
                    }
                }

            }
            else
            {
                Node<T> currentTwo = current.LeftChild;
                Node<T> currentTwoParent = current;
                bool left = true;
                while(currentTwo.RightChild != null)
                {
                    currentTwoParent = currentTwo;
                    currentTwo = currentTwo.RightChild;
                    left = false;
                }

                current.Value = currentTwo.Value;
                if(left == false)
                {
                    currentTwoParent.RightChild = null;

                }
                else
                {
                    if(currentTwo.LeftChild != null)
                    {
                        currentTwoParent.LeftChild = currentTwo.LeftChild;

                    }
                    else if(current.RightChild != null)
                    {
                        currentTwoParent.LeftChild = currentTwo.RightChild;
                    }
                    else {
                        currentTwoParent.LeftChild = null;
                    }
                }

                

            }
            return true;

            
        }

        public List<Node<T>> PreOrderTraversal()
        {
            Stack<Node<T>> Stack = new Stack<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();
            Stack.Push(Root);

            while(Stack.Count > 0)
            {
                Node<T> current = Stack.Pop();
                list.Add(current);
                if (current.RightChild != null)
                {
                    Stack.Push(current.RightChild);

                }
                if (current.LeftChild != null)
                {
                    Stack.Push(current.LeftChild);

                }
            }

            return list;

        }


        public List<Node<T>> InOrderTraversal()
        {
            Stack<Node<T>> Stack = new Stack<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();

            Stack.Push(Root);

            while (Stack.Count > 0)
            {
                Node<T> current = Stack.Peek();
                
                if (current.LeftChild != null && !list.Contains(current.LeftChild))
                { 
                    Stack.Push(current.LeftChild);
                }
                else if((current.LeftChild == null || list.Contains(current.LeftChild)) && (current.RightChild == null || !list.Contains(current.RightChild)))
                {
                    list.Add(Stack.Pop());

                    if(current.RightChild != null) Stack.Push(current.RightChild);
                }

                
            }

            return list;
        }

        public List<Node<T>> PostOrderTraversal()
        {
            Stack<Node<T>> Stack = new Stack<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();

            Stack.Push(Root);

            while(Stack.Count > 0)
            {
                Node<T> current = Stack.Peek();

                if(current.LeftChild != null && !list.Contains(current.LeftChild))
                {
                    Stack.Push(current.LeftChild);
                }
                else if(current.RightChild != null && !list.Contains(current.RightChild))
                {
                    Stack.Push(current.RightChild);
                }
                else
                {
                    list.Add(Stack.Pop());
                }
            }

            return list;
        }

        public List<Node<T>> BreadthFirstTraversal()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<Node<T>> list = new List<Node<T>>();

            queue.Enqueue(Root);

            while(queue.Count > 0)
            {
                Node<T> current = queue.Dequeue();
                list.Add(current);
                if(current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }
                if(current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return list;
            
        }




    }
}
