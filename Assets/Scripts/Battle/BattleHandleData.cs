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
        private JsonConverter __jc;
        public List<SerealizableButton> buttons{get; private set;}
        public List<SerializableMainCharacter> characters{get; private set;}
        public List<SerializableEnemy> enemies{get; private set;}
        public Party party;
        public PartyEnemy partyEnemy;
        public bool isEndChoice;

        public BattleHandleData()
        {
            __jc = new JsonConverter();
            buttons = __jc.FileToJsonArray1D<SerealizableButton>(Path.pathButton);
            characters = __jc.FileToJsonArray1D<SerializableMainCharacter>(Path.pathButton);
            enemies = __jc.FileToJsonArray1D<SerializableEnemy>(Path.pathEnemy);
            party = __jc.FileToJson<Party>(Path.pathParty);
        }
    }
}
