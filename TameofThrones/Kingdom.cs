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
                string kingdom = secretMessage.Split(' ', 2)[0];
                string emblemName = kingdomDict[kingdom];

                string encryptedMessage = secretMessage.Split(' ', 2)[1];
                int encryptionKey = emblemName.Length;
                Message message = new Message(encryptedMessage);
                string decryptedMessage = message.Decrypt(encryptionKey);

                Emblem emblem = new Emblem(emblemName);
                Dictionary<char, int> emblemDistinctCharCountDict = emblem.GetDistinctCharCount();

                if (emblem.IsSubsetofMessage(decryptedMessage, emblemDistinctCharCountDict))
                {
                    allyKingdoms.Add(kingdom);
                }

            }

            return allyKingdoms;

        }

    }
}
    
   
    