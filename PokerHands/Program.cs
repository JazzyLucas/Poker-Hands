using System;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            // Infinite loop so the game keeps replaying
            while (true)
            {
                // Get input from user
                Console.WriteLine("Enter Black's hand:");
                string bPlayer = Console.ReadLine();
                Console.WriteLine("Enter White's hand:");
                string wPlayer = Console.ReadLine();

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
