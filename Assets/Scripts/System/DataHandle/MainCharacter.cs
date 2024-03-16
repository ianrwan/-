using System;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalMainCharacter : MonoBehaviour
    {
        public Character no;
        public string job;
        public int hp;
        public int speed;
        public Tool[] tool;

        public void SetUp(SerializableMainCharacter serializableMainCharacter)
        {
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