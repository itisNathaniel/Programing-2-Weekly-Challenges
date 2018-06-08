using System;
using System.IO;
using System.Collections.Generic;

namespace NameRank
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // store ranks in dictionary
            Dictionary<string, int> wordRank = new Dictionary<string, int>();

            // dictionary letter scores
            Dictionary<char, int> letterValue = new Dictionary<char, int>();
            const string theAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int position = 1;
            foreach(char c in theAlphabet)
            {
                letterValue.Add(c, position);
                position++;
            }

            // Import our names
            List<string> names = new List<string>();
            using (StreamReader wordList = new StreamReader("names.txt"))
            {
                while(true) 
                {
                    string thisLine = wordList.ReadLine();
                    if (thisLine == null)
                    {
                        break;
                    }
                    names.Add(thisLine);
                }

            }

            // Sort our names
            names.Sort();

            // look up names in alphabet 
            int rankcount = 1;
            foreach(string name in names)
            {
                int nameScore = 0;
                foreach(char c in name)
                {
                    int letterscore = 0;
                    letterValue.TryGetValue(c, out letterscore);
                    nameScore += letterscore;
                }

                int NewNameScore = nameScore * rankcount;
                wordRank.Add(name, NewNameScore);
                rankcount++;
            }

            // print output and calculate cumulative
            int nameScoreSoFar = 0;
            foreach(string name in names) 
            {
                int score = 0;
                wordRank.TryGetValue(name, out score);
                nameScoreSoFar += score;
                Console.WriteLine("{0} scored {1} - cumulative {2}", name, score, nameScoreSoFar);

            }

            Console.ReadKey();
        }
    }
}
