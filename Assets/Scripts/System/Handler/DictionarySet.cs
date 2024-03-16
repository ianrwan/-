using System;
using System.Collections.Generic;

namespace Megumin.GameSystem
{
    [Serializable]
    public class DictionarySet
    {
        public Dictionary<Tool, SerializableTool> toolDicitonary{get; private set;}
        public Dictionary<Character, SerializableMainCharacter> characterDictionary{get; private set;}

        public DictionarySet()
        {
        }

        public void MakeDictionary(List<SerializableTool> serializableTools)
        {
            toolDicitonary = new Dictionary<Tool, SerializableTool>();
            foreach(var data in serializableTools)
            {
                toolDicitonary.Add(data.code, data);
            }
        }

        public void MakeDictionary(List<SerializableMainCharacter> serializableMainCharacters)
        {
            characterDictionary = new Dictionary<Character, SerializableMainCharacter>();
            foreach(var data in serializableMainCharacters)
            {
                characterDictionary.Add(data.no, data);
            }
        }
    }
}
