using System.Text.Json;
using BurstTrie;
namespace Consolezproject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BurstTrie.BurstTrie burstTrie = new BurstTrie.BurstTrie();

            //string json = File.ReadAllText("..\\..\\..\\..\\fulldictionary.json");

            //var thing = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            //foreach(var item in thing)
            //{
            //    if (!item.Key.Contains('1') && !item.Key.Contains('/') && !item.Key.Contains(' ') && !item.Key.Contains("'") && !item.Key.Contains('-') && !item.Key.Contains('.') && !item.Key.Contains(',') && !item.Key.Contains('!') && !item.Key.Contains('?') && !item.Key.Contains(':') && !item.Key.Contains(';') && !item.Key.Contains("\"") && !item.Key.Contains('(') && !item.Key.Contains(')') && !item.Key.Contains('[') && !item.Key.Contains(']') && !item.Key.Contains('{') && !item.Key.Contains('}'))
            //    {
            //        burstTrie.Insert(item.Key);

            //    }
            //}
            List<string> list = new List<string>();
            list.Add("hello");
            list.Add("happy");
            list.Add("halloween");
            list.Add("hector");
            
            list = burstTrie.BurstSort(list);
            ;
        }
    }
}
