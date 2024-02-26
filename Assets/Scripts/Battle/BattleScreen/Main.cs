using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.GameSystem;
using Megumin.DataStructure;
using Megumin.MeguminException;

namespace Megumin.Battle
{
    public class Main : MonoBehaviour, IBattleScreen
    {
        public GameObject canvaButtons;
        public GameObject[] gameObjButtons;
        private List<Text> textButtons;
        private List<LocalButton> localButtons;
        private GameObject __toggle;

        public void SetUpButton(List<SerealizableButton> list)
        {
            localButtons = new List<LocalButton>();
            foreach(var gameObjButton in gameObjButtons)
                localButtons.Add(gameObjButton.GetComponent<LocalButton>());
            
            localButtons[0].SetUp(list[0].no, list[0].name);
            localButtons[1].SetUp(list[1].no, list[1].name);

            __SetUpToggle();
         }

         private void __SetUpToggle()
         {
            canvaButtons.GetComponent<SetToggle>().SetToggleOnFirstItem();
            GameObjectFind gameObjectFind = new GameObjectFind();
            __toggle = gameObjectFind.FindDecendantTag(canvaButtons, "Toggle")[0];
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

        public void ButtonDo(KeyBoard key)
        {
            if(localButtons.Count == 0)
                throw new BattleScreenException();

            switch(key)
            {
                case KeyBoard.RIGHT:
                    canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.LEFT:
                    canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.UP:
                    canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.DOWN:
                    canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.Z:
                    var localToggle = __toggle.GetComponent<GameSystem.Toggle>();
                    var button = localToggle.GetToggleCurrent().GetComponent<LocalButton>();
                    button.Click();
                    break;
                case KeyBoard.X:
                    
                    break;
            }
        }

        public void Close()
        {
            gameObjButtons[0].transform.parent.gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObjButtons[0].transform.parent.gameObject.SetActive(true);
        }

        public void Destroy()
        {
            __toggle.GetComponent<GameSystem.Toggle>().MoveToggle(gameObjButtons[0]);
        }
    }
}
