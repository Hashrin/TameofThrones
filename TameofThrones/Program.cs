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
            List<string> allyKingdoms = kingdom.GetAllies(kingdom.name, kingdomDict, secretMessageFileName);

            Allies allies = new Allies(allyKingdoms);
            allies.Print();

        }

        public List<string> GetAllies(string conqueringKingdom, Dictionary<string, string> kingdomDict, string secretMessageFileName)
        {
            List<string> allyKingdoms = new List<string>() { conqueringKingdom };

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
                Dictionary<char, int> emblemDistinctCharCountDict = emblem.CreateDistinctCharCountDict();

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
        public Dictionary<char, int> CreateDistinctCharCountDict()
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
        private List<string> allyKingdoms;
        public Allies(List<string> allyKingdoms)
        {
            this.allyKingdoms = allyKingdoms;
        }

        public void Print()
        {
            if (allyKingdoms.Count < 4)
            {
                Console.WriteLine("NONE");
            }
            else
            {
                foreach (string kingdom in allyKingdoms)
                {
                    Console.Write("{0} ", kingdom);
                }
            }
        }
    }
}
