using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Megumin.GameSystem;
using Megumin.FileSystem;
using Megumin.MeguminException;

namespace Megumin.Battle
{
    [Serializable]
    public class BattleHandleData
    {
        private JsonConverter jc;
        public List<SerealizableButton> buttons{get; private set;}
        public List<SerializableMainCharacter> characters{get; private set;}
        public List<SerializableEnemy> enemies{get; private set;}
        public List<SerializableTool> tools{get; private set;}
        public SerializableParty partySerial;
        public Party party;
        public PartyEnemy partyEnemy;
        public DictionarySet dictionarySet;

        public TeamChoice teamChoice;

        // Look what's character is in action currently
        [SerializeField]
        private GameObject currentEntity;
        public GameObject CurrentEntity
        {
            get
            {
                try
                {
                    return currentEntity;
                }
                catch(NullReferenceException)
                {
                    Debug.LogWarning("You are trying access currentMainCharacter which is null");
                }
                return null;
            }
            set
            {
                if(value.GetComponent<LocalMainCharacter>() == null && value.GetComponent<LocalEnemy>() == null)
                    throw new NoComponentException("LocalMainCharacter component isn't in the GameObject");
                
                currentEntity = value;
            }
        }

        public BattleHandleData()
        {
            jc = new JsonConverter();
            buttons = jc.FileToJsonArray1D<SerealizableButton>(Path.pathButton);
            characters = jc.FileToJsonArray1D<SerializableMainCharacter>(Path.pathCharacter);
            enemies = jc.FileToJsonArray1D<SerializableEnemy>(Path.pathEnemy);
            tools = jc.FileToJsonArray1D<SerializableTool>(Path.pathTool);
            partySerial = jc.FileToJson<SerializableParty>(Path.pathParty);

            MakeDictionary();
        }

        private void MakeDictionary()
        {
            dictionarySet = new DictionarySet();
            dictionarySet.MakeDictionary(tools);
            dictionarySet.MakeDictionary(characters);
        }
    }
}
