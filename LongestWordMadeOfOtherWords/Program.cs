using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a list of words, find out the longest word, 
// if any, that can be formed by other words in the list
namespace LongestWordMadeOfOtherWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input1 = new List<string>();
            input1.Add("ab");
            input1.Add("cd");
            input1.Add("ef");
            input1.Add("abcdef");

            string result1 = GetLongestWordMadeOfOtherWords(input1);

            Console.WriteLine("Test 1: Longest word that can be formed is {0}", result1);

            List<string> input2 = new List<string>();
            input2.Add("water");
            input2.Add("melon");
            input2.Add("waterbottle");
            input2.Add("watermelon");

            string result2 = GetLongestWordMadeOfOtherWords(input2);

            Console.WriteLine("Test 2: Longest word that can be formed is {0}", result2);
        }

        static string GetLongestWordMadeOfOtherWords(List<string> words)
        {
            HashSet<string> hashSet = new HashSet<string>(words);

            words.Sort(SortByLengthDescending);

            foreach (string currentWord in words)
            {
                if (CanWordBeFormed(currentWord, hashSet, true))
                {
                    return currentWord;
                }
            }

            return null;
        }

        static bool CanWordBeFormed(string inputWord, HashSet<string> words, bool isOriginalWord)
        {
            if (words.Contains(inputWord) && !isOriginalWord)
            {
                return true;
            }

            for (int i = 1; i < inputWord.Length; i++)
            {
                string firstPart = inputWord.Substring(0, i);
                string secondPart = inputWord.Substring(i);

                if (words.Contains(firstPart) && CanWordBeFormed(secondPart, words, false))
                {
                    return true;
                }
            }

            return false;
        }

        static int SortByLengthDescending(string first, string second)
        {
            return first.Length > second.Length ? -1 : 1;
        }
    }
}
