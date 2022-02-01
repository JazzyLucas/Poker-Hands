using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }
        public static Dictionary<string, int> valueDict = new Dictionary<string, int>()
        {
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "T", 10 },
            { "J", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 }
        };
        public static Dictionary<int, string> nameDict = new Dictionary<int, string>()
        {
            { 2, "2" },
            { 3, "3" },
            { 4, "4" },
            { 5, "5" },
            { 6, "6" },
            { 7, "7" },
            { 8, "8" },
            { 9, "9" },
            { 10, "10" },
            { 11, "Jack" },
            { 12, "Queen" },
            { 13, "King" },
            { 14, "Ace" }
        };

        public Card(string inputValue, string inputSuit)
        {
            Value = valueDict[inputValue];
            Suit = inputSuit;
        }
    }
}
