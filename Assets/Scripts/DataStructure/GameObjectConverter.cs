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
    }
}
