using System;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    [Serializable]
    public class PartyEnemy
    {
        public List<SerializableEnemy> enemies;
        public List<GameObject> enemiesObj;

        private int __amount;
        public int Amount
        {
            get => __amount;
            set
            {
                if(value >= 0)
                    __amount = value;
            }
        }

        public PartyEnemy()
        {
            System.Random ran = new System.Random();
            __amount = ran.Next(1, 4);

            enemies = new List<SerializableEnemy>();
        }

        public PartyEnemy(int amount) 
        {
            __amount = amount;
            enemies = new List<SerializableEnemy>();
        }
    }
}

