using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR18._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            List<string> order = new List<string>();
            string str = Console.ReadLine();
            while (str != "")
            {
                string strL = str.ToLower();
                string[] words = strL.Split(
                    new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '(', ')', '[', ']', '{', '}', '"' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (wordsCount.TryGetValue(word, out int count))
                    {
                        wordsCount[word] = count + 1;
                    }
                    else
                    {
                        wordsCount.Add(word, 1);
                        order.Add(word);
                    }
                }
                str = Console.ReadLine();
            }
            foreach (string word in order)
            {
                Console.WriteLine($"{word}: {wordsCount[word]}");
            }
            string maxWord = "";
            int maxCount = 0;
            foreach (string word in order)
            {
                if (wordsCount[word] > maxCount)
                {
                    maxCount = wordsCount[word];
                    maxWord = word;
                }
            }
            Console.WriteLine($"Самое частое слово: {maxWord} (повторяется {maxCount} раз(а))");
        }
    }
}
