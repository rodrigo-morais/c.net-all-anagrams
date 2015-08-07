using System;
using System.Collections.Generic;

namespace all_anagrams
{
    public class AllAnagrams
    {
        public static ICollection<string> GetAllAnagrams(string str)
        {
            var root = str.Substring(0, 1);
            var leaves = new List<string>();
            var words = new HashSet<string>();

            foreach (var word in str.Substring(1, str.Length - 1))
            {
                leaves.Add(word.ToString());
            }

            for (var counter = 0; counter < str.Length; counter = counter + 1)
            {
                if (leaves.Count > 0)
                {
                    var last = leaves[leaves.Count - 1];
                    for (var c = 0; c < leaves.Count; c = c + 1)
                    {
                        words.Add(root + string.Concat(leaves.ToArray()));
                        leaves.RemoveAt(leaves.Count - 1);
                        leaves.Insert(0, last);
                        last = leaves[leaves.Count - 1];
                    }

                    leaves.Insert(0, root);
                    root = last;
                    leaves.RemoveAt(leaves.Count - 1);
                }
                else
                {
                    words.Add(str);
                }
            }

            return words;
        }

        public static void Main(string[] args)
        {
            ICollection<string> anagrams = GetAllAnagrams("abba");
            foreach (string a in anagrams)
                Console.WriteLine(a);

            Console.WriteLine("");
            Console.WriteLine("Second");
            Console.WriteLine("");

            anagrams = GetAllAnagrams("aaaaaaaa");
            foreach (string a in anagrams)
                Console.WriteLine(a);

            Console.WriteLine("");
            Console.WriteLine("Third");
            Console.WriteLine("");

            anagrams = GetAllAnagrams("a");
            foreach (string a in anagrams)
                Console.WriteLine(a);

            Console.WriteLine("");
            Console.WriteLine("Fourth");
            Console.WriteLine("");

            anagrams = GetAllAnagrams("abc");
            foreach (string a in anagrams)
                Console.WriteLine(a);

            Console.WriteLine("");
            Console.WriteLine("Fifth");
            Console.WriteLine("");

            anagrams = GetAllAnagrams("aabbccd");
            foreach (string a in anagrams)
                Console.WriteLine(a);

            Console.Read();
        }
    }
}
