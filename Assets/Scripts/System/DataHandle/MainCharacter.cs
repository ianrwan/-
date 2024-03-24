using System;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalMainCharacter : MonoBehaviour
    {
        // no is the enum of character
        private Character no;
        public Character No
        {
            get => no;
        }

        // job is saved as "勇者" or "戰士" etc
        private string job;
        public string Job
        {
            get => job;
        }

        // hp is the health of the main character
        private int hp;
        public int HP
        {
            get => hp;
            set
            {
                // hp under 0 isn't allowed
                if(value < 0)
                    hp = 0;
                else
                    hp = value;

                mainCharacterInfo.hp = hp;
            }
        }

        // speed is for letting character do action first or next
        private int speed;
        public int Speed
        {
            get => speed;
            set
            {
                speed = value;
                mainCharacterInfo.speed = speed;
            }
        }

        // tool is what the character has right now
        private Tool[] tool;
        public Tool[] Tool
        {
            get => tool;
            set
            {
                tool = value;
                mainCharacterInfo.tool = tool;
            }
        }

        [SerializeField]
        private SerializableMainCharacter mainCharacterInfo;

        public void SetUp(SerializableMainCharacter serializableMainCharacter)
        {
            mainCharacterInfo = serializableMainCharacter;
            this.no = serializableMainCharacter.no;
            this.job = serializableMainCharacter.job;
            this.hp = serializableMainCharacter.hp;
            this.speed = serializableMainCharacter.speed;
            this.tool = serializableMainCharacter.tool;
        }
    }

    [Serializable]
    public class SerializableMainCharacter
    {
        public Character no;
        public string job;
        public int hp;
        public int speed;
        public Tool[] tool;
    }
}