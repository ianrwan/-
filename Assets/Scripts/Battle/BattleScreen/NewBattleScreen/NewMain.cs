using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Megumin.GameSystem;
using Megumin.MeguminException;
using Megumin.DataStructure;

namespace Megumin.Battle
{
    public class NewMain : BattleScreen
    {
        private List<LocalButton> __localDatas;

        private class Serialize
        {
            public string tag;
            public string name;
        }

        public override void SetUp(BattleHandleData handleData)
        {
            _parent = Instantiate(prefab, root.transform);
            // GameObjectFind gameObjectFind = new GameObjectFind();
            // _gameObjects = gameObjectFind.FindDecendantTag(_parent, "Buttons");

            // var list = handleData.buttons;

            // __localDatas = new List<LocalButton>();
            // foreach(var gameObjButton in _gameObjects)
            //     __localDatas.Add(gameObjButton.GetComponent<LocalButton>());

            // __localDatas[0].SetUp(list[0]);
            // __localDatas[1].SetUp(list[1]);

            // base.SetUp();
        }

        public override void ShowText()
        {
            // if(__localDatas.Count == 0)
            //     throw new Exception("");

            // var textButtons = new List<Text>();
            // int i = 0; 
            // foreach(var gameObjButton in _gameObjects)
            // {
            //     textButtons.Add(gameObjButton.GetComponent<Text>());
            //     textButtons[i].text = __localDatas[i].name;
            //     i++;
            // }
        }

        protected override void _SetUpInput()
        {
            _zPress = () =>
            {
                var localToggle = _toggle.GetComponent<GameSystem.Toggle>();
                var button = localToggle.GetToggleCurrent().GetComponent<LocalButton>();
                button.Click();
            }; 
        }

        protected override void _LocalDatasExceptionHandle()
        {
            if(__localDatas.Count <= 0)
                throw new BattleScreenException();
        }

        public override void Close()
        {
            _gameObjects[0].transform.parent.gameObject.SetActive(false);
        }

        public override void Open()
        {
            _gameObjects[0].transform.parent.gameObject.SetActive(true);
        }

        public override void Destroy()
        {
            Destroy(_parent);
        }
    }
}
