using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurstTrie
{
    public class InternalNode : BurstNode
    {
        public BurstNode[] otherNodes;
        public InternalNode(BurstTrie parent) : base(parent)
        {
            otherNodes = new BurstNode[27];
        
        }
        public InternalNode(BurstTrie parent, List<string> Values, int index) : base(parent)
        {
            otherNodes = new BurstNode[27];
            for(int i = 0; i < Values.Count; i++)
            {
                Insert(Values[i], index);
            }
        }

        private int count;
        public override int Count => count;

        public override BurstNode Insert(string value, int index)
        {
            if (index >= value.Length)
            {
                if (otherNodes[0] == null)
                {
                    otherNodes[0] = new ContainerNode(ParentTrie);

                }


                otherNodes[0].Insert(value, index);
                return this;
            }
            if (otherNodes[value[index] - 'a' + 1] == null)
            {
                otherNodes[value[index] - 'a' + 1] = new ContainerNode(ParentTrie);
            }
            if(index < value.Length - 1)
            {
                otherNodes[value[index] - 'a' + 1] = otherNodes[value[index] - 'a' + 1].Insert(value, index + 1);

            }
            else
            {
                otherNodes[value[index] - 'a' + 1] = otherNodes[value[index] - 'a' + 1].Insert(value, index);
            }

            count++;
            return this;

        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            
            if (otherNodes[value[index] - 'a' + 1] == null)
            {
                success = false;
                return null;
            }
            otherNodes[value[index] - 'a' + 1] = otherNodes[value[index] - 'a' + 1].Remove(value, index + 1, out success);
            count--;
            return this;
        }

        public override BurstNode? Search(string prefix, int index)
        {
            if (otherNodes[prefix[index] - 'a' + 1] == null)
            {
                return null;
            }
            return otherNodes[prefix[index] - 'a' + 1].Search(prefix, index + 1);
        }

        internal override void GetAll(List<string> output)
        {
            for(int i = 0; i < otherNodes.Length; i++)
            {
                if (otherNodes[i] != null)
                {
                    otherNodes[i].GetAll(output);
                }
            }
        }
    }
}
