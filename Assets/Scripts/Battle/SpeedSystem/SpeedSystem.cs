using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Megumin.MeguminException;
using Megumin.GameSystem;
using Megumin.DataStructure;

namespace Megumin.Battle
{
    public class SpeedSystem : MonoBehaviour
    {
        // put the enties inside the List without sort, to check which data is in the list
        private List<GameObject> entitiesNoSort;

        // put the enties inside the List with sort by speed
        private List<IEntityDataGet> entitiesData;

        // set the current and next entity(status), and also each GameObj
        // current means entitiesData left List already(Not in the list)
        public Entity currentEntity{get; private set;}
        public GameObject currentGameObj{get; private set;}

        // next means entitiesData[0]
        public Entity nextEntity{get; private set;}
        public GameObject nextGameObj{get; private set;}

        // amount is the List.Count form entitiesData, if Amount == 1, this round is end
        public int Amount
        {
            get => entitiesData.Count;
        }
        

        public void SetUp(BattleHandleData battleHandleData)
        {
            List<GameObject> mainCharactersgameObj = battleHandleData.party.GetPartyGameObjets();
            List<GameObject> enemiesgameObj = battleHandleData.partyEnemy.EnemiesObj;

            enemiesgameObj.AddRange(mainCharactersgameObj);
            entitiesNoSort = new List<GameObject>(enemiesgameObj);

            AdjustBySpeed();
            Peek();
        }

        // gameObjcets can be orderd by speed
        private void AdjustBySpeed()
        {
            if(entitiesNoSort.Count == 0)
                throw new ListEmptyException("No GameObjects inside the list");

            entitiesData = GameObjectConverter.GetListGameObjComponent<IEntityDataGet>(entitiesNoSort);

            Sort();
        }

        // sort data by speed
        private void Sort()
        {
            for(int i = 1 ; i < entitiesNoSort.Count ; i++)
            {
                for(int j = 0 ; j < entitiesNoSort.Count-1 ; j++)
                {
                    // if the speed current is bigger than next, then continue
                    if(entitiesData[j].GetSpeed() > entitiesData[j+1].GetSpeed())
                        continue;

                    // if the speed current is equal than next and it's LocalMainCharacter then continue
                    // This condition is to check if the current entity is MainCharacter or Enemy
                    // Enemy should be swaped when the speed is equal to MainCharacter 
                    if(entitiesData[j].GetSpeed() == entitiesData[j+1].GetSpeed() && 
                        (entitiesData[j] is LocalMainCharacter || entitiesData[j+1] is LocalEnemy))
                            continue;
                    
                    var temp = entitiesData[j];
                    entitiesData[j] = entitiesData[j+1];
                    entitiesData[j+1] = temp;
                }
            }
        }

        // To check what the next GameObject is
        public GameObject Peek()
        {
            if(entitiesData.Count == 0)
            {
                nextEntity = 0;
                nextGameObj = null;
                return null;
            }

            if(entitiesData[0] is LocalMainCharacter)
                nextEntity = Entity.MAIN_CHARACTER;
            else
                nextEntity = Entity.ENEMY;

            nextGameObj = entitiesData[0].GetGameObject();
            return entitiesData[0].GetGameObject();
        }

        // To get the current GameObject and the gameObject should be left from List
        public GameObject Dequeue()
        {
            if(Amount == 0)
                return null;
                
            entitiesData.RemoveAt(0);

            currentEntity = nextEntity;
            currentGameObj = nextGameObj;

            Peek();
            return currentGameObj;
        }


    }
}

