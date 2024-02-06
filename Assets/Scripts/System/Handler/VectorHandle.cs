using System.Collections.Generic;
using Megumin.FileSystem;
using UnityEngine;

namespace Megumin.GameSystem
{
    public abstract class VectorHandle
    {
        protected int characterAmount; 
        protected Dictionary<int, string> jsonDictionary;

        public VectorHandle(int amount)
        {
            this.characterAmount = amount;
            jsonDictionary = new Dictionary<int, string>();
            MakeDictionary();
        }

        public abstract void MakeDictionary();

        public List<Vector3> GetVectorDatas(string path)
        {
            return GetVectorDatas(path, this.characterAmount);
        }

        public List<Vector3> GetVectorDatas(string path, int amount)
        {
            characterAmount = amount;

            JsonConverter jc = new JsonConverter();
            var list = jc.FileToJsonArray1D<Vector3>(path, jsonDictionary[amount]);
            Debug.Log(list[0]);
            return list;
        }
    }
}

