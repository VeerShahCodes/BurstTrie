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
            burstTrie.Insert("hexagon");
            burstTrie.Insert("hzang");
            ;
        }

        [Fact]

        public void DeleteTest()
        {
            BurstTrie.BurstTrie burstTrie = new BurstTrie.BurstTrie();
            burstTrie.Insert("hello");
            burstTrie.Insert("happy");
            burstTrie.Insert("halloween");
            burstTrie.Insert("hector");
            burstTrie.Insert("hack");
            burstTrie.Insert("apple");
            burstTrie.Insert("salamander");
            burstTrie.Insert("dragon");
            burstTrie.Insert("hexagon");


            burstTrie.Remove("hector");
            burstTrie.Remove("happy");
            burstTrie.Remove("hello");
            burstTrie.Remove("halloween");
            ;
        }

        [Fact]
        public void SearchTest()
        {
            BurstTrie.BurstTrie burstTrie = new BurstTrie.BurstTrie();
            burstTrie.Insert("hello");
            burstTrie.Insert("happy");
            burstTrie.Insert("halloween");
            burstTrie.Insert("hector");
            burstTrie.Insert("hack");
            burstTrie.Insert("apple");
            burstTrie.Insert("salamander");
            burstTrie.Insert("dragon");
            burstTrie.Insert("hexagon");
            var result = burstTrie.Search("hec");
            Assert.NotNull(result);
            result = burstTrie.Search("hax");
            Assert.Null(result);
        }
        [Fact]
        public void GetAllTest()
        {
            BurstTrie.BurstTrie burstTrie = new BurstTrie.BurstTrie();
            burstTrie.Insert("hello");
            burstTrie.Insert("happy");
            burstTrie.Insert("halloween");
            burstTrie.Insert("hector");
            burstTrie.Insert("hack");
            burstTrie.Insert("apple");
            burstTrie.Insert("salamander");
            burstTrie.Insert("dragon");
            burstTrie.Insert("hexagon");
            List<string> allItems = new List<string>();
            allItems = burstTrie.GetAll();
            Assert.Contains("hello", allItems);
            Assert.Contains("happy", allItems);
            Assert.Contains("halloween", allItems);
            Assert.Contains("hector", allItems);
            Assert.Contains("hack", allItems);
            Assert.Contains("apple", allItems);
            Assert.Contains("salamander", allItems);
            Assert.Contains("dragon", allItems);
            Assert.Contains("hexagon", allItems);
            ;
        }
    }
}