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
    }
}
