using System;
using System.Collections.Generic;
using System.Linq;
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
            if(Count >= 5)
            {
                return new InternalNode(this.ParentTrie, Values, index);
            }
            return this;
            
           // throw new NotImplementedException();
        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            binarySearchTree.DelNode(value);
            count--;
            success = true;
            return this;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            throw new NotImplementedException();
        }

        internal override void GetAll(List<string> output)
        {
            throw new NotImplementedException();
        }
    }
}
