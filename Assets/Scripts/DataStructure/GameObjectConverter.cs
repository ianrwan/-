using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.DataStructure
{
    public class GameObjectConverter
    {
        public static List<GameObject> TextArrayToObjList(Text[] textButtons)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            foreach(var data in textButtons)
            {
                gameObjects.Add(data.gameObject);
            }
            return gameObjects;
        }

        public static List<T> GetListGameObjComponent<T>(List<GameObject> gameObjs)
        {
            List<T> components = new List<T>();
            foreach(var gameObj in gameObjs)
                components.Add(gameObj.GetComponent<T>());

            return components;
        }

        public static List<T> GetListGameObjComponent<T>(GameObject[] gameObjs)
        {
            List<T> components = new List<T>();
            for(int i = 0 ; i < gameObjs.Length ; i++)
                components.Add(gameObjs[i].GetComponent<T>());

            return components;
        }

        public static List<T> ArrayListConverter<T>(T[] array)
        {
            List<T> list = new List<T>();

            foreach(var data in array)
            {
                list.Add(data);
            }

            return list;
        }

        public static T[] ListArrayConverter<T>(List<T> list)
        {
            T[] array = new T[list.Count];

            int i = 0;
            foreach(var data in list)
            {
                array[i] = list[i];
            }

            return array;
        }
    }
}
