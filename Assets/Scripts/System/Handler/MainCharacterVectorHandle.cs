namespace Megumin.GameSystem
{
    public class MainCharacterVectorHandle : VectorHandle
    {
        public MainCharacterVectorHandle() : this(1){}

        public MainCharacterVectorHandle(int amount) : base(amount){}

        public override void MakeDictionary()
        {
            jsonDictionary.Add(1, "one-data");
            jsonDictionary.Add(2, "two-data");
            jsonDictionary.Add(3, "three-data");
        }
    }
}

