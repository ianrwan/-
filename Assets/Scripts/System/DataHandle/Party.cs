using System;
using System.Collections.Generic;
using Megumin.MeguminException;
using Megumin.DataStructure;
using UnityEngine;

namespace Megumin.GameSystem
{
    [Serializable]
    public class Party
    {
        private List<SerializableMainCharacter> characters;
        private List<GameObject> charactersObj;

        private int amount;
        public int Amount
        {
            get => amount;
            set
            {
                if(value >= 0)
                    amount = value;
            }
        }

        public Party(List<SerializableMainCharacter> characters)
        {
            SetParty(characters);
        }

        public Party(List<SerializableMainCharacter> characters, List<GameObject> gameObjects) : this(characters)
        {
            SetParty(gameObjects);
        }

        public void SetParty(List<SerializableMainCharacter> characters)
        {
            Guard guard = new Guard();
            if(guard.IsElementMissing(characters))
                throw new MissingReferenceException(guard.message);

            this.characters = new List<SerializableMainCharacter>(characters);
            amount = characters.Count;
        }

        public List<SerializableMainCharacter> GetPartyListSerial()
        {
            return new List<SerializableMainCharacter>(characters);
        }

        public void SetParty(List<GameObject> gameObject)
        {
            Guard guard = new Guard();
            if(guard.IsNoComponent<LocalMainCharacter>(gameObject))
                throw new NoComponentException(guard.message);

            if(gameObject.Count != amount)
                throw new NotMatchException("Amount: "+amount+" GameObject Count: "+gameObject.Count);

            charactersObj = new List<GameObject>(gameObject);
        }

        public List<GameObject> GetPartyGameObjets()
        {
            return new List<GameObject>(charactersObj);
        }

        public void UpdateParty(GameObject newCharacter, int num)
        {
            if(charactersObj.Contains(newCharacter))
                throw new ExistException(newCharacter.name+" is already in the List");
        }
    }

    [Serializable]
    public class SerializableParty
    {
        public List<Character> party;
    }
}