using System;
using System.Collections.Generic;
using TameofThrones;
using Xunit;

namespace TameofThronesTest
{
    public class EmblemUnitTests
    {
        [Fact]
        public void EmblemDistinctCharTest()
        {
            Emblem emblem = new Emblem("MAMMOTH");
            Dictionary<char, int> expectedDistinctCharCountDict = new Dictionary<char, int>() { { 'M', 3}, { 'A', 1}, { 'O', 1 },
                                                                                                { 'T', 1 }, { 'H', 1 } };
            Dictionary<char, int> actualDistinctCharCountDict = emblem.GetDistinctCharCount();
            Assert.Equal(expectedDistinctCharCountDict, actualDistinctCharCountDict);
        }

        [Fact]
        public void CheckifEmblemisaSubsetofDecryptedMessage()
        {
            string decryptedMessage = "LADSWNWOO";
            Emblem emblem = new Emblem("OWL");
            Dictionary<char, int> distinctCharCountDict = new Dictionary<char, int>() { { 'O', 1}, { 'W', 1}, { 'L', 1 } };
            Assert.True(emblem.IsSubsetofMessage(decryptedMessage, distinctCharCountDict));
        }
    }
}
