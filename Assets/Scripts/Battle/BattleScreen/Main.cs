using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.DataStructure;
using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class Main : MonoBehaviour, IBattleScreen
    {
        public Text[] textButtons;

        public List<GameObject> ShowButtonText(List<GameSystem.Button> list)
        {
            textButtons[0].text = list[0].name;
            textButtons[1].text = list[1].name;

            var gameObjects =  GameObjectConverter.TextArrayToObjList(textButtons);
            gameObjects[0].GetComponent<LocalButton>().no = list[0].no;
            gameObjects[1].GetComponent<LocalButton>().no = list[1].no;

            return gameObjects;
        }
    }
}
