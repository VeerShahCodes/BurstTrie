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

        public override int Count => throw new NotImplementedException();

        public override BurstNode Insert(string value, int index)
        {
            if (otherNodes[value[index] - 'a' + 1] == null)
            {
                otherNodes[value[index] - 'a' + 1] = new ContainerNode(ParentTrie);
            }
            otherNodes[value[index] - 'a' + 1] = otherNodes[value[index] - 'a' + 1].Insert(value, index + 1);
            return this;

        }

        public override BurstNode? Remove(string value, int index, out bool success)
        {
            otherNodes[value[index] - 'a' + 1] 
            throw new NotImplementedException();
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
