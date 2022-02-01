using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerHands
{
    class Hand
    {
        public Card[] Cards { get; set; }
        public float Value { get; set; }
        public string WinReason { get; set; }
        public string WinningCard { get; set; }
        public Hand(Card[] cardsInput)
        {
            Cards = cardsInput;

            // Sort hand by card value
            Cards = SortCards();

            // Get the value of the hand and assign it
            Value = GetHandValue();
        }
        Card[] SortCards()
        {
            Card[] sorted = Cards.OrderBy(c => c.Value).ToArray();
            return sorted;
        }
        float GetHandValue()
        {
            // Value variables used for displaying winning card, and for tie breakers
            int value;
            int value2;
            int value3;
            int value4;
            if (IsStraightFlush(out value))
            {
                WinReason = "straight flush";
                WinningCard = Card.nameDict[value];
                return 9f + value * .01f;
            }
            else if (IsFourOfAKind(out value))
            {
                WinReason = "four of a kind";
                WinningCard = Card.nameDict[value];
                return 8f + value * .01f;
            }
            else if (IsFullHouse(out value, out value2))
            {
                WinReason = "full house";
                WinningCard = Card.nameDict[value] + " over " + Card.nameDict[value2];
                return 7f + value * .01f;
            }
            else if (IsFlush(out value))
            {
                WinReason = "flush";
                WinningCard = Card.nameDict[Cards[4].Value];
                return 6f + value * .000001f;
            }
            else if (IsStraight(out value))
            {
                WinReason = "straight";
                WinningCard = Card.nameDict[value];
                return 5f + value * .01f;
            }
            else if (IsThreeOfAKind(out value))
            {
                WinReason = "three of a kind";
                WinningCard = Card.nameDict[value];
                return 4f + value * .01f;
            }
            else if (IsTwoPairs(out value, out value2, out value3))
            {
                WinReason = "two pairs";
                WinningCard = Card.nameDict[value];
                return 3f + value * .01f + value2 * .001f + value3 * .0001f;
            }
            else if (IsPair(out value, out value2, out value3, out value4))
            {
                WinReason = "pair";
                WinningCard = Card.nameDict[value];
                return 2f + value * .01f + value2 * .001f + value3 * .0001f + value4 * .00001f;
            }
            else
            {
                WinReason = "high card";
                WinningCard = Card.nameDict[Cards[4].Value];
                return GetHighCardValue();
            }
        }
        bool IsStraightFlush(out int value)
        {
            string suit = Cards[0].Suit;
            int counter = Cards[0].Value;
            value = 0;
            for (int i = 0; i < 5; i++)
            {
                // Check if all suits are the same
                if (Cards[i].Suit != suit)
                {
                    return false;
                }
                // Check if numbers are sequential
                if (Cards[i].Value != counter)
                {
                    return false;
                }
                counter++;
            }
            value = Cards[4].Value;
            return true;
        }
        bool IsFourOfAKind(out int value)
        {
            value = 0;
            for (int i = 0; i < 2; i++)
            {
                // Check if first 4 values are the same, then checks if last 4 values are the same
                if (Cards[i].Value == Cards[i + 1].Value && Cards[i + 1].Value == Cards[i + 2].Value && Cards[i + 2].Value == Cards[i + 3].Value)
                {
                    value = Cards[i].Value;
                    return true;
                }
            }
            return false;
        }
        bool IsFullHouse(out int value, out int value2)
        {
            value = 0;
            value2 = 0;
            for (int i = 0; i < 3; i += 2)
            {
                // Check if first 3 values are the same, then checks if last 3 values are the same
                if (Cards[i].Value == Cards[i + 1].Value && Cards[i + 1].Value == Cards[i + 2].Value)
                {
                    // If first iteration
                    if (i == 0)
                    {
                        // Check if last 2 cards are a pair
                        if (Cards[3].Value == Cards[4].Value)
                        {
                            value = Cards[0].Value;
                            value2 = Cards[3].Value;
                            return true;
                        }
                    }
                    // If second iteration
                    else
                    {
                        // Check if first 2 cards are a pair
                        if (Cards[0].Value == Cards[1].Value)
                        {
                            value = Cards[2].Value;
                            value2 = Cards[0].Value;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        bool IsFlush(out int value)
        {
            value = 0;
            string suit = Cards[0].Suit;
            for (int i = 0; i < 5; i++)
            {
                // Check if all suits are the same
                if (Cards[i].Suit != suit)
                {
                    return false;
                }
            }
            value = (int)(GetHighCardValue() * 100000);
            return true;
        }
        bool IsStraight(out int value)
        {
            value = 0;
            int counter = Cards[0].Value;
            // Check if numbers are sequential
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i].Value != counter)
                {
                    return false;
                }
                counter++;
            }
            value = Cards[4].Value;
            return true;
        }
        bool IsThreeOfAKind(out int value)
        {
            value = 0;
            for (int i = 0; i < 3; i += 2)
            {
                // Check if first 3 values are the same, then checks if last 3 values are the same
                if (Cards[i].Value == Cards[i + 1].Value && Cards[i + 1].Value == Cards[i + 2].Value)
                {
                    value = Cards[i].Value;
                    return true;
                }
            }
            return false;
        }
        bool IsTwoPairs(out int value, out int value2, out int value3)
        {
            value = 0;
            value2 = 0;
            value3 = 0;
            int numberOfPairs = 0;
            for (int i = 0; i < 4; i++)
            {
                // Check if there are two cards of the same value
                if (Cards[i].Value == Cards[i + 1].Value)
                {
                    if (numberOfPairs == 0)
                    {
                        value2 = Cards[i].Value;
                    }
                    else
                    {
                        value = Cards[i].Value;
                    }
                    numberOfPairs += 1;
                }
            }
            // Dirty way to get leftover card
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i].Value != value || Cards[i].Value != value2)
                {
                    value3 = Cards[i].Value;
                }
            }
            return numberOfPairs == 2;
        }
        bool IsPair(out int value, out int value2, out int value3, out int value4)
        {
            value = 0;
            value2 = 0;
            value3 = 0;
            value4 = 0;
            for (int i = 0; i < 4; i++)
            {
                // Check if there are two cards of the same value
                if (Cards[i].Value == Cards[i + 1].Value)
                {
                    value = Cards[i].Value;

                    // Dirty way to get leftover cards
                    int counter = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (Cards[j].Value != value && counter == 0)
                        {
                            counter++;
                            value4 = Cards[j].Value;
                        }
                        else if (Cards[j].Value != value && counter == 1)
                        {
                            counter++;
                            value3 = Cards[j].Value;
                        }
                        else if (Cards[j].Value != value && counter == 2)
                        {
                            value2 = Cards[j].Value;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        float GetHighCardValue()
        {
            // Using decimals for tie comparisons
            return (Cards[4].Value * .01f) + (Cards[3].Value * .001f) + (Cards[2].Value * .0001f) + (Cards[1].Value * .00001f) + (Cards[0].Value * .000001f);
        }
    }
}