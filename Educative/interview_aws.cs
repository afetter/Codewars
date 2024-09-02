using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Result
{

    /*
     * Complete the 'countGroups' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY related as parameter.
      Gifiting groups
     */

    public static int countGroups(List<string> related)
    {
        var visited = Enumerable.Repeat(false, related.Count).ToList<bool>();
        var groups = 0;
        for (int i = 0; i < related.Count; i++){
            if (!visited[i]){
                DFS(related, visited, i, related.Count);
                groups++;
            }
        }
        
        return groups;

        void DFS(List<string> matrix, List<bool> visited, int user, int length){
            visited[user] = true;
            for (int i = 0; i < length; i++){
                if (matrix[user][i] == '1' && !visited[i]){
                    DFS(matrix, visited, i, length);
                }
            }
        }    
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int relatedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> related = new List<string>();

        for (int i = 0; i < relatedCount; i++)
        {
            string relatedItem = Console.ReadLine();
            related.Add(relatedItem);
        }

        int result = Result.countGroups(related);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'minimalHeaviestSetA' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
  Optimizing Box weights
     */

    public static List<int> minimalHeaviestSetA(List<int> arr)
    {
        var result = new List<int>();
        var sorted = arr.OrderByDescending(n => n).ToList();
        
        var target = arr.Sum() / 2;
        
        for (int i = 0; i < sorted.Count(); i++){
            if (result.Sum() > target){
                break;
            }
            result.Add(sorted[i]);
        }
        result.Reverse();
        return result; 
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < arrCount; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        List<int> result = Result.minimalHeaviestSetA(arr);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
