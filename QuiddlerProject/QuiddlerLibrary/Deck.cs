using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        const ushort NumCards = 118;

        public Deck()
        {
            foreach (var key in Card._cardCounts.Keys)
                for (int i = 0; i < Card._cardCounts[key]; i++)
                    _cards.Add(new Card(key));
        }

        public string About => "Test Client for: Quiddler (TM) Library, © 2022 Michael Nogueira/Alex D";
        public int CardCount => _cards.Count - _cardIndex;
        public string TopDiscard
        {
            get
            {
                if (TopDiscard == null)
                    TopDiscard = DrawCard().ToString();
                return TopDiscard;
            }
            internal set { }
        }
        public int CardsPerPlayer
        {
            get => CardsPerPlayer;

            set
            {
                if (value > 10 || value < 3)
                    throw new ArgumentOutOfRangeException(
                        message: "Cards per player must be between 3-10 inclusive.", paramName: nameof(value)
                    );
            }
        }


        private readonly List<Card> _cards = new List<Card>();
        private int _cardIndex = 0;


        public IPlayer NewPlayer()
        {
            var player = new Player(this);
            for (int i = 0; i < CardsPerPlayer; i++)
                player.DrawCard();
            return player;
        }

        public override string ToString()
        {
            int cardsPerLine = 8;
            int cardsPrinted = 0;
            StringBuilder sb = new();
            var availableCards = new Dictionary<string, int>();
            for(int i = _cardIndex; i < _cards.Count; i++)
                availableCards[_cards[i]._rank]++;

            foreach(var card in availableCards)
                sb.Append(
                    $"{ card.Key}({card.Value}){(cardsPrinted++ >= cardsPerLine ? '\n' : ' ')}"
                );
            return sb.ToString();
        }

        internal Card DrawCard() => _cards.ElementAt(_cardIndex++);
    }
}
