using System;
using Megumin.Battle;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalEnemy : MonoBehaviour, IEntityDataGet, IEntityDataSet
    {
        // The enum symbol of the enemy, like "ENEMY_SLIME"
        private Enemy symbol;
        public Enemy Symbol
        {
            get => symbol;
        }

        // The name of the enemy, like "史萊姆"
        private new string name;
        public string Name
        {
            get => name;
        }

        // The health of the enemy
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

                enemy.hp = hp;
            }
        }

        private int defense;
        public int Defense
        {
            get => defense;
            set
            {
                defense = value;
                enemy.defense = defense;
            }
        }

        private int powerMin;
        public int PowerMin
        {
            get => powerMin;
            set
            {
                powerMin = value;
                enemy.powerMin = powerMin;
            }
        }

        private int powerMax;
        public int PowerMax
        {
            get => powerMax;
            set
            {
                powerMax = value;
                enemy.powerMax = powerMax;
            }
        }

        private int speed;
        public int Speed
        {
            get => speed;
            set
            {
                speed = value;
                enemy.speed = speed;
            }
        }

        private string[] area;
        public string[] Area
        {
            get => (string[])area.Clone();
        }

        private SerializableEnemy enemy;

        public void SetUp(SerializableEnemy enemy)
        {
            this.enemy = enemy;
            symbol = enemy.symbol;
            name = enemy.name;
            hp = enemy.hp;
            defense = enemy.defense;
            powerMin = enemy.powerMin;
            powerMax = enemy.powerMax;
            speed = enemy.speed;
            area = enemy.area;
        }

        int IEntityDataGet.GetSpeed()
        {
            return Speed;
        }

        int IEntityDataGet.GetDefense()
        {
            return Defense;
        }

        int IEntityDataGet.GetHealth()
        {
            return hp;
        }

        int IEntityDataGet.GetPower()
        {
            return UnityEngine.Random.Range(powerMin, powerMax+1);
        }

        GameObject IEntityDataGet.GetGameObject()
        {
            return gameObject;
        }

        void IEntityDataSet.SetHealth(int hp)
        {
            HP = hp;
        }
    }

    public class SerializableEnemy
    {
        public Enemy symbol;
        public string name;
        public int hp;
        public int powerMin;
        public int powerMax;
        public int defense;
        public int speed;
        public string[] area;
    }
}