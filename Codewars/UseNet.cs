using System.Collections.Generic;

namespace Codewars
{
    /// <summary>
    /// Description:
    /// How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.
    /// I found this joke on USENET, but the punchline is scrambled.Maybe you can decipher it? According to Wikipedia, ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.
    /// Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc. Test examples:
    /// rot13("EBG13 rknzcyr.") == "ROT13 example.";
    /// rot13("This is my first ROT13 excercise!" == "Guvf vf zl svefg EBG13 rkprepvfr!"
    /// </summary>
    public static class UseNet
    {
        static string Input = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        static string output = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";

        public static string Rot13(string input)
        {
            var result = string.Empty;
            var dic = new Dictionary<char, char>();
            for (int i = 0; i < Input.Length; i++)
            {
                dic.Add(Input[i], output[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (dic.ContainsKey(input[i]))
                    result += dic[input[i]];
                else
                    result += input[i];
            }

            return result;
        }
        // Best Solution
        //public static string Rot13(string input)
        //{
        //    var s1 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
        //    var s2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //    return string.Join("", input.Select(x => char.IsLetter(x) ? s1[s2.IndexOf(x)] : x));
        //}
    }
}
