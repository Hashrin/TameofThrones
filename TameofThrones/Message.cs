using System;
using System.Collections.Generic;
using System.Text;

namespace TameofThrones
{
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
            for (int i = 0; i < message.Length; i++)
            {
                decryptedMessage.Append(message[i] - encryptionKey < ASCIIValueofA ? ((char)(message[i] - encryptionKey + AlphabetCount)).ToString()
                                                                        : ((char)(message[i] - encryptionKey)).ToString());
            }
            return decryptedMessage.ToString();
        }
    }

}
