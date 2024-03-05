using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Megumin.GameSystem;
using Megumin.DataStructure;

namespace Megumin.Battle
{
    public abstract class BattleScreen : MonoBehaviour
    {
        public GameObject prefab;
        public GameObject _parent;
        public GameObject[] _gameObjects;
        protected GameObject _toggle;

        protected System.Action _zPress;
        protected System.Action _xPress;

        public abstract void SetUp(BattleHandleData handleData);
        public abstract void ShowText();
        protected abstract void _SetUpInput();
        protected abstract void _LocalDatasExceptionHandle();

        public void SetUp()
        {
            _SetUpToggle(0);
            _SetUpInput();
        }

        public void UserInput(KeyBoard key)
        {
            _LocalDatasExceptionHandle();

            switch(key)
            {
                case KeyBoard.RIGHT:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.LEFT:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.UP:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.DOWN:
                    _parent.GetComponent<SetToggle>().MoveToggle(key);
                    break;
                case KeyBoard.Z:
                    _zPress?.Invoke();
                    break;
                case KeyBoard.X:
                    _xPress?.Invoke();
                    break;
            }
        }

        public GameObject[] GetGameObjects()
        {
            return _gameObjects;
        }

        public virtual void Close()
        {
            _parent.SetActive(false);
        }

        public virtual void Open()
        {
            _parent.SetActive(true);
        }

        public virtual void Destroy()
        {
            Destroy(_parent);
        }

        protected void _SetUpToggle(int i)
        {
            _parent.GetComponent<SetToggle>().SetToggleOnFirstItem();
            GameObjectFind gameObjectFind = new GameObjectFind();
            _toggle = gameObjectFind.FindDecendantTag(_parent, "Toggle")[i];
        }
    }

}