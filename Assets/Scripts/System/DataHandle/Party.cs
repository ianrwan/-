using System.Collections.Generic;

namespace Megumin.GameSystem
{
    public class Party
    {
        public List<MainCharacter> characters;

        public Party()
        {
            characters = new List<MainCharacter>();
        }
    }
}