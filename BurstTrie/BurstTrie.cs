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
    }
}
