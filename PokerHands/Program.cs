using System;
using System.Collections.Generic;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            var argQueue = new Queue<string>();
            foreach (var s in args)
                argQueue.Enqueue(s);
            // Infinite loop so the game keeps replaying
            while (true)
            {
                string bPlayer;
                string wPlayer;
                if (argQueue.Count < 2)
                {
                    // Get input from user
                    Console.WriteLine("Enter Black's hand:");
                    bPlayer = Console.ReadLine();
                    Console.WriteLine("Enter White's hand:");
                    wPlayer = Console.ReadLine();
                }
                else
                {
                    bPlayer = argQueue.Dequeue();
                    wPlayer = argQueue.Dequeue();
                }

                // Split string into array of cards
                string[] bCardStringArray = bPlayer.Split(" ");
                string[] wCardStringArray = wPlayer.Split(" ");

                // Convert the string array into a hand object
                Hand bHand = ConvertCardStringArrayToHand(bCardStringArray);
                Hand wHand = ConvertCardStringArrayToHand(wCardStringArray);

                if (bHand.Value > wHand.Value)
                {
                    Console.WriteLine("Black wins. - with " + bHand.WinReason + ": " + bHand.WinningCard);
                    Console.WriteLine(bHand.Value);
                    Console.WriteLine(wHand.Value);
                }
                else if (bHand.Value < wHand.Value)
                {
                    Console.WriteLine("White wins. - with " + wHand.WinReason + ": " + wHand.WinningCard);
                }
                else
                {
                    Console.WriteLine("Tie.");
                }
            }
        }

        static Hand ConvertCardStringArrayToHand(string[] cardStringArray)
        {
            // Creates a hand object from a card string array
            Card[] cardsArray = ConvertCardStringArrayToCards(cardStringArray);
            Hand hand = new Hand(cardsArray);
            return hand;
        }
        static Card[] ConvertCardStringArrayToCards(string[] cardStringArray)
        {
            Card[] cardArray = new Card[5];
            for (int i = 0; i < 5; i++)
            {
                // Create a new card for each element in the array, and set it in the new Card[] array
                cardArray[i] = new Card(cardStringArray[i][0].ToString(), cardStringArray[i][1].ToString());
            }
            return cardArray;
        }
    }
}
