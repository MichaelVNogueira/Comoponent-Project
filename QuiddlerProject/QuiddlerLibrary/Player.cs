
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Text;

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
                for(int i = 0; i < _hand.Count; i++)
                    if (_hand[i]._rank.Equals(card))
                        _hand.Remove(_hand[i]);
            return TotalPoints += points;
        }

        public int TestWord(string candidate)
        {
            string[] candidateCards = candidate.Trim().Split(" ");
            if (candidateCards.Length == _hand.Count)
                return 0;

            var handDictionary = new Dictionary<string, int>();
            foreach (var card in _hand)
                if ((!handDictionary.TryGetValue(card._rank, out int value)))
                    handDictionary.Add(card._rank, value);
                else handDictionary[card._rank]++;

            var candidateDictionary = new Dictionary<string, int>();
            foreach (var card in candidateCards)
                if ((!candidateDictionary.TryGetValue(card, out int value)))
                    candidateDictionary.Add(card, value);
                else candidateDictionary[card]++;

            foreach (var card in candidateDictionary)
                if (!(handDictionary.TryGetValue(card.Key, out int value) && value >= card.Value))
                    return 0;

            if (!spellChecker.CheckSpelling(candidate.ToLower().Replace(" ", "")))
                return 0;

            return CalculateScore(candidate.ToLower());
        }

        public override string ToString()
        {
            StringBuilder sb = new("[");
            int i;
            for(i = 0; i < _hand.Count - 1; i++)
                sb.Append($"{_hand[i]} ");
            sb.Append($"{_hand[i]}]");
            return sb.ToString();
        }

        private static int CalculateScore(string word)
        {
            int score = 0;
            foreach (string letter in word.Split(' '))
                score += (Card._cardValues.TryGetValue(letter, out int value)
                    ? value
                    : 0);
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
