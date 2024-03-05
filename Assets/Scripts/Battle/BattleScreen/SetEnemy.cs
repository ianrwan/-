using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.GameSystem;
using Megumin.DataStructure;

namespace Megumin.Battle
{
    public class SetEnemy : MonoBehaviour
    {
        public GameObject parent;
        public GameObject prefabEnemy;
        public List<GameObject> enemyObj;

        private string __area;
        private int[] __enemiesAppearNum; // 陣列存取該地區會出現的 enemy
        private PartyEnemy __party;

        public void SetUpParty(BattleHandleData handleData,List<Vector3> partyVectors)
        {
            __party = handleData.partyEnemy;

            for(int i = 0 ; i < __party.Amount ; i++)
            {
                __party.enemies.Add(handleData.enemies[0]);

                enemyObj.Add(Instantiate(prefabEnemy, parent.transform));
                var rectTransform = enemyObj[i].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = partyVectors[i];
                SetRelativePos(__party.Amount, i);
            }

            __party.enemiesObj = enemyObj;    
            var localEnemies = GameObjectConverter.GetListGameObjComponent<LocalEnemy>(enemyObj);

            for(int i = 0 ; i < __party.Amount ; i++)
            {
                localEnemies[i].SetUp(__party.enemies[i]);
            }

            SetUpText();
        }

        private void SetRelativePos(int total, int tag)
        {
            var posRelative = enemyObj[tag].GetComponent<PosRelative2D>();
            double d = Math.Ceiling((double)tag-total/2);
            
            if(d >= 0)
                posRelative.x = Convert.ToUInt32(0+2*d);
            else
                posRelative.x = Convert.ToUInt32(Math.Abs(1+2*d));

            posRelative.y = 0;
        }

        // 以下為暫時使用，之後會變更
        public void SetUpText()
        {
            var texts = GameObjectConverter.GetListGameObjComponent<Text>(enemyObj);
            var enemies = GameObjectConverter.GetListGameObjComponent<LocalEnemy>(enemyObj);

            for(int i = 0 ; i < __party.Amount ; i++)
            {
                texts[i].text = enemies[i].name+"\nhp "+enemies[i].hp;
            }
        }
    }
}
