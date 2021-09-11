using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Codewars
{
    public static class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            var line = text.Split("\n");
            foreach (var item in commentSymbols)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    var index = line[i].IndexOf(item);
                    if (index != -1)
                    {
                        line[i] = line[i].Substring(0, index).TrimEnd();
                    }
                    else
                    {
                        line[i] = line[i].TrimEnd();
                    }
                }
            }
            
            return string.Join("\n", line);
        }

        //Best Solution
        public static string StripComments1(string text, string[] commentSymbols)
        {
            string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
            lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
            return string.Join("\n", lines);
        }
    }
}
