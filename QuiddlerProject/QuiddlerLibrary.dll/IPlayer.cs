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
