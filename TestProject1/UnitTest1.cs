using BurstTrie;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            BurstTrie.BurstTrie burstTrie = new BurstTrie.BurstTrie();
            burstTrie.Insert("hello");
            burstTrie.Insert("happy");
            burstTrie.Insert("halloween");
            burstTrie.Insert("hector");
            burstTrie.Insert("apple");
            burstTrie.Insert("salamander");
            burstTrie.Insert("dragon");
            ;
        }
    }
}