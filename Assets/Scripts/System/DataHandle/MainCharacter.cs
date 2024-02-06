using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalMainCharacter : MonoBehaviour
    {
        public int no;
        public string job;
        public int hp;
        public int speed;

        public void SetUp(int no, string job, int hp, int speed)
        {
            this.no = no;
            this.job = job;
            this.hp = hp;
            this.speed = speed;
        }
    }

    [Serializable]
    public class SerializableMainCharacter
    {
        public int no;
        public string job;
        public int hp;
        public int speed;
    }
}