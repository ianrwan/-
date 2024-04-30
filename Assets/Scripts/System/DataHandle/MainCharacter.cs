using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class LocalMainCharacter : MonoBehaviour, IEntityDataGet, IEntityDataSet
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

        // strength is main chacrater self physical power
        private int strength;
        public int Strength
        {
            get => strength;
            set
            {
                strength = value;
                mainCharacterInfo.strength = strength;
            }
        }

        private int defense;
        public int Defense
        {
            get => defense;
            set
            {
                defense = value;
                mainCharacterInfo.defense = defense;
            }
        }

        // intelligence is main character self megical power
        private int intelligence;
        public int Intelligence
        {
            get => intelligence;
            set
            {
                intelligence = value;
                mainCharacterInfo.intelligence = intelligence;
            }
        }

        // physicalPower is strength + equipment
        private int physicalPower;
        public int PhysicalPower
        {
            get => physicalPower;
            set
            {
                physicalPower = value;
                mainCharacterInfo.physicalPower = physicalPower;
            }
        }

        // megicalPower is intelligence + equipment
        private int megicalPower;
        public int MegicalPower
        {
            get => megicalPower;
            set
            {
                megicalPower = value;
                mainCharacterInfo.megicalPower = megicalPower;
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
            // this.hp = serializableMainCharacter.hp;
            hp = StageHandlerGlobal.instance.health;
            this.speed = serializableMainCharacter.speed;
            this.defense = serializableMainCharacter.defense;
            this.strength = serializableMainCharacter.strength;
            this.intelligence = serializableMainCharacter.intelligence;
            this.physicalPower = serializableMainCharacter.physicalPower;
            this.megicalPower = serializableMainCharacter.megicalPower;
            // this.tool = serializableMainCharacter.tool;
            if(StageHandlerGlobal.instance.flowerMissionStage == FlowerMissionStage.FINISH)
            {
                this.tool = new Tool[1];
                this.tool[0] = GameSystem.Tool.TOOL_HONEY;
            }
        }

        int IEntityDataGet.GetDefense()
        {
            return Defense;
        }

        int IEntityDataGet.GetHealth()
        {
            return HP;
        }

        int IEntityDataGet.GetPower()
        {
            return strength;
        }

        int IEntityDataGet.GetSpeed()
        {
            return Speed;
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

    [Serializable]
    public class SerializableMainCharacter
    {
        public Character no;
        public string job;
        public int hp;
        public int speed;
        public int strength;
        public int defense;
        public int intelligence;
        public int physicalPower;
        public int megicalPower;
        public Tool[] tool;
    }
}