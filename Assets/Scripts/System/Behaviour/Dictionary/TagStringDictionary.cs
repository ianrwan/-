using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class TagStringDictionary<T>
    {
        private List<Serialze> serialze;
        public Dictionary<T, string> dictionary{get; private set;}

        public string type;

        [Serializable]
        private class Serialze
        {
            public T tag;
            public string name;
        }

        public TagStringDictionary()
        {
            Debug.LogError("You should input you string type");
        }

        public TagStringDictionary(string type)
        {
            this.type = type;
        }

        public void SetUp()
        {
            if(type == null || type == "")
                Debug.LogError("string type doesn't set");

            serialze = TextAssetsManager.instance.FindObjectsByString<Serialze>(type);
            
            if(serialze == null)
                Debug.LogError("serial can't be set");
            SetDictionary();
        }

        private void SetDictionary()
        {
            dictionary = new Dictionary<T, string>();
            foreach(var single in serialze)
            {
                dictionary.Add(single.tag, single.name);
            }
        }

        public string GetName(T tag)
        {
            return dictionary[tag];
        }
    }
}

