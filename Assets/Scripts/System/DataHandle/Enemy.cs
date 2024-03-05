using System;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalEnemy : MonoBehaviour, IEnemy
    {
        public int no;
        public new string name;
        public int hp;
        public string[] area;

        public void SetUp(SerializableEnemy enemy)
        {
            no = enemy.no;
            name = enemy.name;
            hp = enemy.hp;
            area = enemy.area;
        }
    }

    public class SerializableEnemy
    {
        public int no;
        public string name;
        public int hp;
        public string[] area;
    }
}