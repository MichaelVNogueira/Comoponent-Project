using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiddlerLibrary
{
    class Player : IPlayer
    {
        public int CardCount => throw new NotImplementedException();

        public int TotalPoints => throw new NotImplementedException();

        public string DrawCard() => throw new NotImplementedException();
        public bool Discard(string card) => throw new NotImplementedException();
        public string PickupTopDiscard() => throw new NotImplementedException();
        public int PlayWord(string candidate) => throw new NotImplementedException();
        public int TestWord(string candidate) => throw new NotImplementedException();
    }
}
