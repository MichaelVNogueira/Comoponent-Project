/*
 * File:        Card.cs
 * Date:        2022-02-08
 * Authors:     Michael Nogueira, Alex D
 * Description: This class represents a Card object in the Quiddler library
 */
using System.Collections.Generic;

namespace QuiddlerLibrary
{
    class Card
    {
        internal static readonly Dictionary<string, ushort> _cardCounts = new()
        {
            { "a", 10 },
            { "b", 2 },
            { "c", 2 },
            { "cl", 2 },
            { "d", 4 },
            { "e", 12 },
            { "er", 2 },
            { "f", 2 },
            { "g", 4 },
            { "h", 2 },
            { "i", 8 },
            { "in", 2 },
            { "j", 2 },
            { "k", 2 },
            { "l", 4 },
            { "m", 2 },
            { "n", 6 },
            { "o", 8 },
            { "p", 2 },
            { "q", 2 },
            { "qu", 2 },
            { "r", 6 },
            { "s", 4 },
            { "t", 6 },
            { "th", 2 },
            { "u", 6 },
            { "v", 2 },
            { "w", 2 },
            { "x", 2 },
            { "y", 4 },
            { "z", 2 }

        };
        internal static readonly Dictionary<string, ushort> _cardValues = new()
        {
            { "a", 2 },
            { "b", 8 },
            { "c", 8 },
            { "cl", 10 },
            { "d", 5 },
            { "e", 2 },
            { "er", 7 },
            { "f", 6 },
            { "g", 6 },
            { "h", 7 },
            { "i", 2 },
            { "in", 7 },
            { "j", 13 },
            { "k", 8 },
            { "l", 3 },
            { "m", 5 },
            { "n", 5 },
            { "o", 2 },
            { "p", 6 },
            { "q", 15 },
            { "qu", 9 },
            { "r", 5 },
            { "s", 3 },
            { "t", 3 },
            { "th", 9 },
            { "u", 4 },
            { "v", 11 },
            { "w", 10 },
            { "x", 12 },
            { "y", 4 },
            { "z", 14 }
        };

        internal string _rank;
        internal ushort _value;

        internal Card(string rank)
        {
            _rank = rank;
            _value = _cardValues[rank];
        }

        public override string ToString() => _rank;
    }
}
