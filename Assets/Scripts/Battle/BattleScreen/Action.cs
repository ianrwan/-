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

        public void SetUpButton(List<SerealizableButton> list)
        {
            SetButtonOnCharacter();
            localButtons = new List<LocalButton>();

            localButtons = GameObjectConverter.GetListGameObjComponent<LocalButton>(gameObjButtons);

            for(int i = 0 ; i < gameObjButtons.Length ; i++)
            {
                localButtons[i].SetUp(list[i+2].no, list[i+2].name);
            }
        }

        private void SetButtonOnCharacter()
        {
            var gameObjsChar = GameObject.FindGameObjectsWithTag("Characters");

            var canva = Instantiate(canvaButtons, gameObjsChar[0].transform);
            
            VectorHandle vectorHandle = new ChoiceVectorHandle(1);
            var vector = vectorHandle.GetVectorDatas(Path.BattleSystem.battleChoiceVector);
            var rectTransform = canva.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(vector[0].x, rectTransform.position.y, rectTransform.position.z);

            GameObjectFind gameObjectFind = new GameObjectFind();

            gameObjButtons = gameObjectFind.FindDecendantTag(canva, "Buttons");
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

        public void ButtonDo(int num)
        {
            if(localButtons.Count == 0)
                throw new BattleButtonException();

            localButtons[num].Click();
        }

        public void Close()
        {
            canvaButtons.GetComponent<Canvas>().enabled = false;
        }
    }
}