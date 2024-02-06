using System.Collections.Generic;

namespace Megumin.GameSystem
{
    public class Party
    {
        public List<SerializableMainCharacter> characters;

        public Party()
        {
            characters = new List<SerializableMainCharacter>();
        }
    }
}