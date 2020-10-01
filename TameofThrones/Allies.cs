using System;
using System.Collections.Generic;
using System.Text;

namespace TameofThrones
{
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
