using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Megumin.MeguminException;
using Megumin.DataStructure;
using System.Linq;

namespace Megumin.GameSystem
{
    public class PosRelative2DAdjust
    {
        private GameObject[] posGameObjects;
        public GameObject[] PosGameObjects
        {
            private get => posGameObjects;
            set
            {
                Guard guard = new Guard();

                if(value == null)
                    throw new NullReferenceException();

                if(guard.IsElementMissing<GameObject>(value))
                    throw new MissingGameObjectException(guard.message+" "+guard.index);

                var data = GameObjectConverter.ArrayListConverter(value);
                if(guard.IsNoComponent<PosRelative2D>(GameObjectConverter.ArrayListConverter(value)))
                    throw new NoComponentException(guard.message+" "+guard.index);

                posGameObjects = value;
            }
        }

        // GameObjcet: GameObject with PosRelative2D
        // uint[]: save the data same as PosRelative2D x y
        private PosRelative2D[] implementData;
        private uint[][] storeOrigin;

        public PosRelative2DAdjust(GameObject[] gameObjects)
        {
            PosGameObjects = gameObjects;
            SetNewArray();
        }

        public void SetData(uint[][] posData)
        {
            for(int i = 0 ; i < posGameObjects.Length ; i++)
            {
                implementData[i].x = posData[i][0];
                implementData[i].y = posData[i][1];
            }
        }

        public void Reset()
        {
            SetData(storeOrigin);
        }

        public void SetNewArray()
        {
            storeOrigin = new uint[posGameObjects.Length][];
            implementData = new PosRelative2D[posGameObjects.Length];

            for(int i = 0 ; i < posGameObjects.Length ; i++)
            {
                storeOrigin[i] = new uint[2];
                var pos = posGameObjects[i].GetComponent<PosRelative2D>();
                storeOrigin[i][0] = pos.x;
                storeOrigin[i][1] = pos.y;

                implementData[i] = pos;
            }
           
        }
    }
}

