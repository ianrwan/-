using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class ArithmeticHandleData
    {
        public ButtonChoice combatChoice;
        public Character character;
        public Enemy enemy;

        public ArithmeticHandleData(ButtonChoice combatChoice) : this(combatChoice, null, null){}

        public ArithmeticHandleData(ButtonChoice combatChoice, Character character) : this(combatChoice, character, null){}

        public ArithmeticHandleData(ButtonChoice combatChoice, Enemy enemy) : this(combatChoice, null, enemy){}

        public ArithmeticHandleData(ButtonChoice combatChoice, Character character, Enemy enemy)
        {
            this.combatChoice = combatChoice;
            this.character = character;
            this.enemy = enemy;
        }
    }

}

