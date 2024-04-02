using System;
using System.Collections.Generic;
using Megumin.DataStructure;
using Megumin.GameSystem;
using Megumin.MeguminException;
using UnityEngine;
using UnityEngine.UI;

namespace Megumin.Battle
{
    public class Action : BattleScreen, IGetUpperData<ButtonChoice>
    {
        private List<LocalButton> __localDatas;
        private GameObject current;
        public ButtonChoice buttonChoice;

        public override void SetUp(BattleHandleData handleData)
        {
            var list = handleData.buttons;
            current = handleData.CurrentEntity;
            
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

            _parent = Instantiate(prefab, current.transform); // 暫時放置角色

            VectorHandle vectorHandle = new ChoiceVectorHandle(1);
            var vector = vectorHandle.GetVectorDatas(Path.BattleSystem.battleChoiceVector);
            var rectTransform = _parent.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(vector[0].x, vector[0].y, rectTransform.position.z);

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

        public ButtonChoice GetData()
        {
            return buttonChoice;
        }
    }
}