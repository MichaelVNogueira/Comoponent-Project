/*
 * File         IDeck.cs
 * Date:        2022-02-08
 * Authors      Michael Nogueira, Alex Mendez
 * Description: This interface exposes functionality of the Deck object in the QuiddlerLibrary
 */

namespace QuiddlerLibrary
{
    public interface IPlayer
    {
        public int CardCount { get; }
        public int TotalPoints { get; }

        public string DrawCard();
        public bool Discard(string card);
        public string PickupTopDiscard();
        public int PlayWord(string candidate);
        public int TestWord(string candidate);
        public string ToString();
    }
}
