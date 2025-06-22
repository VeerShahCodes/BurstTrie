namespace BurstTrie
{
    public class BurstTrie
    {
        BurstNode Root { get; set; }
        public BurstTrie()
        {
            Root = new ContainerNode(this);
        }

        public void Insert(string value)
        {
            Root = Root.Insert(value, 0);
        }

        public void Remove(string value)
        {
            ;
            Root = Root.Remove(value, 0, out bool success);
        }
    }
}
