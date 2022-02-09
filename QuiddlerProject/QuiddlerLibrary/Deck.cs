/*
 * File:        Deck.cs
 * Date:        2022-02-08
 * Authors:     Michael Nogueira, Alex Mendez
 * Description: This class reperesents a deck of quiddler cards used in the QuiddlerLibrary
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuiddlerLibrary
{
    public class Deck : IDeck
    {
        public string About => "Test Client for: Quiddler (TM) Library, © 2022 Michael Nogueira / Alex Mendez";
        public int CardCount => _cards.Count - _cardIndex;
        public string TopDiscard
        {
            get => _topDiscard ??= DrawCard().ToString();
            internal set {}
        }
        public int CardsPerPlayer
        {
            get => _cardsPerPlayer;
            set
            {
                if (value > 10 || value < 3)
                    throw new ArgumentOutOfRangeException(
                        message: "Cards per player must be between 3-10 inclusive.", paramName: nameof(value)
                    );
                else _cardsPerPlayer = value;
            }
        }
        public Deck()
        {
            foreach (var key in Card._cardCounts.Keys)
                for (int i = 0; i < Card._cardCounts[key]; i++)
                    _cards.Add(new Card(key));
            ShuffleDeck();
        }

        private readonly List<Card> _cards = new();
        private int _cardIndex = 0;
        private int _cardsPerPlayer = 0;
        private string _topDiscard;

        /// <summary>
        ///     Populates new Player object using CardsPerPlayer prop
        ///     then returns the Player.
        /// </summary>
        /// <returns><see cref="IPlayer"/></returns>
        public IPlayer NewPlayer()
        {
            var player = new Player(this);
            for (int i = 0; i < CardsPerPlayer; i++)
                player.DrawCard();
            return player;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            var availableCards = new SortedDictionary<string, int>();

            for(int i = _cardIndex; i < _cards.Count; i++)
            {
                if (availableCards.TryGetValue(_cards[i]._rank, out _))
                    availableCards[_cards[i]._rank]++;
                else
                    availableCards.Add(_cards[i]._rank, 1);
            }

            int cardsPerLine = 8, cardsInLine = 0;
            foreach (var card in availableCards)
            {
                sb.Append($"{ card.Key}({card.Value}) ");
                if(++cardsInLine >= cardsPerLine)
                {
                    sb.Append('\n');
                    cardsInLine = 0;
                }
            }
 
            return sb.ToString();
        }

        /// <summary>
        ///     Draws a card from the deck
        /// </summary>
        /// <returns><see cref="Card"/></returns>
        internal Card DrawCard() => _cards.ElementAt(_cardIndex++);

        /// <summary>
        ///     Shuffles the list of cards
        /// </summary>
        private void ShuffleDeck()
        {
            var random = new Random();
            for(int i = _cards.Count - 1; i > 0; i--)
            {
                int rng = random.Next(i);
                var tempCard = _cards[rng];
                _cards[rng]= _cards[i];
                _cards[i] = tempCard;
            }
        }
    }
}
