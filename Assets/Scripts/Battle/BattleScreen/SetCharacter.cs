using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using Megumin.DataStructure;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    public class SetCharacter : MonoBehaviour
    {
        public GameObject parent;
        public GameObject prefabMainCharacter;
        public List<GameObject> mainCharactersGObj;
        private Party party;
        private int partyAmount;

        public void SetUpParty(Party party, List<Vector3> partyVectors)
        {
            this.party = party;
            partyAmount = party.characters.Count;

            for(int i = 0 ; i < partyAmount ; i++)
            {
                mainCharactersGObj.Add(Instantiate(prefabMainCharacter, parent.transform, false));
                var rectTransform = mainCharactersGObj[i].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = partyVectors[i];
            }

            var characters = GameObjectConverter.GetListGameObjComponent<LocalMainCharacter>(mainCharactersGObj);

            for(int i = 0 ; i < partyAmount ; i++)
            {
                characters[i].SetUp(party.characters[i].no, party.characters[i].job, party.characters[i].hp, party.characters[i].speed);
            }

            SetUpText();
        }

        // 以下為暫時使用，之後會變更
        public void SetUpText()
        {
            var texts = GameObjectConverter.GetListGameObjComponent<Text>(mainCharactersGObj);
            var characters = GameObjectConverter.GetListGameObjComponent<LocalMainCharacter>(mainCharactersGObj);

            for(int i = 0 ; i < partyAmount ; i++)
            {
                texts[i].text = characters[i].job+"\nhp "+characters[i].hp;
            }
        }
    }
}