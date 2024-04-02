using System;
using System.Collections.Generic;
using UnityEngine;
using Megumin.DataStructure;
using Megumin.MeguminException;

namespace Megumin.GameSystem
{
    [Serializable]
    public class PartyEnemy
    {
        public List<SerializableEnemy> enemies;
        private List<GameObject> enemiesObj;
        public List<GameObject> EnemiesObj
        {
            get => new List<GameObject>(enemiesObj);
            set
            {
                Guard guard = new Guard();
                if(guard.IsElementMissing(value))
                    throw new MissingGameObjectException(guard.message);

                if(guard.IsNoComponent<LocalEnemy>(value))
                    throw new NoComponentException(guard.message);

                enemiesObj = new List<GameObject>(value);
            }
        }

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

