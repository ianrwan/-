namespace Megumin.GameSystem
{
    public class ChoiceVectorHandle : VectorHandle
    {
        public ChoiceVectorHandle() : this(1){}

        public ChoiceVectorHandle(int amount) : base(amount){}

        public override void MakeDictionary()
        {
            jsonDictionary.Add(1, "action");
        }
    }
}

