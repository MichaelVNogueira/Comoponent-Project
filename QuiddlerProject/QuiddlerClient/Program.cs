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
        }
    }
}
