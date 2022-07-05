using System;
using System.Collections.Generic;

namespace P03.Cards
{
    public class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                if (!isFaceValid(value))
                {
                    throw new InvalidOperationException();
                }

                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            private set
            {
                if (!isSuiteValid(value))
                {
                    throw new InvalidOperationException();
                }

                value = GetSuitSymbol(value);
                suit = value;
            }
        }

        private bool isFaceValid(string input)
        {
            List<string> validFaces = new List<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };

            if (validFaces.Contains(input))
            {
                return true;
            }

            return false;
        }

        private bool isSuiteValid(string input)
        {
            List<string> validSuits = new List<string>
            {
                        "S", "H", "D", "C"
            };

            if (validSuits.Contains(input))
            {
                return true;
            }

            return false;
        }

        private string GetSuitSymbol(string suiteLetter)
        {
            string suitSymbol = string.Empty;

            if (suiteLetter == "S")
            {
                suitSymbol = "\u2660";
            }

            else if (suiteLetter == "H")
            {
                suitSymbol = "\u2665";
            }

            else if (suiteLetter == "D")
            {
                suitSymbol = "\u2666";
            }

            else if (suiteLetter == "C")
            {
                suitSymbol = "\u2663";
            }

            return suitSymbol;
        }

        public override string ToString()
            => $"[{this.Face}{this.Suit}]";
    }
}
