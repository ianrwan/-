using System;
using System.Collections.Generic;
using Megumin.DataStructure;
using Megumin.GameSystem;
using Megumin.MeguminException;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    public class Action : MonoBehaviour, IBattleScreen
    {
        public GameObject canvaButtons;
        public GameObject[] gameObjButtons;
        private List<Text> textButtons;
        private List<LocalButton> localButtons;
        private GameObject __toggle;

        public void SetUpButton(List<SerealizableButton> list)
        {
            SetButtonOnCharacter();
            localButtons = new List<LocalButton>();

            localButtons = GameObjectConverter.GetListGameObjComponent<LocalButton>(gameObjButtons);

            for(int i = 0 ; i < gameObjButtons.Length ; i++)
            {
                localButtons[i].SetUp(list[i+2].no, list[i+2].name);
            }

            __SetUpToggle();
        }

        private void __SetUpToggle()
        {
            canvaButtons.GetComponent<SetToggle>().SetToggleOnFirstItem();
            GameObjectFind gameObjectFind = new GameObjectFind();
            __toggle = gameObjectFind.FindDecendantTag(canvaButtons, "Toggle")[0];
        }

        private void SetButtonOnCharacter()
        {
            var gameObjsChar = GameObject.FindGameObjectsWithTag("Characters");

            canvaButtons = Instantiate(canvaButtons, gameObjsChar[0].transform);
            
            VectorHandle vectorHandle = new ChoiceVectorHandle(1);
            var vector = vectorHandle.GetVectorDatas(Path.BattleSystem.battleChoiceVector);
            var rectTransform = canvaButtons.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(vector[0].x, rectTransform.position.y, rectTransform.position.z);

            GameObjectFind gameObjectFind = new GameObjectFind();

            gameObjButtons = gameObjectFind.FindDecendantTag(canvaButtons, "Buttons");
        }

        public void ShowButtonText()
        {
            
            if(localButtons.Count == 0)
                throw new BattleButtonException();

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
            }
        }

        public void Close()
        {
            canvaButtons.GetComponent<Canvas>().enabled = false;
        }
    }
}