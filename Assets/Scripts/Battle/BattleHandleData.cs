using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Megumin.GameSystem;
using Megumin.FileSystem;

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
