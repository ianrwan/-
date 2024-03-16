using System.Collections;
using System.Collections.Generic;
using Megumin.GameSystem;
using Megumin.DataStructure;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace Megumin.Battle
{
    public class SetCharacter : MonoBehaviour
    {
        public GameObject parent;
        public GameObject prefabMainCharacter;
        public List<GameObject> mainCharactersGObj;
        private List<Character> characters;
        private Party party;
        private int partyAmount;

        public void SetUpParty(Party party, List<Vector3> partyVectors)
        {
            
            this.party = party;
            partyAmount = party.Amount;

            for(int i = 0 ; i < partyAmount ; i++)
            {
                mainCharactersGObj.Add(Instantiate(prefabMainCharacter, parent.transform, false));
                var rectTransform = mainCharactersGObj[i].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = partyVectors[i];
            }

            var characters = GameObjectConverter.GetListGameObjComponent<LocalMainCharacter>(mainCharactersGObj);

            for(int i = 0 ; i < partyAmount ; i++)
            {
                characters[i].SetUp(party.GetPartyListSerial()[i]);
            }

            SetUpText();
        }

        public Party SetParty(List<GameSystem.Character> characters, DictionarySet dictionarySet)
        {
            List<SerializableMainCharacter> serial = new List<SerializableMainCharacter>();
            for(int i = 0 ; i < characters.Count ; i++)
            {
                serial.Add(dictionarySet.characterDictionary[characters[i]]);
            }
            Party party = new Party(serial);
            return party;
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