using System;
using System.Collections.Generic;

namespace P03.Cards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] inputLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string card in inputLine)
            {
                try
                {
                    string[] cardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string face = cardInfo[0];
                    string suit = cardInfo[1];

                    Card cardToAdd = new Card(face, suit);

                    cards.Add(cardToAdd);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid card!");
                    continue;
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}


