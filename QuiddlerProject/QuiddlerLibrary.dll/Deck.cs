using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        const ushort NumCards = 118;

        private Dictionary<string, ushort> _cardCounts = new()
        {
            { "a", 10 },
            { "b", 2 },
            { "c", 2 },
            { "cl", 2 },
            { "d", 4 },
            { "e", 12 },
            { "er",2 },
            { "f", 2 },
            { "g", 4 },
            { "h", 2 },
            { "i", 8 },
            { "in",2 },
            { "j", 2 },
            { "k", 2 },
            { "l", 4 },
            { "m", 2 },
            { "n", 6 },
            { "o", 8 },
            { "p", 2 },
            { "q", 2 },
            { "qu",2 },
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
        private Dictionary<string, ushort> _cardValues = new()
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
        private int _numPlayers;
        private List<Card> _cards = new List<Card>();
        public Deck()
        {
            foreach(var key in _cardCounts.Keys)
                for(int i = 0; i < _cardCounts[key]; i++)
                    _cards.Add(new Card(key, _cardValues[key]));
        }

        public string About => "Test Client for: Quiddler (TM) Library, © 2022 M. Nogueira";

        public int CardCount => throw new NotImplementedException();

        public int CardsPerPlayer 
        {
            get => CardsPerPlayer;

            set
            {
                if (value > 10 || value < 3)
                    throw new ArgumentOutOfRangeException(
                        message: "Cards per player must be between 3-10 inclusive.", paramName: nameof(value));
            }
        }

        public string TopDiscard { get; }

        public IPlayer NewPlayer() => new Player(this);

        public override string ToString()
        {
            int cardsPerLine = 8;
            int cardsPrinted = 0;
            StringBuilder sb = new();
            foreach(Card card in _cards )
            {
                if(cardsPrinted >= cardsPerLine)
                {
                    sb.Append("\n");
                    cardsPrinted = 0;
                }                    
                sb.Append(card);
                ++cardsPrinted;
            }
            return sb.ToString();
        }

        private void DrawCard()
        {

        }
    }
}
