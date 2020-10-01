using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TameofThrones
{
    public class Kingdom
    {
        private string name;
        public Kingdom(string name)
        {
            this.name = name;
        }
        static void Main(string[] args)
        {
            string secretMessageFileName = args[0];
            Dictionary<string, string> kingdomDict = new Dictionary<string, string>() { {"SPACE", "GORILLA"},
                                                                                   {"LAND", "PANDA"},
                                                                                   {"WATER", "OCTOPUS"},
                                                                                   {"ICE", "MAMMOTH"},
                                                                                   {"AIR", "OWL"},
                                                                                   {"FIRE", "DRAGON"} };
            Kingdom kingdom = new Kingdom("SPACE");
            List<string> allyKingdoms = kingdom.GetAllies(kingdomDict, secretMessageFileName);

            Allies allies = new Allies(kingdom.name, allyKingdoms);
            allies.Print();

        }

        /// <summary>
        /// Function to find the allies of the conquering kingdom
        /// </summary>
        /// <param name="kingdomDict">Dictionary. Key - Kingdom, Value - Emblem</param>
        /// <param name="secretMessageFileName">Full path of the input file</param>
        /// <returns>List of allies</returns>
        public List<string> GetAllies(Dictionary<string, string> kingdomDict, string secretMessageFileName)
        {
            List<string> allyKingdoms = new List<string>();

            string[] secretMessages = File.ReadAllLines(secretMessageFileName);

            foreach (string secretMessage in secretMessages)
            {
                string kingdom = secretMessage.Split(" ")[0];
                string emblemName = kingdomDict[kingdom];

                string encryptedMessage = secretMessage.Split(" ")[1];
                int encryptionKey = emblemName.Length;
                Message message = new Message(encryptedMessage);
                string decryptedMessage = message.Decrypt(encryptionKey);

                Emblem emblem = new Emblem(emblemName);
                Dictionary<char, int> emblemDistinctCharCountDict = emblem.GetDistinctCharCount();

                if(emblem.IsSubsetofMessage(decryptedMessage, emblemDistinctCharCountDict))
                {
                    allyKingdoms.Add(kingdom);
                }

            }

            return allyKingdoms;

        }

    }
    public class Message
    {
        public static int AlphabetCount = 26;
        public static int ASCIIValueofA = 65;
        private string message;
        public Message(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Function to decrypt the given message
        /// </summary>
        /// <param name="encryptionKey"></param>
        /// <returns>Decrypted message</returns>
        public string Decrypt(int encryptionKey)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            for(int i = 0; i < message.Length; i++)
            {
                decryptedMessage.Append(message[i] - encryptionKey < ASCIIValueofA ? ((char)(message[i] - encryptionKey + AlphabetCount)).ToString()
                                                                        : ((char)(message[i] - encryptionKey)).ToString());
            }
            return decryptedMessage.ToString();
        }
    }

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
    public class Allies
    {
        public static int RequiredAllyCount = 3;
        private List<string> allyKingdoms;
        private string conqueringKingdom;
        public Allies(string conqueringKingdom, List<string> allyKingdoms)
        {
            this.conqueringKingdom = conqueringKingdom;
            this.allyKingdoms = allyKingdoms;
        }

        /// <summary>
        /// Prints the conquering kingdom and its allies, 
        /// if the ally count is greater than the specified count.
        /// Else, prints "NONE"
        /// </summary>
        public void Print()
        {
            if (allyKingdoms.Count < RequiredAllyCount)
            {
                Console.WriteLine("NONE");
            }
            else
            {
                Console.Write("{0} ", conqueringKingdom);
                foreach (string kingdom in allyKingdoms)
                {
                    Console.Write("{0} ", kingdom);
                }
            }
        }
    }
}
