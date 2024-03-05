using System;
using System.Collections.Generic;
using Megumin.DataStructure;
using Megumin.GameSystem;
using Megumin.MeguminException;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    // public class Action : MonoBehaviour, IBattleScreen, IButtonScreen
    // {
    //     public GameObject prefabCanvaButtons;

    //     private GameObject canvaButtons;
    //     public GameObject[] _gameObjects;
    //     private List<Text> textButtons;
    //     private List<LocalButton> __localDatas;
    //     private GameObject __toggle;
    //     private ButtonChoice buttonChoice;

    //     public void SetUpButton(BattleHandleData handleData)
    //     {
    //         var list = handleData.buttons;

    //         SetButtonOnCharacter();
    //         __localDatas = new List<LocalButton>();

    //         __localDatas = GameObjectConverter.GetListGameObjComponent<LocalButton>(_gameObjects);

    //         for(int i = 0 ; i < _gameObjects.Length ; i++)
    //         {
    //             __localDatas[i].SetUp(list[i+2]);
    //         }

    //         __SetUpToggle();
    //     }

    //     private void __SetUpToggle()
    //     {
    //         canvaButtons.GetComponent<SetToggle>().SetToggleOnFirstItem();
    //         GameObjectFind gameObjectFind = new GameObjectFind();
    //         __toggle = gameObjectFind.FindDecendantTag(canvaButtons, "Toggle")[0];
    //     }

    //     private void SetButtonOnCharacter()
    //     {
    //         var gameObjsChar = GameObject.FindGameObjectsWithTag("Characters");

    //         canvaButtons = Instantiate(prefabCanvaButtons, gameObjsChar[0].transform);

    //         VectorHandle vectorHandle = new ChoiceVectorHandle(1);
    //         var vector = vectorHandle.GetVectorDatas(Path.BattleSystem.battleChoiceVector);
    //         var rectTransform = canvaButtons.GetComponent<RectTransform>();
    //         rectTransform.anchoredPosition = new Vector3(vector[0].x, rectTransform.position.y, rectTransform.position.z);

    //         GameObjectFind gameObjectFind = new GameObjectFind();

    //         _gameObjects = gameObjectFind.FindDecendantTag(canvaButtons, "Buttons");
    //     }

    //     public void ShowButtonText()
    //     {

    //         if(__localDatas.Count == 0)
    //             throw new BattleButtonException();

    //         textButtons = new List<Text>();
    //         int i = 0; 
    //         foreach(var gameObjButton in _gameObjects)
    //         {
    //             textButtons.Add(gameObjButton.GetComponent<Text>());
    //             textButtons[i].text = __localDatas[i].name;
    //             i++;
    //         }
    //     }

    //     public GameObject[] GetButtonsGameObj()
    //     {
    //         return _gameObjects;
    //     }

    //     public void ButtonDo(KeyBoard key)
    //     {
    //         if(__localDatas.Count == 0)
    //             throw new BattleScreenException();

    //         switch(key)
    //         {
    //             case KeyBoard.RIGHT:
    //                 canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.LEFT:
    //                 canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.UP:
    //                 canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.DOWN:
    //                 canvaButtons.GetComponent<SetToggle>().MoveToggle(key);
    //                 break;
    //             case KeyBoard.Z:
    //                 var localToggle = __toggle.GetComponent<GameSystem.Toggle>();
    //                 var button = localToggle.GetToggleCurrent().GetComponent<LocalButton>();
    //                 buttonChoice = button.status;

    //                 button.Click();
    //                 break;
    //         }
    //     }

    //     public void Close()
    //     {
    //         canvaButtons.SetActive(false);
    //     }

    //     public void Open()
    //     {
    //         canvaButtons.SetActive(true);
    //     }

    //     public void Destroy()
    //     {
    //         Destroy(canvaButtons);
    //     }

    //     public ButtonChoice GetButtonChoice()
    //     {
    //         return buttonChoice;
    //     }
    // }

    public class Action : BattleScreen, IButtonChoice
    {
        private List<LocalButton> __localDatas;
        public ButtonChoice buttonChoice;

        public override void SetUp(BattleHandleData handleData)
        {
            var list = handleData.buttons;

            SetButtonOnCharacter();
            __localDatas = new List<LocalButton>();

            __localDatas = GameObjectConverter.GetListGameObjComponent<LocalButton>(_gameObjects);

            for(int i = 0 ; i < _gameObjects.Length ; i++)
            {
                __localDatas[i].SetUp(list[i+2]);
            }

            base.SetUp();
        }

         private void SetButtonOnCharacter()
        {
            var gameObjsChar = GameObject.FindGameObjectsWithTag("Characters");

            _parent = Instantiate(prefab, gameObjsChar[0].transform);

            VectorHandle vectorHandle = new ChoiceVectorHandle(1);
            var vector = vectorHandle.GetVectorDatas(Path.BattleSystem.battleChoiceVector);
            var rectTransform = _parent.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(vector[0].x, rectTransform.position.y, rectTransform.position.z);

            GameObjectFind gameObjectFind = new GameObjectFind();

            _gameObjects = gameObjectFind.FindDecendantTag(_parent, "Buttons");
        }

        public override void ShowText()
        {
            if(__localDatas.Count == 0)
                throw new BattleButtonException();

            var textButtons = new List<Text>();
            int i = 0; 
            foreach(var gameObjButton in _gameObjects)
            {
                textButtons.Add(gameObjButton.GetComponent<Text>());
                textButtons[i].text = __localDatas[i].name;
                i++;
            }
        }

        protected override void _LocalDatasExceptionHandle()
        {
            if(__localDatas.Count == 0)
                throw new BattleButtonException();
        }

        protected override void _SetUpInput()
        {
            _zPress = () =>
            {
                var localToggle = _toggle.GetComponent<GameSystem.Toggle>();
                var button = localToggle.GetToggleCurrent().GetComponent<LocalButton>();
                buttonChoice = button.status;

                button.Click();
            };
        }

        public ButtonChoice GetButtonChoice()
        {
            return buttonChoice;
        }
    }
}