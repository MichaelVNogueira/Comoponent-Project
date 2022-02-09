/*
 * File         IDeck.cs
 * Date:        2022-02-08
 * Authors      Michael Nogueira, Alex Mendez
 * Description: This interface exposes functionality of the Deck object in the QuiddlerLibrary
 */

namespace QuiddlerLibrary
{
    public interface IDeck
    {
        public string About { get; }
        public int CardCount { get; }
        public int CardsPerPlayer { get; set; }
        public string TopDiscard { get; }

        public IPlayer NewPlayer();
        public string ToString();
    }
}
