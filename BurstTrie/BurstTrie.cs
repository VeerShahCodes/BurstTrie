namespace BurstTrie
{
    public class BurstTrie
    {
        BurstNode Root { get; set; }
        List<string> values => GetAll();
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

            Root = Root.Remove(value, 0, out bool success);
        }

        public BurstNode Search(string prefix)
        {
            return Root.Search(prefix, 0);
        }

        public List<string> GetAll()
        {
            List<string> output = [];
            Root.GetAll(output);
            return output;
        }

        public List<string> BurstSort(List<string> values)
        {
            foreach(string value in values)
            {
                Insert(value);
            }
            List<string> sorted = GetAll();
          
            foreach (string value in values)
            {
                Remove(value);
            }
            return sorted;
        }
    }
}
