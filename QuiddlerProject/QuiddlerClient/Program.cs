using System;
using QuiddlerLibrary;

namespace QuiddlerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Console.WriteLine(deck.ToString());
            Console.WriteLine($"Cards in deck: { deck.CardCount}");
            deck.CardsPerPlayer = 5;
            var player = deck.NewPlayer();
            Console.WriteLine($"Cards after dealing player: {deck.CardCount}");
            Console.WriteLine($"Draw: {player.DrawCard()}");
            Console.WriteLine($"Cards in deck after draw: {deck.CardCount}");
            Console.WriteLine($"Player: {player.ToString()}");
            Console.WriteLine($"Top discard of deck {deck.TopDiscard}");
            while(true)
            {
                string word = Console.ReadLine();
                Console.WriteLine(player.PlayWord(word));
            }

        }
    }
}
