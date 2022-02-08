
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;

namespace QuiddlerLibrary
{
    class Player : IPlayer, IDisposable
    {
        public int CardCount => _hand.Count;
        public int TotalPoints { get; private set; }

        public Player(Deck d) => _deck = d;

        private readonly Deck _deck;
        private readonly List<Card> _hand = new();
        private readonly Application spellChecker = new();
        private bool disposedValue;

        public string DrawCard()
        {
            if (_deck.CardCount <= 0) throw new InvalidOperationException();
            
            var card = _deck.DrawCard();
            _hand.Add(card);
            return card.ToString();
        }

        public bool Discard(string card)
        {
            foreach (var handCard in _hand)
            {
                if (card == handCard._rank)
                {
                    _hand.Remove(handCard);
                    _deck.TopDiscard = card;
                    return true;
                }
            }
            return false;
        }

        public string PickupTopDiscard()
        {
            var card = new Card(_deck.TopDiscard);
            _hand.Add(card);
            return card.ToString();
        }

        public int PlayWord(string candidate)
        {
            int points = TestWord(candidate);
            if(points <= 0) return 0;
            foreach (string card in candidate.Split(' '))
                foreach (var handCard in _hand)
                    if (handCard._value.Equals(card))
                        _hand.Remove(handCard);
            return TotalPoints += points;
        }

        public int TestWord(string candidate)
        {
            string[] candidateCards = candidate.Split(" ");
            if (candidateCards.Length == _hand.Count) return 0;

            var handDictionary = new Dictionary<string, int>();
            foreach(var card in candidateCards)
                handDictionary[card]++;

            var candidateDictionary = new Dictionary<string, int>();
            foreach (var card in candidateCards)
                candidateDictionary[card]++;

            foreach(var card in candidateDictionary)
                if (handDictionary[card.Key] != card.Value) return 0;

            if (!spellChecker.CheckSpelling(candidate.ToLower().Replace(" ", "")))
                return 0;

            return CalculateScore(candidate.ToLower());
        }

        private static int CalculateScore(string word)
        {
            int score = 0;
            foreach(string letter in word.Split(' '))
                score += Card._cardValues[letter];
            return score;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    spellChecker.Quit();             
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
