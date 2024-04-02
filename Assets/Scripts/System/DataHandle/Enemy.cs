using System;
using Megumin.Battle;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalEnemy : MonoBehaviour, IEntityDataGet
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
            speed = enemy.speed;
            area = enemy.area;
        }

        int IEntityDataGet.GetSpeed()
        {
            return Speed;
        }

        GameObject IEntityDataGet.GetGameObject()
        {
            return gameObject;
        }
    }

    public class SerializableEnemy
    {
        public Enemy symbol;
        public string name;
        public int hp;
        public int speed;
        public string[] area;
    }
}