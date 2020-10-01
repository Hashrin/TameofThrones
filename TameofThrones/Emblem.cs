using System;
using System.Collections.Generic;
using System.Text;

namespace TameofThrones
{
    public class Emblem
    {
        private string name;
        public Emblem(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Creates a dictionary of distinct emblem characters with their counts as values
        /// </summary>
        /// <returns> Dictionary. Key - distinct characters in the given emblem, value - counts</returns>
        public Dictionary<char, int> GetDistinctCharCount()
        {
            Dictionary<char, int> distinctCharCountDict = new Dictionary<char, int>();
            for (int i = 0; i < name.Length; i++)
            {
                if (distinctCharCountDict.ContainsKey(name[i]))
                {
                    distinctCharCountDict[name[i]] += 1;
                }
                else
                {
                    distinctCharCountDict.Add(name[i], 1);
                }
            }
            return distinctCharCountDict;
        }

        /// <summary>
        /// Checks whether the emblem is a subset of the decrypted message
        /// </summary>
        /// <param name="decryptedMessage">Decrypted message</param>
        /// <param name="distinctCharCountDict">Dictionary. Key - distinct characters in the given emblem, value - counts</param>
        /// <returns></returns>
        public bool IsSubsetofMessage(string decryptedMessage, Dictionary<char, int> distinctCharCountDict)
        {
            for (int i = 0; i < decryptedMessage.Length; i++)
            {
                if (distinctCharCountDict.ContainsKey(decryptedMessage[i]))
                {
                    distinctCharCountDict[decryptedMessage[i]] -= 1;
                }

            }

            int count = 0;
            foreach (var item in distinctCharCountDict)
            {
                if (item.Value <= 0)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            int distinctCharsinEmblem = distinctCharCountDict.Count;
            return count == distinctCharsinEmblem ? true : false;

        }

    }
}
