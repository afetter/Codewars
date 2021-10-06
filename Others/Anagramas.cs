using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Others
{
    public class Anagramas
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> list = new List<int>();
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) return list;
            
            if (s.Length < p.Length) return list;
            
            var pMap = new Dictionary<char, int>();
            var sMap = new Dictionary<char, int>();
            
            foreach (var ch in p) 
                pMap[ch] = pMap.ContainsKey(ch) ? pMap[ch] + 1 : 1;

            var queue = new Queue<char>();
            var output = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];
                queue.Enqueue(s[i]);
                sMap[ch] = sMap.ContainsKey(ch) ? sMap[ch] + 1 : 1;
                if (queue.Count > p.Length)
                {
                    sMap[queue.Dequeue()]--;
                }
                //do not use else if, use if
                if (queue.Count == p.Length)
                {
                    bool isSame = pMap.Keys.All(x => sMap.ContainsKey(x) && sMap[x] == pMap[x]);
                    //do not use else pMap.Length, use p.Length
                    if (isSame) output.Add(i - p.Length + 1);
                }
            }
            return output;
        }
    }
}
