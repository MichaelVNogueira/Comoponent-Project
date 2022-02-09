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
            while(true)
            {
                Console.WriteLine($"Player: {player.ToString()}");
                string word = Console.ReadLine();
                Console.WriteLine(player.PlayWord(word));
            }

        }
    }
}
