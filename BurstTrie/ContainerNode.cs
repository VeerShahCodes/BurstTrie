using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;
namespace BurstTrie
{
    public class ContainerNode : BurstNode
    {
        BinarySearchTree<string> binarySearchTree = new BinarySearchTree<string>();

        List<string> Values => binarySearchTree.BreadthFirstTraversal().Select(x => x.Value).ToList();

        public ContainerNode(BurstTrie parent) : base(parent)
        {
            count = 0;
        }

        private int count;
        public override int Count => count;

        public override BurstNode Insert(string value, int index)
        {
            binarySearchTree.Insert(value);
            count++;
            if (Count >= 5)
            {
                return new InternalNode(this.ParentTrie, Values, index);
            }
            return this;

            // throw new NotImplementedException();
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            success = binarySearchTree.DelNode(value);
            count--;
            if (count == 0) return null;
            return this;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            EqualityComparer<string> equality = EqualityComparer<string>.Create(
                (prefix, value) =>
                {
                    if (prefix.Length > value.Length)
                    {
                        return false;
                    }

                    for (int i = 0; i <= index; i++)
                    {
                        if (prefix[i] != value[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            );

            if (binarySearchTree.FindNode(prefix, equality) != null)
            {
                return this;
            }
            return null;
        }

        internal override void GetAll(List<string> output)
        {
            List<string> values = binarySearchTree.InOrderTraversal().Select(x => x.Value).ToList();
            for (int i = 0; i < values.Count; i++)
            {
                output.Add(values[i]);
            }
        }
    }
}
