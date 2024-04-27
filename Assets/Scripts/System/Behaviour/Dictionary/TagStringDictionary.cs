using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Megumin.GameSystem
{
    public class TagDictionary<T1, T2>
    {
        private List<Serialze> serialze;
        public Dictionary<T1, T2> dictionary{get; private set;}

        public string type;

        [Serializable]
        private class Serialze
        {
            public T1 tag;
            public T2 name;
        }

        public TagDictionary()
        {
            Debug.LogError("You should input you string type");
        }

        public TagDictionary(string type)
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
            dictionary = new Dictionary<T1, T2>();
            foreach(var single in serialze)
            {
                dictionary.Add(single.tag, single.name);
            }
        }

        public T2 GetName(T1 tag)
        {
            return dictionary[tag];
        }
    }
}

