using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.GameSystem;

namespace Megumin.Battle
{
    public class Main : MonoBehaviour, IBattleScreen
    {
        public GameObject[] gameObjButtons;
        private List<Text> textButtons;
        private List<LocalButton> localButtons;

        public void SetUpButton(List<SerealizableButton> list)
        {
            localButtons = new List<LocalButton>();
            foreach(var gameObjButton in gameObjButtons)
                localButtons.Add(gameObjButton.GetComponent<LocalButton>());
            
            localButtons[0].SetUp(list[0].no, list[0].name);
            localButtons[1].SetUp(list[1].no, list[1].name);
         }

        public void ShowButtonText()
        {
            
            if(localButtons.Count == 0)
                throw new Exception("");

            textButtons = new List<Text>();
            int i = 0; 
            foreach(var gameObjButton in gameObjButtons)
            {
                textButtons.Add(gameObjButton.GetComponent<Text>());
                textButtons[i].text = localButtons[i].name;
                i++;
            }
        }

        public GameObject[] GetButtonsGameObj()
        {
            return gameObjButtons;
        }

        public void ButtonDo(int num)
        {
            if(localButtons.Count == 0)
                throw new Exception("");
            

            switch(num)
            {
                case 0:
                    localButtons[0].Click();
                    break;
                case 1:
                    localButtons[1].Click();
                    break;
            }
        }

        public void Close()
        {
            gameObjButtons[0].transform.parent.GetComponent<Canvas>().enabled = false;
        }
    }
}
